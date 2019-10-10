using System;

namespace Project0.App
{
    class Menu
    {
        internal static void DisplayMenu()
        {
            Console.WriteLine("[*] Welcome to Javon's Tea Store");
            Console.WriteLine("[0] Add a new customer");
            Console.WriteLine("[1] Search for a customer");
            Console.WriteLine("[2] Display details of an order");
            Console.WriteLine("[3] Display order history of a location");
            Console.WriteLine("[4] Display order history of a customer");
            Console.WriteLine("[5] Display all locations");
            Console.WriteLine("[6] Exit");
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
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("[!] Null argument");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("[!] Wrong format - input needs to be an integer");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("[!] Overflow - input should not be out of an integer range");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (MenuRequest)inp;
        }
    }
}
