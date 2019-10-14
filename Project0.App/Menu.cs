using System;

namespace Project0.App
{
    internal class Menu
    {
        internal static void DisplayMenu()
        {
            Console.WriteLine("[*] Welcome to TThreeTeas");
            Console.WriteLine("[Menu]");
            Console.WriteLine("[0] Place order");
            Console.WriteLine("[1] Add a new customer");
            Console.WriteLine("[2] Search for a customer");
            Console.WriteLine("[3] Display details of an order");
            Console.WriteLine("[4] Display order history of a location");
            Console.WriteLine("[5] Display order history of a customer");
            Console.WriteLine("[6] Display all locations");
            Console.WriteLine("[7] Exit");
            Console.WriteLine("[?] What would you like to do");
        }

        internal static MenuRequest PromptUser()
        {
            string input = Console.ReadLine();
            return (MenuRequest)Int32.Parse(input);
        }
    }
}
