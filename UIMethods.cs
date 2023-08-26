namespace SlotMachine2
{
    public static class UIMethods
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("\t\tWelcome to the Slot Machine");
            Console.WriteLine("\tFor each winning line you need to increase your bet by 5$ !!");
            Console.WriteLine($"\tOnly vertical lines - {Constants.VERTICAL_LINES}$ bet");
            Console.WriteLine($"\tHorizontal and vertical lines - {Constants.HORIZONTAL_LINES}$ bet");
            Console.WriteLine($"\tHorizontal, vertical and diagonaly lines - {Constants.ALL_LINES}$ bet");
        }
        
        public static void CurentMoney(int playerMoney)
        {
            Console.WriteLine($"Your current money: {playerMoney} $");
            Console.Write("Enter your wager amount: ");
        }

        public static void NotEnoughMoney()
        {
            Console.WriteLine("You don't have enough money to place that wager!");
        }

        public static void WonAmount(int winAmount, int playerMoney)
        {
            Console.WriteLine($"Congratulations! You have won ${winAmount}. Your new total is ${playerMoney}.");
        }

        public static void NotWinning()
        {
            Console.WriteLine("Sorry, try again.");
        }

        public static void ThankYouForPlaying()
        {
            Console.WriteLine("Thank you for chossing to Play the SlotMachine!");
        }

        public static void DisplayGrid(int[,] grid)
        {
            //Display the grid
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }                
        }

        public static bool ExitProgram()
        {
            Console.WriteLine("Please enter 'E' to exit or 'Enter' to continue");
            string userInput = Console.ReadLine().ToUpper();
            if (userInput == "E")
            {
                return true;
            }
            return false;
        }

        public static bool CheckOnPlayAgain()
        {
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("Press any key to EXIT or 'Y' to start again!");
            string exitOrStartAgain = Console.ReadLine().ToUpper();
            if (exitOrStartAgain == "Y")
            {
                return true;
            }
            return false;
        }

        public static int GetMoneyAmount()
        {
            while (true)
            {
                Console.Write("How much $ would you like to add? : ");

                string valueString = Console.ReadLine();
                                
                if (int.TryParse(valueString, out int value))
                {
                    return value;
                }
                Console.WriteLine("Please enter a valid Digit!");
            }            
        }
        public static int GetWagerAmount()
        {
            while(true)
            {
                string wagerString = Console.ReadLine();

                if (int.TryParse(wagerString, out int wager))
                {
                    return wager;
                }                
                Console.Write("Please enter a valid wager amount! : ");
            }            
        }
    }
}