using System;
using System.Collections.Generic;

namespace Rest.Data.Sql.DAO
{


    public class Reservation
    {
        public Reservation()
        {

            Orders = new List<Order>();
        }

        public int ReservationId { get; set; }
        public int ClientId { get; set; }
        public int Number { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }


        
        public virtual Client Client { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


    }
}