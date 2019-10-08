using System;

namespace Project0.App
{
    class Menu
    {
        internal static void DisplayMenu()
        {
            Console.WriteLine("Welcome to Javon's Tea Store");
            Console.WriteLine("0] Add a new customer");
            Console.WriteLine("1] Search for a customer");
            Console.WriteLine("2] Display details of an order");
            Console.WriteLine("3] Display order history of a location");
            Console.WriteLine("4] Display order history of a customer");
            Console.WriteLine("5] Exit");
            Console.WriteLine("What would you like to do?: ");
        }

        internal static MenuRequest PromptUser()
        {
            string input = Console.ReadLine();
            int inp = Int32.Parse(input);

            return (MenuRequest)inp;
        }
    }
}
