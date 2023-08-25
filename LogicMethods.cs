using static SlotMachine2.Constants;

namespace SlotMachine2
{
    public static class LogicMethods
    {   
        public static int[,] GenerateGrid(Random random)
        {
            int[,] grid = new int[ROW_COUNT, COLUMN_COUNT];

            //Generate the Grid
            for (int i = 0; i < COLUMN_COUNT; i++)
            {
                for (int j = 0; j < ROW_COUNT; j++)
                {
                    grid[i, j] = random.Next(MIN_NUMBER, MAX_NUMBER);
                }
            }
            return grid;
        }

        public static bool CheckWinningLines(int[,] grid, int wager, out int winAmount)
        {
            winAmount = 0;

            if(wager >= VERTICAL_LINES)
            {
                CheckVerticalLines(grid, wager, ref winAmount);
            }
            
            if(wager >= HORIZONTAL_LINES)
            {
                CheckHorizontalLines(grid, wager, ref winAmount);
            }
            
            if(wager >= ALL_LINES)
            {
                CheckDiagonalLines(grid, wager, ref winAmount);
            }          

            return winAmount > 0; // Return true if winAmount is greater than 0
        }

        public static void CheckVerticalLines(int[,] grid,int wager,ref int winAmount)
        {
            // Check vertical lines
            for (int col = 0; col < COLUMN_COUNT; col++)
            {
                bool winningLine = false;
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

        public static void CheckHorizontalLines(int[,] grid, int wager,ref int winAmount)
        {
            // Check horizontal lines
            for (int row = 0; row < ROW_COUNT; row++)
            {
                bool winningLine = false;
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

        public static void CheckDiagonalLines(int[,]grid, int wager,ref int winAmount)
        {
            // Check diagonal lines
            bool winningLine = false;
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
    }
}
