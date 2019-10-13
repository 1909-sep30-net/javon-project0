using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    public static class OrderData
    {
        public static BusinessOrder GetOrderById(int orderId)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            Orders order = context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order is null)
            {
                return null;
            }

            BusinessLocation bLocation = LocationData.GetLocationById(order.LocationId);
            BusinessCustomer bCustomer = CustomerData.GetCustomerById(order.CustomerId);
            BusinessOrder bOrder = new BusinessOrder
            {
                Id = order.Id,
                StoreLocation = bLocation,
                Customer = bCustomer,
                OrderTime = order.OrderTime
            };

            foreach (LineItem item in context.LineItem.Where(l => l.OrdersId == order.Id).ToList())
            {
                Product product = context.Product.Where(p => p.Id == item.ProductId).FirstOrDefault();
                BusinessProduct bProduct = new BusinessProduct()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
                bOrder.AddLineItem(bProduct, item.Quantity);
            }

            return bOrder;
        }

        public static ICollection<BusinessOrder> GetOrdersByLocationId(int locationId)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            List<BusinessOrder> bOrders = new List<BusinessOrder>();
            foreach (int orderId in context.Orders.Where(o => o.LocationId == locationId).Select(o => o.Id).ToList())
            {
                bOrders.Add(GetOrderById(orderId));
            }
            return bOrders;
        }

        public static ICollection<BusinessOrder> GetOrdersByCustomerId(int customerId)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            List<BusinessOrder> bOrders = new List<BusinessOrder>();
            foreach (int orderId in context.Orders.Where(o => o.CustomerId == customerId).Select(o => o.Id).ToList())
            {
                bOrders.Add(GetOrderById(orderId));
            }
            return bOrders;
        }
    }
}
