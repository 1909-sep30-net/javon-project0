using Project0.BusinessLogic;
using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.App
{
    internal class MenuHandler
    {
        internal static void HandleRequest(MenuRequest req)
        {
            if (req.Equals(MenuRequest.PlaceOrder))
            {
                HandleRequestPlaceOrder();
            }
            else if (req.Equals(MenuRequest.AddCustomer))
            {
                HandleRequestAddCustomer();
            }
            else if (req.Equals(MenuRequest.SearchCustomer))
            {
                HandleRequestSearchCustomer();
            }
            else if (req.Equals(MenuRequest.DisplayDetailsOfOrder))
            {
                HandleRequestDisplayDetailsOfOrder();
            }
            else if (req.Equals(MenuRequest.DisplayOrderHistoryOfLocation))
            {
                HandleRequestDisplayOrderHistoryOfLocation();
            }
            else if (req.Equals(MenuRequest.DisplayOrderHistoryOfCustomer))
            {
                HandleRequestDisplayOrderHistoryOfCustomer();
            }
            else if (req.Equals(MenuRequest.DisplayAllLocations))
            {
                HandleRequestDisplayAllLocations();
            }
            else if (req.Equals(MenuRequest.Exit))
            {
                HandleRequestExit();
            }
            else
            {
                HandleRequestInvalid();
            }
        }

        private static void HandleRequestPlaceOrder()
        {
            int line = 0;
            Dictionary<int, int> lineItemsParsed = new Dictionary<int, int>();
            Dictionary<BusinessProduct, int> lineItems = new Dictionary<BusinessProduct, int>();

            Console.WriteLine("[?] What is the customer ID");
            string inputCustomerId = Console.ReadLine();
            if (!Int32.TryParse(inputCustomerId, out int customerId))
            {
                throw new FormatException($"[!] Input for customer ID is not an integer");
            }

            Console.WriteLine("[?] What is the location ID");
            string inputLocationId = Console.ReadLine();
            if (!Int32.TryParse(inputLocationId, out int locationId))
            {
                throw new FormatException($"[!] Input for location ID is not an integer");
            }

            while (++line > 0)
            {
                Console.WriteLine($"[?] Line {line} - Enter product ID or press enter to finish your order");
                string inputProductId = Console.ReadLine();
                if (inputProductId == "")
                {
                    break;
                }
                if (!Int32.TryParse(inputProductId, out int productId))
                {
                    throw new FormatException($"[!] Input for product ID is not an integer");
                }

                Console.WriteLine($"[?] Line {line} - Enter quantity");
                string inputQuantity = Console.ReadLine();
                if (!Int32.TryParse(inputQuantity, out int quantity))
                {
                    throw new FormatException($"[!] Input for quantity is not an integer");
                }

                lineItemsParsed.Add(productId, quantity);
            }

            if (CustomerData.GetCustomerWithId(customerId) is null)
            {
                throw new BusinessCustomerException($"[!] Customer does not exist");
            }

            if (LocationData.GetLocationWithId(locationId) is null)
            {
                throw new BusinessLocationException($"[!] Location does not exist");
            }

            foreach (KeyValuePair<int, int> lineItemParsed in lineItemsParsed)
            {
                BusinessProduct bProduct = ProductData.GetProductWithId(lineItemParsed.Key);
                if (bProduct is null)
                {
                    throw new BusinessProductException($"[!] Product {lineItemParsed.Key} does not exist");
                }
                lineItems.Add(bProduct, lineItemParsed.Value);
            }

            BusinessCustomer bCustomer = CustomerData.GetCustomerWithId(customerId);
            BusinessLocation bLocation = LocationData.GetLocationWithId(locationId);

            BusinessOrder bOrder = new BusinessOrder()
            {
                StoreLocation = bLocation,
                Customer = bCustomer,
                OrderTime = DateTime.Now
            };
            bOrder.AddLineItems(lineItems);
            foreach (KeyValuePair<BusinessProduct, int> lineItem in lineItems)
            {
                bOrder.StoreLocation.DecrementStock(lineItem.Key, lineItem.Value);
            }
            OrderData.CreateOrder(bOrder);
        }

        private static void HandleRequestAddCustomer()
        {
            BusinessCustomer customer = new BusinessCustomer();

            Console.WriteLine("[?] What is the first name of the customer");
            string firstName = Console.ReadLine();
            customer.FirstName = firstName;

            Console.WriteLine("[?] What is the last name of the customer");
            string lastName = Console.ReadLine();
            customer.LastName = lastName;

            CustomerData.AddCustomer(customer);
            Console.WriteLine($"[+] The customer {customer.FirstName} {customer.LastName} has been added\n");
        }

        private static void HandleRequestSearchCustomer()
        {
            BusinessCustomer customer = new BusinessCustomer();

            Console.WriteLine("[?] What is the last name of the customer you are searching for");
            string lastName = Console.ReadLine();
            customer.LastName = lastName;

            ICollection<BusinessCustomer> customersWithLastName = CustomerData.GetCustomersWithLastName(customer.LastName);
            Console.WriteLine($"[*] There are {customersWithLastName.Count} customers with the last name \"{lastName}\"");
            customersWithLastName.ToList().ForEach(c => Console.WriteLine(c));
            Console.WriteLine();
        }

        private static void HandleRequestDisplayDetailsOfOrder()
        {
            Console.WriteLine("[?] What is the order ID");
            string inputOrderId = Console.ReadLine();
            if (!Int32.TryParse(inputOrderId, out int orderId))
            {
                throw new FormatException("[!] Input for order ID is not an integer");
            }

            BusinessOrder order = OrderData.GetOrderWithId(orderId);
            if (order is null)
            {
                throw new BusinessOrderException($"[!] Order {orderId} does not exist in the database");
            }

            Console.WriteLine($"{order}\n");
        }

        private static void HandleRequestDisplayOrderHistoryOfLocation()
        {
            Console.WriteLine("[?] What is the location ID");
            string inputLocationId = Console.ReadLine();
            if (!Int32.TryParse(inputLocationId, out int locationId))
            {
                throw new FormatException("[!] Input for location ID is not an integer");
            }

            if (LocationData.GetLocationWithId(locationId) is null)
            {
                throw new BusinessLocationException($"[!] Location {locationId} does not exist");
            }

            ICollection<BusinessOrder> ordersWithLocation = OrderData.GetOrdersWithLocationId(locationId);
            Console.WriteLine($"[*] There are {ordersWithLocation.Count} orders for location {locationId}");
            ordersWithLocation.ToList().ForEach(o => Console.WriteLine(o));
            Console.WriteLine();
        }

        private static void HandleRequestDisplayOrderHistoryOfCustomer()
        {
            Console.WriteLine("[?] What is the customer ID");
            string inputCustomerId = Console.ReadLine();
            if (!Int32.TryParse(inputCustomerId, out int customerId))
            {
                throw new FormatException("[!] Input for customer ID is not an integer");
            }

            if (CustomerData.GetCustomerWithId(customerId) is null)
            {
                throw new BusinessCustomerException($"[!] Customer {customerId} does not exist");
            }

            ICollection<BusinessOrder> ordersWithCustomer = OrderData.GetOrdersWithCustomerId(customerId);
            Console.WriteLine($"[*] There are {ordersWithCustomer.Count} orders for customer {customerId}");
            ordersWithCustomer.ToList().ForEach(o => Console.WriteLine(o));
            Console.WriteLine();
        }

        private static void HandleRequestDisplayAllLocations()
        {
            ICollection<BusinessLocation> locations = LocationData.GetLocations();
            Console.WriteLine($"[*] There are {locations.Count} locations");
            locations.ToList().ForEach(l =>
            {
                Console.WriteLine(l);
                Console.WriteLine(l.ToStringInventory());
            });
            Console.WriteLine();
        }

        private static void HandleRequestExit()
        {
            Console.WriteLine("[*] Bye!\n");
            Environment.Exit(0);
        }

        private static void HandleRequestInvalid()
        {
            Console.WriteLine("[!] Invalid input\n");
        }
    }
}
