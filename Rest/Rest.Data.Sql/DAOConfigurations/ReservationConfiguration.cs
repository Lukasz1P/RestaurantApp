using Rest.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Rest.Data.Sql.DAOConfigurations;

public class ReservationConfiguration: IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
      
        builder.Property(c => c.Number).IsRequired();
        builder.Property(c => c.ReservationStart).IsRequired(); 
        builder.Property(c => c.ReservationEnd).IsRequired();

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Reservations)
            .OnDelete(DeleteBehavior.Restrict) 
            .HasForeignKey(x => x.ClientId);
            
        
        builder.ToTable("Reservation");
    }
}