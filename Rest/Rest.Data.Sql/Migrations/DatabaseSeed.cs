using System;
using System.Collections.Generic;
using System.Linq;
using Rest.Common.Enums;
using Rest.Common.Extensions;
using Rest.Data.Sql.DAO;

namespace Rest.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly RestDbContext _context;

        //wstrzyknięcie instancji klasy RestDbContext poprzez konstruktor
        public DatabaseSeed(RestDbContext context)
        {
            _context = context;
        }

        //metoda odpowiadająca za uzupełnienie utworzonej bazy danych testowymi danymi
        //kolejność wywołania ma niestety znaczenie, ponieważ nie da się utworzyć rekordu
        //w bazie dnaych bez znajmości wartości klucza obcego
        //dlatego należy zacząć od uzupełniania tabel, które nie posiadają kluczy obcych
        //--OFFTOP
        //w przeciwną stronę działa ręczne usuwanie tabel z wypełnionymi danymi w bazie danych
        //należy zacząć od tabel, które posiadają klucze obce, a skończyć na tabelach, które 
        //nie posiadają
        public void Seed()
        {
            //regiony pozwalają na zwinięcie kodu w IDE
            //nie sa dobrą praktyką, kod w danej klasie/metodzie nie powinien wymagać jego zwijania
            //zastosowałem je z lenistwa nie powinno to mieć miejsca 

            #region CreateClients

            var clientList = BuildClientList();
            //dodanie użytkowników do tabeli User
            _context.Client.AddRange(clientList);
            //zapisanie zmian w bazie danych
            _context.SaveChanges();

            #endregion


            #region CreateTables

            var tableList = BuildTableList();
            _context.Table.AddRange(tableList);
            _context.SaveChanges();

            #endregion

            #region CreateProducts

            var productList = BuildProductList();
            _context.Product.AddRange(productList);
            _context.SaveChanges();

            #endregion
            
            #region CreateReservations

            var reservationList = BuildReservationList(clientList);
            _context.Reservation.AddRange(reservationList);
            _context.SaveChanges();

            #endregion

            #region CreateOrders

            var orderList = BuildOrderList(reservationList,tableList);
            _context.Order.AddRange(orderList);
            _context.SaveChanges();

            #endregion

            #region CreateProductOrders

            var productOrderList = BuildProductOrderList(productList, orderList);
            _context.ProductOrder.AddRange(productOrderList);
            _context.SaveChanges();

            #endregion

        }

        private IEnumerable<DAO.Client> BuildClientList()
        {
            var clientList = new List<DAO.Client>();
            var client = new DAO.Client()
            {
                ClientName = "Tomasz",
                ClientSurName = "Podolski",
                ClientPhone = 123123123,
                ClientEmail = "t.podolski@wp.pl"

            };
            clientList.Add(client);

            var client2 = new DAO.Client()
            {
                ClientName = "Adam",
                ClientSurName = "Pasieka",
                ClientPhone = 987987987,
                ClientEmail = "a.pasieka@wp.pl"
            };
            clientList.Add(client2);

            for (int i = 3; i <= 6; i++)
            {
                var client3 = new DAO.Client
                {
                    ClientName = "client" + i,
                    ClientSurName = "surname" + i,
                    ClientPhone = i,
                    ClientEmail = "client" + i + "@wp.pl",
                };
                clientList.Add(client3);
            }

            return clientList;
        }



        private IEnumerable<Product> BuildProductList()
        {
            var productList = new List<Product>
            {
                new Product
                {
                    Name = "Sushi",
                    Price = 13,
                    Number = 1
                },

                new Product
                {
                    Name = "PizzaSalami",
                    Price = 24,
                    Number = 1
                },

                new Product
                {
                    Name = "PizzaCapriciosa",
                    Price = 20,
                    Number = 1
                },

                new Product
                {
                    Name = "PizzaHawajska",
                    Price = 27,
                    Number = 1
                },


                new Product
                {
                    Name = "Burger BBQ",
                    Price = 27,
                    Number = 1
                },

                new Product
                {
                    Name = "KebabAmerykanskiXL",
                    Price = 34,
                    Number = 1
                },

            };

            return productList;
        }

        private IEnumerable<Table> BuildTableList()
        {
            var tableList = new List<Table>
            {
                new Table
                {
                    HallNr = 1,
                    Size = 2,
                    Available = "Yes"
                },

                new Table
                {
                    HallNr = 1,
                    Size = 2,
                    Available = "Yes"
                },

                new Table
                {
                    HallNr = 1,
                    Size = 4,
                    Available = "Yes"
                },

                new Table
                {
                    HallNr = 2,
                    Size = 3,
                    Available = "Yes"
                },

                new Table
                {
                    HallNr = 2,
                    Size = 3,
                    Available = "Yes"
                },
                new Table
                {
                    HallNr = 2,
                    Size = 3,
                    Available = "No"
                }


            };


            return tableList;
        }
        
        
        /*private IEnumerable<Reservation> BuildReservationList(
            IEnumerable<DAO.Client> clientList)
        {
            var reservationList = new List<Reservation>();
            var r = new Random();
            var clientCount = clientList.ToList().Count;
            foreach (var client in clientList)
            {
                var clientId = r.Next(clientCount);
                reservationList.Add(new Reservation()
                {
                    
                    ClientId = clientList.ToList()[clientId].ClientId,
                    ReservationStart = DateTime.Now,
                    ReservationEnd = DateTime.Now,

                });
            }

            return reservationList;
        }*/
        private IEnumerable<Reservation> BuildReservationList(
            IEnumerable<DAO.Client> clientList)
        {
            var reservationList = new List<Reservation>();
            var r = new Random();
            var clientCount = clientList.ToList().Count;
            for (int i = 1; i < 7; i++ )
            {
                var clientId = r.Next(clientCount);
                reservationList.Add(new Reservation()
                {
                    
                    ClientId = i,
                    ReservationStart = DateTime.Now,
                    ReservationEnd = DateTime.Now,

                });
            }

            return reservationList;
        }
        

        
        /*private IEnumerable<ProductOrder> BuildProductOrderList(IEnumerable<Product> productList,
            IEnumerable<Order> orderList)
        {
            var productOrderList = new List<ProductOrder>();
            
            
            var r = new Random();
            var orderCount = orderList.ToList().Count;
            var productCount = productList.ToList().Count;
            foreach (var product in productList)
            {
                var orderIdFk=r.Next(orderCount);
                var productIdFk=r.Next(productCount);
                productOrderList.Add(new ProductOrder
                {
                    ProductId = productList.ToList()[productIdFk].ProductId,
                    OrderId = orderList.ToList()[orderIdFk].OrderId,
                });

            }

            return productOrderList;
        }*/
        private IEnumerable<ProductOrder> BuildProductOrderList(IEnumerable<Product> productList,
            IEnumerable<Order> orderList)
        {
            var productOrderList = new List<ProductOrder>();
            
            
            var r = new Random();
            var orderCount = orderList.ToList().Count;
            var productCount = productList.ToList().Count;
            for (int i = 1; i < 7; i++ )
            {
                var orderIdFk=r.Next(orderCount);
                var productIdFk=r.Next(productCount);
                productOrderList.Add(new ProductOrder
                {
                    ProductId = i,
                    OrderId = i,
                });

            }

            return productOrderList;
        }
        

        /*private IEnumerable<Order> BuildOrderList(
            IEnumerable<Reservation>reservationList,
            IEnumerable<Table>tableList)
        {
            var orderList = new List<Order>();
            var rand = new Random();
            var reservationCount = reservationList.ToList().Count;
            var tableCount = tableList.ToList().Count;
           
                foreach (var reservation in reservationList)
                {
                    var ReservationId_fk = rand.Next(reservationCount);
                    var TableId_fk = rand.Next(tableCount);
                    
                    orderList.Add(new Order
                    {
                        ReservationId = reservationList.ToList()[ReservationId_fk].ReservationId,
                        TableId = tableList.ToList()[TableId_fk].TableId,
                        
                        OrderNr=rand.Next(1,8),
                    });
                
                }

            return orderList;
        }*/
        
        private IEnumerable<Order> BuildOrderList(
            IEnumerable<Reservation>reservationList,
            IEnumerable<Table>tableList)
        {
            var orderList = new List<Order>();
            var rand = new Random();
            var reservationCount = reservationList.ToList().Count;
            var tableCount = tableList.ToList().Count;
           
            for (int i = 1; i < 7; i++ )
            {
                var ReservationId_fk = rand.Next(reservationCount);
                var TableId_fk = rand.Next(tableCount);
                    
                orderList.Add(new Order
                {
                    ReservationId = i,
                    TableId = i,
                        
                    OrderNr=rand.Next(1,8),
                });
                
            }

            return orderList;
        }

        

    }
}