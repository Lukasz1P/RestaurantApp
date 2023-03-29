using System.Threading.Tasks;
using Rest.IData.Client;
using Rest.IServices.Requests;
using Rest.IServices.Client;

namespace Rest.Services.Client
{
    public class ClientService: IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Domain.Client.Client> GetClientByClientId(int clientId)
        {
            return _clientRepository.GetClient(clientId);
        }

        public Task<Domain.Client.Client> GetClientByClientName(string clientName)
        {
            return _clientRepository.GetClient(clientName);
        }

        public async Task<Domain.Client.Client> CreateClient(CreateClient createClient)
        {
            var client = new Domain.Client.Client(createClient.ClientName, createClient.ClientSurName,createClient.ClientEmail, createClient.ClientPhone);
            client.ClientId = await _clientRepository.AddClient(client);
            return client;
        }

        public async Task EditClient(int clientId, EditClient editClient)
        {
            var client = new Domain.Client.Client(clientId,editClient.ClientName, editClient.ClientSurName, editClient.ClientEmail, editClient.ClientPhone);
            await _clientRepository.EditClient(clientId, client);
        }
        public async Task RemoveClient(int clientId)
        {
            await _clientRepository.RemoveClient(clientId);
        }
    }

}