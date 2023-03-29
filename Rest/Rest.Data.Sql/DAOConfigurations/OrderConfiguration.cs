using Rest.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Rest.Data.Sql.DAOConfigurations;

public class OrderConfiguration: IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
       
        builder.Property(c => c.TableId).IsRequired(); 
        builder.Property(c => c.ReservationId).IsRequired(); 
        builder.Property(c => c.OrderNr).IsRequired();

        builder.HasOne(x=>x.Reservation)
            .WithMany(x=>x.Orders)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x => x.ReservationId);
        builder.HasOne(x=>x.Table)
            .WithMany(x=>x.Orders)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x => x.TableId);
        
            
        
        builder.ToTable("Order");
    }
}