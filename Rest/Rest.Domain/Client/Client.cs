using System;
using Rest.Common.Enums;
using Rest.Domain.DomainExceptions;

namespace Rest.Domain.Client
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurName { get; set; }
        public string ClientEmail { get; set; }
        public int ClientPhone { get; set; }

        public Client(int id, string clientName, string clientSurName, string clientEmail, int clientPhone)
        {
            ClientId = id;
            ClientName = clientName;
            ClientSurName = clientSurName;
            ClientEmail = clientEmail;
            ClientPhone = clientPhone;

        }
        public Client(string clientName, string clientSurName, string clientEmail, int clientPhone)
        {
            ClientName = clientName;
            ClientSurName = clientSurName;
            ClientEmail = clientEmail;
            ClientPhone = clientPhone;
            
        }
        
        public void EditClient(string clientName, string clientSurName, string clientEmail, int clientPhone)
        {
            ClientName = clientName;
            ClientSurName = clientSurName;
            ClientEmail = clientEmail;
            ClientPhone = clientPhone;
        }

    }
}