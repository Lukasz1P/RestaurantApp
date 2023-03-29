using Rest.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Rest.Data.Sql.DAOConfigurations;

public class ClientConfiguration: IEntityTypeConfiguration<DAO.Client>
{
    public void Configure(EntityTypeBuilder<DAO.Client> builder)
    {
        //metoda IsRequired() wymusza w bazie ustawienie koleumny na NotNull
        //builder.Property(c => c.ClientId).IsRequired();    
        //builder.Property(c => c.OrderId).IsRequired(); 
        builder.Property(c => c.ClientName).IsRequired(); 
        builder.Property(c => c.ClientSurName).IsRequired(); 
        builder.Property(c => c.ClientPhone).IsRequired(); 
        builder.Property(c => c.ClientEmail).IsRequired();
        
        builder.ToTable("Client");
    }
}