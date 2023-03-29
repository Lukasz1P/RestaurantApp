using System.Threading.Tasks;
using Rest.IServices.Requests;

namespace Rest.IServices.Client
{
    public interface IClientService
    {
       
        Task<Rest.Domain.Client.Client> GetClientByClientId(int clientId);
        Task<Rest.Domain.Client.Client> GetClientByClientName(string clientName);
        Task<Rest.Domain.Client.Client> CreateClient(CreateClient createClient);
        Task EditClient(int clientId, EditClient editClient);
        
        Task RemoveClient(int clientId);
    }
}