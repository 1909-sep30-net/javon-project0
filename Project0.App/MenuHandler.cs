using Project0.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.App
{
    class MenuHandler
    {
        internal static void HandleRequest(Request req)
        {
            if (req.Equals(Request.AddCustomer)) HandleRequestAddCustomer();
            else if (req.Equals(Request.SearchCustomer)) HandleRequestSearchCustomer();
            else if (req.Equals(Request.DisplayDetailsOfOrder)) HandleRequestDisplayDetailsOfOrder();
            else if (req.Equals(Request.DisplayOrderHistoryOfLocation)) HandleRequestDisplayOrderHistoryOfLocation();
            else if (req.Equals(Request.DisplayOrderHistoryOfCustomer)) HandleRequestDisplayOrderHistoryOfCustomer();
            else if (req.Equals(Request.Exit)) HandleRequestExit();
            else HandleRequestInvalid();
        }

        private static void HandleRequestAddCustomer()
        {
            Console.WriteLine("What would the first name of the customer be?: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("What would the last name of the customer be?: ");
            string lastName = Console.ReadLine();

            CustomerAccess.AddCustomer(firstName, lastName);

            Console.WriteLine($"We have added a customer with name {firstName} {lastName}");
        }

        private static void HandleRequestSearchCustomer()
        {
            Console.WriteLine("What is the name of the customer you are searching for?");
        }

        private static void HandleRequestDisplayDetailsOfOrder()
        {
            Console.WriteLine("What is the order ID?: ");
            string orderId = Console.ReadLine();
            Console.WriteLine($"Searching for order {orderId}");
        }

        private static void HandleRequestDisplayOrderHistoryOfLocation()
        {
            Console.WriteLine("What is the location ID?");
            string locationId = Console.ReadLine();
            Console.WriteLine($"Searching for order history of location {locationId}");
        }

        private static void HandleRequestDisplayOrderHistoryOfCustomer()
        {
            Console.WriteLine("What is the customer ID?");
            string customerId = Console.ReadLine();
            Console.WriteLine($"Searching for order history of customer {customerId}");
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
