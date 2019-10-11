namespace Project0.App
{
    class ConsoleApp
    {
        static void Main(string[] args)
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
