
namespace SlotMachine
{
    internal class Program
    {
        const int ROW_COUNT = 3;
        const int COLUMN_COUNT = 3;
        const int MIN_NUMBER = 1;
        const int MAX_NUMBER = 9;

        static void Main(string[] args)
        {
            char playAgain = 'Y';
            Random random = new();

            Console.WriteLine("\t\tWelcome to the Slot Machine");
            Console.WriteLine("\tFor each winning line you need to increase your bet by 5$ !!");
            Console.WriteLine("\tOnly vertical lines - 5$ bet");
            Console.WriteLine("\tHorizontal and vertical lines - 10$ bet");
            Console.WriteLine("\tHorizontal, vertical and diagonaly lines - 15$ bet");

            while (playAgain == 'Y')
            {
                int[,] grid = new int[ROW_COUNT, COLUMN_COUNT];
                int playerMoney = 0;
                int wager;
                string input;
                bool winningLine = false;
                bool validInput = false;

                while (!validInput)
                {
                    Console.Write("How much $ would you like to add? : ");
                    validInput = int.TryParse(Console.ReadLine(), out playerMoney);

                   if (!validInput)
                    {
                        Console.WriteLine("Please enter a valid digit!");
                    }
                }

                while (playerMoney > 0)
                {
                    int winAmount = 0;

                    Console.WriteLine($"Your current money: {playerMoney} $");
                    Console.Write("Enter your wager amount: ");

                    validInput = int.TryParse(Console.ReadLine(), out wager);
                    if (!validInput)
                    {
                        Console.WriteLine("Please enter a valid wager amount!");
                        continue;
                    }

                    if (wager > playerMoney)
                    {
                        Console.WriteLine("You don't have enough money to place that wager!");
                        continue;
                    }

                    playerMoney -= wager;

                    // Generate and display the grid
                    for (int i = 0; i < COLUMN_COUNT; i++)
                    {
                        for (int j = 0; j < ROW_COUNT; j++)
                        {
                            grid[i, j] = random.Next(MIN_NUMBER, MAX_NUMBER);
                            Console.Write(grid[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    if (wager >= 5)
                    {
                        // Check horizontal lines
                        for (int row = 0; row < ROW_COUNT; row++)
                        {
                            winningLine = false;
                            for (int col = 0; col < COLUMN_COUNT - 1; col++)
                            {
                                if (grid[row, col] != grid[row, col + 1])
                                {
                                    winningLine = true;
                                    break;
                                }
                            }
                            if (!winningLine)
                            {
                                winAmount += wager;
                            }
                        }
                    }

                    if (wager >= 10)
                    {
                        // Check vertical lines
                        for (int col = 0; col < COLUMN_COUNT; col++)
                        {
                            winningLine = false;
                            for (int row = 0; row < ROW_COUNT - 1; row++)
                            {
                                if (grid[row, col] != grid[row + 1, col])
                                {
                                    winningLine = true;
                                    break;
                                }
                            }
                            if (!winningLine)
                            {
                                winAmount += wager;
                            }
                        }
                    }
                    if (wager >= 15)
                    {
                        // Check diagonal from top-left to bottom-right
                        for (int i = 0; i < 2; i++)
                        {
                            if (grid[i, i] != grid[i + 1, i + 1])
                            {
                                winningLine = true;
                                break;
                            }

                        }
                        if (!winningLine)
                        {
                            winAmount += wager;
                        }
                        // Check diagonal from top-right to bottom-left
                        for (int i = 0; i < 2; i++)
                        {
                            if (grid[i, 2 - i] != grid[i + 1, 1 - i])
                            {
                                winningLine = true;
                                break;
                            }
                        }
                        if (!winningLine)
                        {
                            winAmount += wager;
                        }
                    }

                    playerMoney += winAmount;

                    if (winAmount > 0)
                    {
                        Console.WriteLine($"Congratulations! You have won ${winAmount}. Your new total is ${playerMoney}.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, try again.");
                    }

                    Console.WriteLine("Please enter 'E' to exit or 'Enter' to continue");
                    input = Console.ReadLine().ToUpper();

                    if (input == "E")
                    {
                        break;
                    }
                }
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("Press any key to EXIT or 'Y' to start again!");
                playAgain = Console.ReadKey().KeyChar;
                playAgain = char.ToUpper(playAgain);
                Console.WriteLine();
            }
        }
    }
}
