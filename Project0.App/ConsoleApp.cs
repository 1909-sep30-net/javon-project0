namespace Project0.App
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Menu.DisplayMenu();
                Request req = Menu.PromptUser();
                Menu.HandleRequest(req);
            }
        }
    }
}
