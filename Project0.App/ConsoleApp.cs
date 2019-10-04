using System;

namespace Project0.App
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Javon's Tea Store");
            Console.WriteLine("Options");
            Console.WriteLine("1] Add a new customer");
            Console.WriteLine("2] Search for a customer");
            Console.WriteLine("3] Display details of an order");
            Console.WriteLine("4] Display order history of a location");
            Console.WriteLine("What would you like to do?: ");
            string input = Console.ReadLine();
            if (input.Equals("1"))
            {
                Console.WriteLine("What would the name of the customer be?: ");
                string customerName = Console.ReadLine();
                Console.WriteLine($"We have added a customer of id 1 with name {customerName}");
            }
            else if (input.Equals("2"))
            {
                Console.WriteLine("What is the name of the customer you are searching for?");
            }
            else if (input.Equals("3"))
            {
                Console.WriteLine("What is the order ID?: ");
                string orderId = Console.ReadLine();
                Console.WriteLine($"Searching for order {orderId}");
            }
            else if (input.Equals("4"))
            {
                Console.WriteLine("What is the location ID?");
                string locationId = Console.ReadLine();
                Console.WriteLine($"Searching for order history of location {locationId}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
