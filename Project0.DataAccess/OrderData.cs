using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    /// <summary>
    /// DataAccess static class for retrieving and updating the Order objects in the database.
    /// </summary>
    public static class OrderData
    {
        /// <summary>
        /// Retrieves the BusinessOrder with the given order id
        /// </summary>
        /// <param name="orderId">The id of the order</param>
        /// <returns>The BusinessOrder object with the given order id</returns>
        public static BusinessOrder GetOrderWithId(int orderId)
        {
            Log.Information($"Called the Data Access method to get the order with order id {orderId}");
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

        /// <summary>
        /// Retrieves all orders at a given location.
        /// </summary>
        /// <param name="locationId">The id of the location</param>
        /// <returns>All BusinessOrders at a given location</returns>
        public static ICollection<BusinessOrder> GetOrdersWithLocationId(int locationId)
        {
            Log.Information($"Called the Data Access method to get the orders with location id {locationId}");
            using var context = new TThreeTeasContext(SQLOptions.options);

            List<BusinessOrder> bOrders = new List<BusinessOrder>();
            foreach (int orderId in context.Orders.Where(o => o.LocationId == locationId).Select(o => o.Id).ToList())
            {
                bOrders.Add(GetOrderWithId(orderId));
            }
            return bOrders;
        }

        /// <summary>
        /// Retrieves all orders of a customer
        /// </summary>
        /// <param name="customerId">The id of the customer</param>
        /// <returns>All BusinessOrders of a customer</returns>
        public static ICollection<BusinessOrder> GetOrdersWithCustomerId(int customerId)
        {
            Log.Information($"Called the Data Access method to get the orders with customer id {customerId}");
            using var context = new TThreeTeasContext(SQLOptions.options);

            List<BusinessOrder> bOrders = new List<BusinessOrder>();
            foreach (int orderId in context.Orders.Where(o => o.CustomerId == customerId).Select(o => o.Id).ToList())
            {
                bOrders.Add(GetOrderWithId(orderId));
            }
            return bOrders;
        }

        /// <summary>
        /// Creates an order
        /// </summary>
        /// <param name="bOrder">
        /// The BusinessOrder which contains all the necessary information to create an order such as
        /// line items and updated inventory
        /// </param>
        public static void CreateOrder(BusinessOrder bOrder)
        {
            Log.Information($"Called the Data Access method to create an order with business order {bOrder}");
            using var context = new TThreeTeasContext(SQLOptions.options);

            Orders additionalOrder = new Orders()
            {
                LocationId = bOrder.StoreLocation.Id,
                CustomerId = bOrder.Customer.Id,
                OrderTime = bOrder.OrderTime
            };

            context.Orders.Add(additionalOrder);
            context.SaveChanges();
            Log.Information($"Saved the additional order to the database");

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
            Log.Information($"Saved the additional line items to the database");

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
            Log.Information($"Saved the updated inventories to the database");
        }
    }
}
