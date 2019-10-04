using System;

namespace Project0.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Javon's Tea Store");
            Console.WriteLine("Options");
            Console.WriteLine("1] Add a new customer");
            Console.WriteLine("What would you like to do?: ");
            string input = Console.ReadLine();
            if (input.Equals("1"))
            {
                Console.WriteLine("Valid input");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
