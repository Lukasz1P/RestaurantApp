using System.Collections.Generic;

namespace Rest.Data.Sql.DAO
{
    //klasa (często nazywana encją) oddająca strukturę tabeli w bazie danych
    //wraz z relacjami z innymi encji/tabel
    public class Table
    {
        public Table()
        {
            Orders = new List<Order>();
        }

        public int TableId { get; set; }
        public int Size { get; set; }
        public int HallNr { get; set; }
        public string Available { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}