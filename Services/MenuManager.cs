namespace W7_assignment_template.Services
{
    public class MenuManager
    {
        public bool ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to the RPG Game!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Exit");
            Console.ResetColor();

            return HandleMainMenuInput();
        }

        private bool HandleMainMenuInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Starting game...");
                        Console.ResetColor();
                        return true;  // Indicate to start the game
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Exiting game...");
                        Console.ResetColor();
                        Environment.Exit(0);
                        return false;  // This line will never be reached, but it's here for completeness
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid selection. Please choose 1 or 2.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
