namespace SlotMachine2
{
    internal class Program
    {
        const bool V = false;
        const int DEFAULT_CREDIT = 100;

        static void Main(string[] args)
        {
            char playAgain = 'y';

            while (playAgain == 'Y' || playAgain == 'y')
            {
                Console.WriteLine("Welcome to the Slot Machine");

                int[,] grid = new int[5, 5];
                int playerMoney = DEFAULT_CREDIT;
                int wager;
                string input;
                int winAmount = 0;
                Random random = new();
                bool fail = V;
                bool diagonal1 = V;
                bool diagonal2 = V;

                while (playerMoney > 0)
                {
                    Console.WriteLine($"Your current money : {playerMoney}");
                    Console.WriteLine("Enter your wager amount : ");

                    if (!int.TryParse(Console.ReadLine(), out wager))
                    {
                        Console.WriteLine("Please enter only digits!");
                        continue;
                    }
                    if (wager > playerMoney)
                    {
                        Console.WriteLine("You don`t have enough money to place that wager!");
                    }

                    playerMoney -= wager;

                    Console.WriteLine("Please enter 'E' to exit or 'Enter' to spin");
                    input = Console.ReadLine().ToLower();

                    if (input == "e")
                    {
                        break;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            grid[i, j] = random.Next(1, 6);
                        }
                    }

                    Console.WriteLine("Slot machine results:");
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            Console.Write(grid[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    // check horizontal lines
                    for (int row = 0; row < 5; row++)
                    {
                        fail = false;
                        for (int col = 0; col < 4; col++)
                        {
                            if (grid[row, col] != grid[row, col + 1])
                            {
                                fail = true;
                            }
                        }
                        if (!fail)
                        {
                            winAmount += wager;
                        }
                    }

                    // check vertical lines
                    for (int col = 0; col < 5; col++)
                    {
                        for (int row = 0; row < 4; row++)
                        {
                            if (grid[row, col] != grid[row + 1, col])
                            {
                                fail = true;
                            }
                        }
                        if (!fail)
                        {
                            winAmount += wager;
                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (grid[i, i] != grid[i + 1, i + 1])
                        {
                            diagonal1 = true;
                        }

                    }
                    if (!diagonal1)
                    {
                        winAmount += wager;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (grid[i, 4 - i] != grid[i + 1, 3 - i])
                        {
                            diagonal2 = true;
                        }
                    }
                    if (!diagonal2)
                    {
                        winAmount += wager;
                    }


                    if (winAmount > 0)
                    {
                        Console.WriteLine($"Congratulation. You have won {winAmount}.Your new total is {playerMoney}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, try again.");
                    }

                }
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("Press any key to EXIT or 'Y to start again!'");
                playAgain = Console.ReadKey().KeyChar;
                playAgain = char.ToUpper(playAgain);

            }
        }
    }
}