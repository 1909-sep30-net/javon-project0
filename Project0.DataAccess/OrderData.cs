//using Project0.BusinessLogic;
//using System;
//using System.Collections.Generic;

//namespace Project0.DataAccess
//{
//    public static class OrderData
//    {
//        public static List<Order> GetOrdersByCustomer(int cId)
//        {
//            List<Order> orders = new List<Order>();
//            foreach (Order ord in MemoryStore.Orders)
//            {
//                if (ord.Customer.Id == cId)
//                {
//                    orders.Add(ord);
//                }
//            }
//            return orders;
//        }
//        public static List<Order> GetOrdersByLocation(int lId)
//        {
//            List<Order> orders = new List<Order>();
//            foreach (Order ord in MemoryStore.Orders)
//            {
//                if (ord.StoreLocation.Id == lId)
//                {
//                    orders.Add(ord);
//                }
//            }
//            return orders;
//        }
//        public static Order GetOrderById(int id)
//        {
//            foreach (Order order in MemoryStore.Orders)
//            {
//                if (order.Id == id)
//                {
//                    return order;
//                }
//            }

//            return null;
//        }
//    }
//}
