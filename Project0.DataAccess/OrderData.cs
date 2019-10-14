using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    public static class OrderData
    {
        public static BusinessOrder GetOrderWithId(int orderId)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            Orders order = context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order is null)
            {
                return null;
            }

            BusinessLocation bLocation = LocationData.GetLocationWithId(order.LocationId);
            BusinessCustomer bCustomer = CustomerData.GetCustomerWithId(order.CustomerId);
            BusinessOrder bOrder = new BusinessOrder
            {
                Id = order.Id,
                StoreLocation = bLocation,
                Customer = bCustomer,
                OrderTime = order.OrderTime
            };

            Dictionary<BusinessProduct, int> lineItems = new Dictionary<BusinessProduct, int>();
            foreach (LineItem item in context.LineItem.Where(l => l.OrdersId == order.Id).ToList())
            {
                Product product = context.Product.Where(p => p.Id == item.ProductId).FirstOrDefault();
                BusinessProduct bProduct = new BusinessProduct()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
                lineItems.Add(bProduct, item.Quantity);
            }
            bOrder.AddLineItems(lineItems);

            return bOrder;
        }

        public static ICollection<BusinessOrder> GetOrdersWithLocationId(int locationId)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            List<BusinessOrder> bOrders = new List<BusinessOrder>();
            foreach (int orderId in context.Orders.Where(o => o.LocationId == locationId).Select(o => o.Id).ToList())
            {
                bOrders.Add(GetOrderWithId(orderId));
            }
            return bOrders;
        }

        public static ICollection<BusinessOrder> GetOrdersWithCustomerId(int customerId)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            List<BusinessOrder> bOrders = new List<BusinessOrder>();
            foreach (int orderId in context.Orders.Where(o => o.CustomerId == customerId).Select(o => o.Id).ToList())
            {
                bOrders.Add(GetOrderWithId(orderId));
            }
            return bOrders;
        }

        public static void CreateOrder(BusinessOrder bOrder)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            Orders additionalOrder = new Orders()
            {
                LocationId = bOrder.StoreLocation.Id,
                CustomerId = bOrder.Customer.Id,
                OrderTime = bOrder.OrderTime
            };

            context.Orders.Add(additionalOrder);
            context.SaveChanges();

            List<LineItem> additionalLineItems = new List<LineItem>();
            foreach (KeyValuePair<BusinessProduct, int> lineItem in bOrder.LineItems)
            {
                LineItem additionalLineItem = new LineItem()
                {
                    OrdersId = additionalOrder.Id,
                    ProductId = lineItem.Key.Id,
                    Quantity = lineItem.Value
                };
                additionalLineItems.Add(additionalLineItem);
            }
            foreach (LineItem additionalLineItem in additionalLineItems)
            {
                context.LineItem.Add(additionalLineItem);
            }
            context.SaveChanges();

            List<Inventory> updatedInventories = new List<Inventory>();
            foreach (KeyValuePair<BusinessProduct, int> inventory in bOrder.StoreLocation.inventory)
            {
                Inventory updatedInventory = new Inventory()
                {
                    LocationId = bOrder.StoreLocation.Id,
                    ProductId = inventory.Key.Id,
                    Stock = inventory.Value
                };
                updatedInventories.Add(updatedInventory);
            }
            foreach (Inventory updatedInventory in updatedInventories)
            {
                context.Inventory.Update(updatedInventory);
            }
            context.SaveChanges();
        }
    }
}
