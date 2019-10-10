using Project0.Data;
using Project0.Logic;
using System;
using System.Collections.Generic;

namespace Project0.App
{
    class MenuHandler
    {
        internal static void HandleRequest(MenuRequest req)
        {
            if (req.Equals(MenuRequest.AddCustomer)) HandleRequestAddCustomer();
            else if (req.Equals(MenuRequest.SearchCustomer)) HandleRequestSearchCustomer();
            else if (req.Equals(MenuRequest.DisplayDetailsOfOrder)) HandleRequestDisplayDetailsOfOrder();
            else if (req.Equals(MenuRequest.DisplayOrderHistoryOfLocation)) HandleRequestDisplayOrderHistoryOfLocation();
            else if (req.Equals(MenuRequest.DisplayOrderHistoryOfCustomer)) HandleRequestDisplayOrderHistoryOfCustomer();
            else if (req.Equals(MenuRequest.DisplayAllLocations)) HandleRequestDisplayAllLocations();
            else if (req.Equals(MenuRequest.Exit)) HandleRequestExit();
            else HandleRequestInvalid();
        }

        private static void HandleRequestAddCustomer()
        {
            try
            {
                Customer cust = new Customer();

                Console.WriteLine("What is the first name of the customer?");
                string firstName = Console.ReadLine();
                cust.FirstName = firstName;

                Console.WriteLine("What is the last name of the customer?");
                string lastName = Console.ReadLine();
                cust.LastName = lastName;

                CustomerData.AddCustomer(cust);
                Console.WriteLine($"The customer {cust.FirstName} {cust.LastName} has been added");
            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void HandleRequestSearchCustomer()
        {
            try
            {
                Customer cust = new Customer();

                Console.WriteLine("What is the last name of the customer you are searching for?");
                string lastName = Console.ReadLine();
                cust.LastName = lastName;

                List<Customer> customersWithLastName = CustomerData.GetCustomersByLastName(cust);
                Console.WriteLine($"There are {customersWithLastName.Count} customers with last name \"{lastName}\"");
                foreach (Customer c in customersWithLastName)
                {
                    Console.WriteLine($"[{c.Id}] {c.FirstName} {c.LastName}");
                }
            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void HandleRequestDisplayDetailsOfOrder()
        {
            //Console.WriteLine("What is the order ID?: ");
            //string orderId = Console.ReadLine();
            //Console.WriteLine($"Searching for order {orderId}");
        }

        private static void HandleRequestDisplayOrderHistoryOfLocation()
        {
            //Console.WriteLine("What is the location ID?");
            //string locationId = Console.ReadLine();
            //Console.WriteLine($"Searching for order history of location {locationId}");
        }

        private static void HandleRequestDisplayOrderHistoryOfCustomer()
        {
            //Console.WriteLine("What is the customer ID?");
            //string customerId = Console.ReadLine();
            //Console.WriteLine($"Searching for order history of customer {customerId}");
        }

        private static void HandleRequestDisplayAllLocations()
        {
            List<Location> locations = LocationData.GetLocations();
            Console.WriteLine("Locations:");
            foreach (Location loc in locations)
            {
                Console.WriteLine(loc);
            }
        }

        private static void HandleRequestExit()
        {
            Console.WriteLine("Bye!");
            Environment.Exit(0);
        }

        private static void HandleRequestInvalid()
        {
            Console.WriteLine("Invalid input");
        }
    }
}
