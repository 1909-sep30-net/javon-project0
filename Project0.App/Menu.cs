using System;

namespace Project0.App
{
    internal class Menu
    {
        internal static void DisplayMenu()
        {
            Console.WriteLine("[*] Welcome to Javon's Tea Store");
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
            int inp = 1000;
            try
            {
                string input = Console.ReadLine();
                inp = Int32.Parse(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (MenuRequest)inp;
        }
    }
}
