using static SlotMachine2.Constants;

namespace SlotMachine2
{
    public static class LogicMethods
    {   
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

            if(wager >= VERTICAL_LINES)
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
                        winAmount += wager; // Add wager to winAmount for each vertical line
                    }
                }
            }
            
            if(wager >= HORIZONTAL_LINES)
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
                        winAmount += wager; // Add wager to winAmount for each horizontal line
                    }
                }
            }
            
            if(wager >= ALL_LINES)
            {
                // Check diagonal lines
                winningLine = false;
                for (int i = 0; i < ROW_COUNT - 1; i++)
                {
                    if (grid[i, i] != grid[i + 1, i + 1])
                    {
                        winningLine = true;
                        break;
                    }
                }
                if (!winningLine)
                {
                    winAmount += wager; // Add wager to winAmount for diagonal line
                }

                winningLine = false;
                for (int i = 0; i < ROW_COUNT - 1; i++)
                {
                    if (grid[i, COLUMN_COUNT - 1 - i] != grid[i + 1, COLUMN_COUNT - 2 - i])
                    {
                        winningLine = true;
                        break;
                    }
                }
                if (!winningLine)
                {
                    winAmount += wager; // Add wager to winAmount for diagonal line
                }
            }          

            return winAmount > 0; // Return true if winAmount is greater than 0
        }
    }
}
