using Project0.BusinessLogic;
using Project0.DataAccess;
using System;
using System.Collections.Generic;

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
            try
            {
                int customerId;
                int locationId;
                int dummy;
                int line = 0;
                Dictionary<int, int> lineItemsParsed = new Dictionary<int, int>();
                Dictionary<BusinessProduct, int> lineItems = new Dictionary<BusinessProduct, int>();

                Console.WriteLine("[?] What is the customer ID");
                string inputCustomerId = Console.ReadLine();
                if (!Int32.TryParse(inputCustomerId, out customerId))
                {
                    throw new FormatException($"[!] Input for customer ID is not an integer\n");
                }

                Console.WriteLine("[?] What is the location ID");
                string inputLocationId = Console.ReadLine();
                if (!Int32.TryParse(inputLocationId, out locationId))
                {
                    throw new FormatException($"[!] Input for location ID is not an integer\n");
                }

                while (++line > 0)
                {
                    int productId;
                    int quantity;

                    Console.WriteLine($"[?] Line {line} - Enter product ID or press enter to finish your order");
                    string inputProductId = Console.ReadLine();
                    if (inputProductId == "")
                    {
                        break;
                    }
                    if (!Int32.TryParse(inputProductId, out productId))
                    {
                        throw new FormatException($"[!] Input for product ID is not an integer\n");
                    }

                    Console.WriteLine($"[?] Line {line} - Enter quantity");
                    string inputQuantity = Console.ReadLine();
                    if (!Int32.TryParse(inputQuantity, out quantity))
                    {
                        throw new FormatException($"[!] Input for quantity is not an integer\n");
                    }

                    lineItemsParsed.Add(productId, quantity);
                }

                if (!CustomerData.CustomerExistsById(customerId))
                {
                    throw new BusinessCustomerException($"[!] Customer does not exist\n");
                }

                if (!LocationData.LocationExistsById(locationId))
                {
                    throw new BusinessLocationException($"[!] Location does not exist\n");
                }

                foreach (KeyValuePair<int, int> lineItem in lineItemsParsed)
                {
                    if (!ProductData.ProductExistsById(lineItem.Key))
                    {
                        throw new BusinessProductException($"[!] Product {lineItem.Key} does not exist\n");
                    }
                }

                BusinessCustomer bCustomer = CustomerData.GetCustomerById(customerId);
                BusinessLocation bLocation = LocationData.GetLocationById(locationId);

                BusinessOrder bOrder = new BusinessOrder()
                {
                    StoreLocation = bLocation,
                    Customer = bCustomer,
                    OrderTime = DateTime.Now,
                };
                foreach (KeyValuePair<BusinessProduct, int> lineItem in lineItems)
                {
                    bOrder.AddLineItem(lineItem.Key, lineItem.Value);
                }
                OrderData.CreateOrder(bOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n");
            }
        }

        private static void HandleRequestAddCustomer()
        {
            try
            {
                BusinessCustomer cust = new BusinessCustomer();

                Console.WriteLine("[?] What is the first name of the customer");
                string firstName = Console.ReadLine();
                cust.FirstName = firstName;

                Console.WriteLine("[?] What is the last name of the customer");
                string lastName = Console.ReadLine();
                cust.LastName = lastName;

                CustomerData.AddCustomer(cust);
                Console.WriteLine($"[+] The customer {cust.FirstName} {cust.LastName} has been added\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n");
            }
        }

        private static void HandleRequestSearchCustomer()
        {
            try
            {
                BusinessCustomer cust = new BusinessCustomer();

                Console.WriteLine("[?] What is the last name of the customer you are searching for");
                string lastName = Console.ReadLine();
                cust.LastName = lastName;

                ICollection<BusinessCustomer> customersWithLastName = CustomerData.GetCustomersByLastName(cust);
                Console.WriteLine($"[*] There are {customersWithLastName.Count} customers with the last name \"{lastName}\"");
                foreach (BusinessCustomer c in customersWithLastName)
                {
                    Console.WriteLine(c);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void HandleRequestDisplayDetailsOfOrder()
        {
            Console.WriteLine("[?] What is the order ID");
            string inputOrderId = Console.ReadLine();
            int orderId;
            if (Int32.TryParse(inputOrderId, out orderId))
            {
                BusinessOrder order = OrderData.GetOrderById(orderId);
                if (order != null)
                {
                    Console.WriteLine(order);
                }
                else
                {
                    Console.WriteLine("[!] Order does not exist in the database\n");
                }
            }
            else
            {
                Console.WriteLine("[!] Input for order ID is not an integer\n");
            }
        }

        private static void HandleRequestDisplayOrderHistoryOfLocation()
        {
            Console.WriteLine("[?] What is the location ID");
            string locationId = Console.ReadLine();
            int lId;
            if (Int32.TryParse(locationId, out lId))
            {
                if (LocationData.LocationExistsById(lId))
                {
                    ICollection<BusinessOrder> ordersWithLocation = OrderData.GetOrdersByLocationId(lId);
                    Console.WriteLine($"[*] There are {ordersWithLocation.Count} orders for location {lId}");
                    foreach (BusinessOrder o in ordersWithLocation)
                    {
                        Console.WriteLine(o);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"[!] Location {lId} does not exist\n");
                }
            }
            else
            {
                Console.WriteLine("[!] Input for location ID is not an integer\n");
            }
        }

        private static void HandleRequestDisplayOrderHistoryOfCustomer()
        {
            Console.WriteLine("[?] What is the customer ID");
            string customerId = Console.ReadLine();
            int cId;
            if (Int32.TryParse(customerId, out cId))
            {
                if (!(CustomerData.GetCustomerById(cId) is null))
                {
                    ICollection<BusinessOrder> ordersWithCustomer = OrderData.GetOrdersByCustomerId(cId);
                    Console.WriteLine($"[*] There are {ordersWithCustomer.Count} orders for customer {cId}");
                    foreach (BusinessOrder o in ordersWithCustomer)
                    {
                        Console.WriteLine(o);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"[!] Customer {cId} does not exist\n");
                }
            }
            else
            {
                Console.WriteLine("[!] Input for customer ID is not an integer\n");
            }
        }

        private static void HandleRequestDisplayAllLocations()
        {
            ICollection<BusinessLocation> locations = LocationData.GetLocations();
            Console.WriteLine($"[*] There are {locations.Count} locations");
            foreach (BusinessLocation loc in locations)
            {
                Console.WriteLine(loc);
            }
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
