using System;

namespace Project0.App
{
    internal class ConsoleApp
    {
        private static void Main(string[] args)
        {
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
