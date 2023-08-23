using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine2
{
    public static class LogicMethods
    {        
        const int VERTICAL_LINES = 5;
        const int HORIZONTAL_LINES = 10;
        const int ALL_LINES = 15;
        const int ROW_COUNT = 3;
        const int COLUMN_COUNT = 3;
        const int MIN_NUMBER = 1;
        const int MAX_NUMBER = 9;

        public static int[,] GenerateGrid(Random random)
        {
            int[,] grid = new int[ROW_COUNT, COLUMN_COUNT];

            //Generate and display Grid
            for (int i = 0; i < COLUMN_COUNT; i++)
            {
                for (int j = 0; j < ROW_COUNT; j++)
                {
                    grid[i, j] = random.Next(MIN_NUMBER, MAX_NUMBER);
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
            return grid;
        }

        public static bool CheckWinningLines(int[,] grid, int wager, out int winAmount)
        {
            bool winningLine = false;
            winAmount = 0;

            if (wager >= VERTICAL_LINES)
            {
                // Check horizontal lines
                for (int row = 0; row < ROW_COUNT; row++)
                {
                    winningLine = true;
                    for (int col = 0; col < COLUMN_COUNT - 1; col++)
                    {
                        if (grid[row, col] != grid[row, col + 1])
                        {
                            winningLine = false;
                            break;
                        }
                    }
                    if (winningLine)
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
                    winningLine = true;
                    for (int row = 0; row < ROW_COUNT - 1; row++)
                    {
                        if (grid[row, col] != grid[row + 1, col])
                        {
                            winningLine = false;
                            break;
                        }
                    }
                    if (winningLine)
                    {
                        winAmount += wager;
                    }
                }
            }

            if (wager >= ALL_LINES)
            {
                winningLine = true;
                // Check diagonal from top-left to bottom-right
                for (int i = 0; i < 2; i++)
                {
                    if (grid[i, i] != grid[i + 1, i + 1])
                    {
                        winningLine = false;
                        break;
                    }

                }
                if (winningLine)
                {
                    winAmount += wager;
                }
                // Check diagonal from top-right to bottom-left
                for (int i = 0; i < 2; i++)
                {
                    if (grid[i, 2 - i] != grid[i + 1, 1 - i])
                    {
                        winningLine = false;
                        break;
                    }
                }
                if (winningLine)
                {
                    winAmount += wager;
                }
            }
            return winningLine;
        }

        
    }
}
