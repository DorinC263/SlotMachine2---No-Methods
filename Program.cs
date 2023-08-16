
namespace SlotMachine
{
    internal class Program
    {
        const int DEFAULT_CREDIT = 100;

        static void Main(string[] args)
        {
            char playAgain = 'Y';

            while (playAgain == 'Y')
            {
                Console.WriteLine("Welcome to the Slot Machine");

                int[,] grid = new int[3, 3];
                int playerMoney = DEFAULT_CREDIT;
                int wager;
                string input;
                Random random = new();
                bool fail = false;
                bool diagonal1 = false;
                bool diagonal2 = false;

                while (playerMoney > 0)
                {
                    int winAmount = 0;

                    Console.WriteLine($"Your current money: {playerMoney}");
                    Console.Write("Enter your wager amount: ");

                    if (!int.TryParse(Console.ReadLine(), out wager) || wager <= 0)
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

                    Console.WriteLine("Please enter 'E' to exit or 'Enter' to spin");
                    input = Console.ReadLine().ToLower();

                    if (input == "e")
                    {
                        break;
                    }

                    // Generate and display the grid
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            grid[i, j] = random.Next(1, 5);
                            Console.Write(grid[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    // Check horizontal lines
                    for (int row = 0; row < 3; row++)
                    {
                        fail = false;
                        for (int col = 0; col < 2; col++)
                        {
                            if (grid[row, col] != grid[row, col + 1])
                            {
                                fail = true;
                                break;
                            }
                        }
                        if (!fail)
                        {
                            winAmount += wager;
                        }
                    }

                    // Check vertical lines
                    for (int col = 0; col < 3; col++)
                    {
                        fail = false;
                        for (int row = 0; row < 2; row++)
                        {
                            if (grid[row, col] != grid[row + 1, col])
                            {
                                fail = true;
                                break;
                            }
                        }
                        if (!fail)
                        {
                            winAmount += wager;
                        }
                    }

                    // Check diagonal from top-left to bottom-right
                    for (int i = 0; i < 2; i++)
                    {
                        if (grid[i, i] != grid[i + 1, i + 1])
                        {
                            diagonal1 = true;
                            break;
                        }
                    }
                    if (!diagonal1)
                    {
                        winAmount += wager;
                    }

                    // Check diagonal from top-right to bottom-left
                    for (int i = 0; i < 2; i++)
                    {
                        if (grid[i, 2 - i] != grid[i + 1, 1 - i])
                        {
                            diagonal2 = true;
                            break;
                        }
                    }
                    if (!diagonal2)
                    {
                        winAmount += wager;
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
