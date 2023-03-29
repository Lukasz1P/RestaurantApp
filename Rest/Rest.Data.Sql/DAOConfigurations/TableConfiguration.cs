using Rest.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Rest.Data.Sql.DAOConfigurations;

public class TableConfiguration: IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
       
       
        builder.Property(c => c.Size).IsRequired(); 
        builder.Property(c => c.HallNr).IsRequired();
        builder.Property(c => c.Available).IsRequired();


        builder.HasMany(x => x.Orders)
            .WithOne(x => x.Table)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x => x.ReservationId);
        
            
        
        builder.ToTable("Table");
    }
}