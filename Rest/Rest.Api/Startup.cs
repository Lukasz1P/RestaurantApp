using FluentValidation;
using FluentValidation.AspNetCore;
using Rest.Api.BindingModels;
using Rest.Api.Middlewares;
using Rest.Data.Sql;
using Rest.Data.Sql.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rest.Services.Client;
using Rest.IServices.Client;
using Rest.Api.Validation;
using Rest.Data.Sql.Client;
using Rest.IData.Client;


namespace Rest.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private const string MySqlHealthCheckName = "mysql";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        
        
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();           
            
            
            
            
            services.AddDbContext<RestDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("RestDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddHealthChecks();
            services.AddControllers().AddNewtonsoftJson(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation();
            services.AddTransient<IValidator<EditClient>, EditClientValidator>();
            services.AddTransient<IValidator<CreateClient>, CreateClientValidator>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });
        }
        
        
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) 
                .AllowCredentials()); 

            app.UseAuthentication();

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<RestDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();
                
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}