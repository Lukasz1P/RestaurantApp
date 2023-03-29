using System.Collections.Generic;

namespace Rest.Data.Sql.DAO
{
    //tag
    public class Product
    {
        public Product()
        {
            ProductOrders = new List<ProductOrder>();
        }
        
        public int ProductId { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }

    }
}