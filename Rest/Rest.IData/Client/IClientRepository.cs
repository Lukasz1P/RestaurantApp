using System.Threading.Tasks;

namespace Rest.IData.Client
{
    public interface IClientRepository
    {
       
        Task<int> AddClient(Rest.Domain.Client.Client client);
        Task<Rest.Domain.Client.Client> GetClient(int clientId);
        Task<Rest.Domain.Client.Client> GetClient(string clientName);
        Task EditClient(int clientId, Domain.Client.Client client);
        
        Task RemoveClient(int clientId);
    }
}