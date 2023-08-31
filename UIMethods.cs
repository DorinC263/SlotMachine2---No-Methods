namespace SlotMachine2
{
    public static class UIMethods
    {
        /// <summary>
        /// Display the welcome message
        /// </summary>
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("\t\tWelcome to the Slot Machine");
            Console.WriteLine("\tFor each winning line you need to increase your bet by 1$ !!");
            Console.WriteLine("\tYou can play all 8 lines with a min bet of 8$.");
            Console.WriteLine("\t For ex: 1$ is one horizontal line");
            Console.WriteLine("\t         2$ is 2 horizontal lines");
            Console.WriteLine("\t         3$ is 3 horizontal lines");
        }

        /// <summary>
        /// Shows how much money he added
        /// </summary>
        /// <param name="playerMoney">how much money the user added and how much he wants to wage</param>
        public static void DisplayCurrentMoney(int playerMoney)
        {
            Console.WriteLine($"Your current money: {playerMoney} $");
            Console.Write("Enter your wager amount: ");
        }

        public static void DisplayNotEnoughMoney()
        {
            Console.WriteLine("You don't have enough money to place that wager!");
        }

        public static void DisplayWonAmount(int winAmount, int playerMoney)
        {
            Console.WriteLine($"Congratulations! You have won ${winAmount}. Your new total is ${playerMoney}.");
        }

        public static void DisplayNotWinning()
        {
            Console.WriteLine("Sorry, try again.");
        }

        public static void ThankYouForPlaying()
        {
            Console.WriteLine("Thank you for chossing to Play the SlotMachine!");
        }
        /// <summary>
        /// Display the grid
        /// </summary>
        /// <param name="grid"></param>
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

        /// <summary>
        /// User input Continue or exit
        /// </summary>
        /// <returns>After each round, the user has the option to exit or continue the game</returns>
        public static bool DisplayIfExitProgram()
        {
            Console.WriteLine("Please enter 'E' to exit or 'Enter' to continue");
            string userInput = Console.ReadLine().ToUpper();
            if (userInput == "E")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// User Input for Play Again
        /// </summary>
        /// <returns>User input after the game finish, if he wants to Play Again or exit the game completely</returns>
        public static bool DisplayCheckOnPlayAgain()
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

        public static int DisplayAddMoneyAmount()
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
        /// <summary>
        /// User input on how much he want to wager
        /// </summary>
        /// <returns>If the wager is not a digit, it loops until he adds a digit</returns>
        public static int DisplayWagerAmount()
        {
            while (true)
            {
                string wagerString = Console.ReadLine();

                if (int.TryParse(wagerString, out int wager))
                {
                    if (wager > 0)
                    {
                        return wager;
                    }

                }
                Console.Write("Please enter a valid wager amount! : ");

            }
        }
    }
}