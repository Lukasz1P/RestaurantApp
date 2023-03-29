using System;
using System.Linq;
using System.Threading.Tasks;
using Rest.IData.Client;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Rest.Data.Sql.DAO;

namespace Rest.Data.Sql.Client
{
    public class ClientRepository: IClientRepository
    {
        private readonly RestDbContext _context;

        public ClientRepository(RestDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddClient(Domain.Client.Client client)
        {
            var clientDAO =  new DAO.Client { 
                ClientName = client.ClientName,
                ClientSurName = client.ClientSurName,
                ClientEmail = client.ClientEmail,
                ClientPhone = client.ClientPhone,
                
            };
            await _context.AddAsync(clientDAO);
            await _context.SaveChangesAsync();
            return clientDAO.ClientId;
        }

       /* public async Task<Domain.Client.Client> GetAllClients()
        {
            var client = await _context.Client.FirstOrDefaultAsync();
            return new Domain.Client.Client(
                client.ClientId,
                client.ClientName,
                client.ClientSurName,
                client.ClientEmail,
                client.ClientPhone
            );
        }*/
        public async Task<Domain.Client.Client> GetClient(int clientId)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x=>x.ClientId == clientId);
            return new Domain.Client.Client(client.ClientId,
                client.ClientName,
                client.ClientSurName,
                client.ClientEmail,
                client.ClientPhone
            );
        }

        public async Task<Domain.Client.Client> GetClient(string clientName)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x=>x.ClientName == clientName);
            return new Domain.Client.Client(
                client.ClientId,
                client.ClientName,
                client.ClientSurName,
                client.ClientEmail,
                client.ClientPhone);
        }

        public async Task EditClient(int clientId, Domain.Client.Client client)
        {
            var editClient = await _context.Client.FirstOrDefaultAsync(x=>x.ClientId == client.ClientId);
            editClient.ClientName = client.ClientName;
            editClient.ClientSurName = client.ClientSurName;
            editClient.ClientEmail = client.ClientEmail;
            editClient.ClientPhone = client.ClientPhone;
            
            
            await _context.SaveChangesAsync();
        }
        public async Task RemoveClient(int clientId)
        {

          
            var client = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == clientId);

            if (client == null)
            {
                throw new Exception("Client not found");
            }
            
        
            
            _context.ProductOrder.RemoveRange(_context.ProductOrder.Where(x => x.OrderId == clientId));
            _context.Order.RemoveRange(_context.Order.Where(x => x.ReservationId == clientId));
            _context.Reservation.RemoveRange(_context.Reservation.Where(x => x.ClientId == clientId));
            
            _context.Client.Remove(client);
            
            await _context.SaveChangesAsync();
        }
    }

}