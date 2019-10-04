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
            Console.WriteLine("What would you like to do?: ");
            string input = Console.ReadLine();
            if (input.Equals("1"))
            {
                Console.WriteLine("What would the name of the customer be?: ");
                string customerName = Console.ReadLine();
                Console.WriteLine($"We have added a customer of id 1 with name {customerName}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
