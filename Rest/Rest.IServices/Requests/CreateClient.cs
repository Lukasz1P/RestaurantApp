using System;
using Rest.Common.Enums;

namespace Rest.IServices.Requests
{
    public class CreateClient
    {
        public string ClientName { get; set; }
        public string ClientSurName { get; set; }
        public string ClientEmail { get; set; }
        public int ClientPhone { get; set; }
        
        
       

    }
}