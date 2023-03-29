using Rest.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Rest.Data.Sql.DAOConfigurations;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(c => c.ProductId).IsRequired(); 
        builder.Property(c => c.Price).IsRequired(); 
        builder.Property(c => c.Name).IsRequired(); 
        
        
        builder.ToTable("Product");
    }
}