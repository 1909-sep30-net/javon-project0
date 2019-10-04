using System;

namespace Project0.App
{
    class Console
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to Javon's Tea Store");
            System.Console.WriteLine("Options");
            System.Console.WriteLine("1] Add a new customer");
            System.Console.WriteLine("What would you like to do?: ");
            string input = System.Console.ReadLine();
            if (input.Equals("1"))
            {
                System.Console.WriteLine("You would like to add a customer! No problem!");
                System.Console.WriteLine("What would the name of the customer be?: ");
                string customerName = System.Console.ReadLine();
                System.Console.WriteLine($"You would like to add customer called {customerName}");
            }
            else
            {
                System.Console.WriteLine("Invalid input");
            }
        }
    }
}
