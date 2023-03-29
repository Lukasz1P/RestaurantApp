using Rest.Api.ViewModels;

namespace Rest.Api.Mappers
{
    public class ClientToClientViewModelMapper
    {
        public static ClientViewModel ClientToClientViewModel(Domain.Client.Client client)
        {
            var clientViewModel = new ClientViewModel
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                ClientSurName = client.ClientSurName,
                ClientEmail = client.ClientEmail,
                ClientPhone = client.ClientPhone,
            };
            return clientViewModel;
        }

    }
}