//using Project0.Logic;
//using System;
//using System.Collections.Generic;
//
//namespace Project0.Data
//{
//    public static class MemoryStore
//    {
//        static public List<Product> Products { get; set; }
//        static public List<Location> Locations { get; set; }
//        static public List<Customer> Customers { get; set; }
//        static public List<Order> Orders { get; set; }
//        static MemoryStore()
//        {
//            Product prd1 = new Product()
//            {
//                Id = 1,
//                Name = "Butterscotch",
//                Price = 20.56
//            };

//            Product prd2 = new Product()
//            {
//                Id = 2,
//                Name = "Dark Chocolate Peppermint",
//                Price = 15.78
//            };

//            Product prd3 = new Product()
//            {
//                Id = 3,
//                Name = "White Winter Chai",
//                Price = 9.78
//            };

//            Product prd4 = new Product()
//            {
//                Id = 4,
//                Name = "Fresh Greens Tea",
//                Price = 23.62
//            };

//            Product prd5 = new Product()
//            {
//                Id = 5,
//                Name = "Pumpkin Pie",
//                Price = 8.34
//            };

//            Product prd6 = new Product()
//            {
//                Id = 6,
//                Name = "Jasmine Ancient Beauty Tea",
//                Price = 30.12
//            };

//            Location loc1 = new Location()
//            {
//                Id = 1,
//                Address = "8 Winding Street",
//                City = "Hilly Glory",
//                Zipcode = 71550,
//                State = USState.AK
//            };
//            loc1.AddProduct(prd3, 4);
//            loc1.AddProduct(prd4, 11);
//            loc1.AddProduct(prd6, 21);

//            Location loc2 = new Location()
//            {
//                Id = 2,
//                Address = "32 Bull",
//                City = "Ranch Plaza",
//                Zipcode = 90235,
//                State = USState.LA
//            };
//            loc2.AddProduct(prd2, 8);
//            loc2.AddProduct(prd3, 14);
//            loc2.AddProduct(prd5, 6);

//            Location loc3 = new Location()
//            {
//                Id = 3,
//                Address = "192 Main",
//                City = "Shining Beacon",
//                Zipcode = 89567,
//                State = USState.SD
//            };
//            loc3.AddProduct(prd1, 6);
//            loc3.AddProduct(prd3, 15);
//            loc3.AddProduct(prd5, 7);
//            loc3.AddProduct(prd6, 12);

//            Customer cst1 = new Customer()
//            {
//                Id = 1,
//                FirstName = "javon",
//                LastName = "negahban"
//            };

//            Customer cst2 = new Customer()
//            {
//                Id = 2,
//                FirstName = "ojan",
//                LastName = "negahban"
//            };

//            Customer cst3 = new Customer()
//            {
//                Id = 3,
//                FirstName = "henry",
//                LastName = "ford"
//            };

//            Customer cst4 = new Customer()
//            {
//                Id = 4,
//                FirstName = "bruce",
//                LastName = "lee"
//            };

//            Customer cst5 = new Customer()
//            {
//                Id = 5,
//                FirstName = "lucy",
//                LastName = "shepherd"
//            };

//            Order ord1 = new Order()
//            {
//                Id = 1,
//                StoreLocation = loc2,
//                Customer = cst3,
//                OrderDateTime = DateTime.Now.AddHours(-5)
//            };
//            ord1.AddLineItem(prd2, 1); 

//            Order ord2 = new Order()
//            {
//                Id = 2,
//                StoreLocation = loc3,
//                Customer = cst4,
//                OrderDateTime = DateTime.Now.AddHours(-20)
//            };
//            ord2.AddLineItem(prd1, 4);
//            ord2.AddLineItem(prd3, 1);

//            Order ord3 = new Order()
//            {
//                Id = 3,
//                StoreLocation = loc1,
//                Customer = cst2,
//                OrderDateTime = DateTime.Now.AddHours(-2)
//            };
//            ord3.AddLineItem(prd4, 3);

//            Order ord4 = new Order()
//            {
//                Id = 4,
//                StoreLocation = loc3,
//                Customer = cst4,
//                OrderDateTime = DateTime.Now.AddHours(-1)
//            };
//            ord4.AddLineItem(prd6, 3);
//            ord4.AddLineItem(prd5, 1);
//            ord4.AddLineItem(prd1, 1);

//            Order ord5 = new Order()
//            {
//                Id = 5,
//                StoreLocation = loc1,
//                Customer = cst1,
//                OrderDateTime = DateTime.Now.AddHours(-11)
//            };
//            ord5.AddLineItem(prd4, 5);
//            ord5.AddLineItem(prd6, 3);

//            Products = new List<Product>() { prd1, prd2, prd3, prd4, prd5, prd6 };
//            Locations = new List<Location>() { loc1, loc2, loc3 };
//            Customers = new List<Customer>() { cst1, cst2, cst3, cst4, cst5 };
//            Orders = new List<Order>() { ord1, ord2, ord3, ord4, ord5 };
//        }
//    }
//}
//