using static SlotMachine2.Constants;

namespace SlotMachine2
{

    public static class LogicMethods
    {
        public static Random random = new Random();

        /// <summary>
        /// Generate Grid
        /// </summary>
        /// <param name="random">A 2D array representing the generated grid.</param>
        /// <returns></returns>
        public static int[,] GenerateGrid()
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

        /// <summary>
        ///Checks Winning lines
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="wager">If the symbols are the same, it returns winAmount</param>
        /// <returns></returns>
        public static int CheckWinningLines(int[,] grid, int wager)
        {
            int winAmount = 0;

            if (wager >= VERTICAL_LINES)
            {
                winAmount += CheckVerticalLines(grid, wager);
            }

            if (wager >= HORIZONTAL_LINES)
            {
                winAmount += CheckHorizontalLines(grid, wager);
            }

            if (wager >= ALL_LINES)
            {
                winAmount += CheckDiagonalLines(grid, wager);
            }

            return winAmount;
        }

        /// <summary>
        /// Check Vertical Lines
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="wager">It checks vertical lines for the same symbol, if returns true, the winAmount is added</param>
        /// <returns></returns>
        public static int CheckVerticalLines(int[,] grid, int wager)
        {
            int winAmount = 0;
            int linesToCheck = Math.Min(wager, 3);   

            // Check vertical lines
            for (int col = 0; col < linesToCheck; col++)
            {
                bool winningLine = true;
                for (int row = 0; row < MAX_ROW_COUNT; row++)
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

        /// <summary>
        /// Check Horizontal lines for Win
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="wager">It checks horizontal lines for the same symbol</param>
        /// <returns></returns>
        public static int CheckHorizontalLines(int[,] grid, int wager)
        {
            int winAmount = 0;
            int linesToCheck = Math.Min(wager -3, 3);
            
            // Check horizontal lines
            for (int row = 0; row < linesToCheck; row++)
            {
                bool winningLine = true;
                for (int col = 0; col < MAX_COLUMN_COUNT; col++)
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

        /// <summary>
        /// It checks for diagonal lines
        /// </summary>
        /// <param name="grid">It checks for diagonal wins, both from top-right to bottom left, and from top-left to bottom right</param>
        /// <param name="wager"></param>
        /// <returns></returns>
        public static int CheckDiagonalLines(int[,] grid, int wager)
        {
            int winAmount = 0;
            int linesToCheck = (wager == 7) ? 1 : 2;

            // Check diagonal lines
            bool firstDiagonalWin = true;
            bool secondDiagonalWin = true;

            for (int i = 0; i < linesToCheck; i++)
            {
                if (grid[i, i] != grid[i + 1, i + 1])
                {
                    firstDiagonalWin = false;
                    break;
                }
            }
            // check second diagonal
            for (int i = 0; i < linesToCheck; i++)
            {
                if (grid[i, MAX_COLUMN_COUNT - i] != grid[i + 1, COLUMN_COUNT - 2 - i])
                {
                    secondDiagonalWin = false;
                    break;
                }
            }

            if (firstDiagonalWin || secondDiagonalWin)
            {
                return wager; // Add wager to winAmount for diagonal line
            }
            return winAmount;
        }
    }
}