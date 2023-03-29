using System;
using Rest.Common.Enums;

namespace Rest.Api.ViewModels
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurName { get; set; }
        public int ClientPhone { get; set; }
        public string ClientEmail { get; set; }

    }
}