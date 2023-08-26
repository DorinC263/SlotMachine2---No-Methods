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

        public static int CheckWinningLines(int[,] grid, int wager)
        {
            int winAmount = 0;

            if(wager >= VERTICAL_LINES)
            {
                winAmount += CheckVerticalLines(grid, wager);
            }
            
            if(wager >= HORIZONTAL_LINES)
            {
                winAmount += CheckHorizontalLines(grid, wager);
            }
            
            if(wager >= ALL_LINES)
            {
                winAmount += CheckDiagonalLines(grid, wager);
            }          

            return winAmount; 
        }

        public static int CheckVerticalLines(int[,] grid,int wager)
        {
            int winAmount = 0;
            // Check vertical lines
            for (int col = 0; col < COLUMN_COUNT; col++)
            {
                bool winningLine = true;
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
                    winAmount += wager; // Add wager to winAmount for each vertical line
                }
            }
            return winAmount;
        }

        public static int CheckHorizontalLines(int[,] grid, int wager)
        {
            int winAmount = 0;
            // Check horizontal lines
            for (int row = 0; row < ROW_COUNT; row++)
            {
                bool winningLine = true;
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
                    winAmount += wager; // Add wager to winAmount for each horizontal line
                }
            }
            return winAmount;
        }

        public static int CheckDiagonalLines(int[,]grid, int wager)
        {
            // Check diagonal lines
            bool winningLine = true;
            for (int i = 0; i < ROW_COUNT - 1; i++)
            {
                if (grid[i, i] != grid[i + 1, i + 1])
                {
                    winningLine = false;
                    break;
                }
            }
            if (winningLine)
            {
                return wager; // Add wager to winAmount for diagonal line
            }

            winningLine = true;
            for (int i = 0; i < ROW_COUNT - 1; i++)
            {
                if (grid[i, COLUMN_COUNT - 1 - i] != grid[i + 1, COLUMN_COUNT - 2 - i])
                {
                    winningLine = false;
                    break;
                }
            }
            if (winningLine)
            {
                return wager; // Add wager to winAmount for diagonal line
            }
            return 0;
        }
    }
}
