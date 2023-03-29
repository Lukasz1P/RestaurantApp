using Rest.Common.Enums;
using System.Collections.Generic;
// using Rest.Data.Sql.Enums;

namespace Rest.Data.Sql.DAO
{
    public class Order
    {
        public Order()
        {
            ProductOrders = new List<ProductOrder>();
        }
        
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
        public int TableId { get; set; }
        public int OrderNr { get; set; }
      
    
        
        public virtual Table Table { get; set; }
        public virtual Reservation Reservation { get; set; } 
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        


    }
}