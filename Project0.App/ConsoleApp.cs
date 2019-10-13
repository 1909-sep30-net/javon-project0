namespace Project0.App
{
    internal class ConsoleApp
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Menu.DisplayMenu();
                MenuRequest req = Menu.PromptUser();
                MenuHandler.HandleRequest(req);
            }
        }
    }
}
