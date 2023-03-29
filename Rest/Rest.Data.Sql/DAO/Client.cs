using System;
using System.Collections.Generic;
using Rest.Common.Enums;

// using Rest.Data.Sql.Enums;

namespace Rest.Data.Sql.DAO
{
    public class Client
    {
        public Client()
        {
            Reservations = new List<Reservation>();
        }
        
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurName { get; set; }
        public int ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        

    }
}