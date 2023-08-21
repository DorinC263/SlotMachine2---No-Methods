
using SlotMachine2;

namespace SlotMachine
{
    internal class Program
    {
        const int ROW_COUNT = 3;
        const int COLUMN_COUNT = 3;
        const int MIN_NUMBER = 1;
        const int MAX_NUMBER = 9;
        const int VERTICAL_LINES = 5;
        const int HORIZONTAL_LINES = 10;
        const int ALL_LINES = 15;

        static void Main(string[] args)
        {
            char playAgain = 'Y';
            Random random = new Random();

            UIMethods.DisplayWelcomeMessage();

            while (playAgain == 'Y')
            {
                int[,] grid = new int[ROW_COUNT, COLUMN_COUNT];
                int playerMoney = 0;
                int wager;
                string input;
                bool winningLine;
                bool validInput = false;

                while (!validInput)
                {
                    UIMethods.AddMoney();
                    validInput = int.TryParse(Console.ReadLine(), out playerMoney);

                    if (!validInput)
                    {
                        UIMethods.NotValidDigit();
                    }
                }

                while (playerMoney > 0)
                {
                    int winAmount = 0;

                    UIMethods.CurentMoney(playerMoney);

                    validInput = int.TryParse(Console.ReadLine(), out wager);
                    if (!validInput)
                    {
                        UIMethods.WageAmount();
                        continue;
                    }

                    if (wager > playerMoney)
                    {
                        UIMethods.NotEnoughMoney();
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

                    if (wager >= VERTICAL_LINES)
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

                    if (wager >= HORIZONTAL_LINES)
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
                    if (wager >= ALL_LINES)
                    {
                        winningLine = false;
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
                        UIMethods.WonAmount(winAmount,playerMoney);
                    }
                    else
                    {
                        UIMethods.NotWinning();
                    }

                    UIMethods.ContinueOrExit();
                    
                }
                UIMethods.PlayAgain();
            }
        }
    }
}
