using System;
using Rest.Common.Enums;

namespace Rest.IServices.Requests
{
    public class EditClient
    {
        
        public string ClientName { get; set; }
        public string ClientSurName { get; set; }
        public string ClientEmail { get; set; }
        public int ClientPhone { get; set; }

    }
}