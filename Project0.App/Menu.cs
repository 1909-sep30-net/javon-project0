using System;
using Serilog;

namespace Project0.App
{
    /// <summary>
    /// Menu class is responsible for displaying console output and prompting and parsing of the user input.
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Display the menu options to standard out.
        /// </summary>
        internal static void DisplayMenu()
        {
            Log.Information("Displaying menu");
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

        /// <summary>
        /// Prompt the user for input for the menu options and parse it into a MenuRequest.
        /// </summary>
        /// <returns></returns>
        internal static MenuRequest PromptUser()
        {
            Log.Information("Prompting user");
            string input = Console.ReadLine();
            Log.Information($"User entered '{input}'");
            return (MenuRequest)Int32.Parse(input);
        }
    }
}
