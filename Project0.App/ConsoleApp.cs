using System;
using Serilog;

namespace Project0.App
{
    internal class ConsoleApp
    {
        private const string logFile = @"C:\revature\javon-project0\Log.txt";

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
