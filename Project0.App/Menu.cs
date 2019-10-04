using System;

namespace Project0.App
{
    class Menu
    {
        internal static void DisplayMenu()
        {
            Console.WriteLine("Welcome to Javon's Tea Store");
            Console.WriteLine("Options");
            Console.WriteLine("0] Add a new customer");
            Console.WriteLine("1] Search for a customer");
            Console.WriteLine("2] Display details of an order");
            Console.WriteLine("3] Display order history of a location");
            Console.WriteLine("4] Display order history of a customer");
            Console.WriteLine("5] Exit");
            Console.WriteLine("What would you like to do?: ");
        }

        internal static Request PromptUser()
        {
            string input = Console.ReadLine();
            int inp = Int32.Parse(input);

            return (Request)inp;
        }

        internal static void HandleRequest(Request req)
        {
            if (req.Equals(Request.AddCustomer))
            {
                Console.WriteLine("What would the name of the customer be?: ");
                string customerName = Console.ReadLine();
                Console.WriteLine($"We have added a customer of id 1 with name {customerName}");
            }
            else if (req.Equals(Request.SearchCustomer))
            {
                Console.WriteLine("What is the name of the customer you are searching for?");
            }
            else if (req.Equals(Request.DisplayDetailsOfOrder))
            {
                Console.WriteLine("What is the order ID?: ");
                string orderId = Console.ReadLine();
                Console.WriteLine($"Searching for order {orderId}");
            }
            else if (req.Equals(Request.DisplayOrderHistoryOfLocation))
            {
                Console.WriteLine("What is the location ID?");
                string locationId = Console.ReadLine();
                Console.WriteLine($"Searching for order history of location {locationId}");
            }
            else if (req.Equals(Request.DisplayOrderHistoryOfCustomer))
            {
                Console.WriteLine("What is the customer ID?");
                string customerId = Console.ReadLine();
                Console.WriteLine($"Searching for order history of customer {customerId}");
            }
            else if (req.Equals(Request.Exit))
            {
                Console.WriteLine("Bye!");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
