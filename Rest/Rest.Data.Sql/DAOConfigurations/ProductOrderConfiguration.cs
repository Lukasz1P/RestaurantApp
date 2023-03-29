using Rest.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Rest.Data.Sql.DAOConfigurations;

public class ProductOrderConfiguration: IEntityTypeConfiguration<ProductOrder>
{
    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    {
        
        builder.HasOne(x => x.Order)
            .WithMany(x => x.ProductOrders)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x => x.OrderId);
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductOrders)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x=>x.ProductId);
            
        
        builder.ToTable("ProductOrder");
    }
}