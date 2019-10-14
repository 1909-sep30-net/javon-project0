using System;
using Serilog;

namespace Project0.App
{
    internal class ConsoleApp
    {
        private const string logFile = @"C:\revature\javon-project0\Log.txt";

        /// <summary>
        /// Entry point to the ConsoleApp.
        /// </summary>
        /// <param name="args">Arguments to program running</param>
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(logFile).CreateLogger();
            while (true)
            {
                try
                {
                    Menu.DisplayMenu();
                    MenuRequest req = Menu.PromptUser();
                    MenuHandler.HandleRequest(req);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}\n");
                }
            }
        }
    }
}
