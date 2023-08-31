using SlotMachine2;

namespace SlotMachine
{
    internal class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            UIMethods.DisplayWelcomeMessage();

            while (true)
            {
                int playerMoney;
                int wager;

                playerMoney = UIMethods.DisplayAddMoneyAmount(); 

                while (playerMoney > 0)
                {
                    UIMethods.DisplayCurrentMoney(playerMoney);

                    wager = UIMethods.DisplayWagerAmount();
                                        
                    if (wager > playerMoney)
                    {
                        UIMethods.DisplayNotEnoughMoney();
                        continue;
                    }

                    playerMoney -= wager;
                    int[,] grid = LogicMethods.GenerateGrid(random);
                    UIMethods.DisplayGrid(grid);
                    int winAmount = LogicMethods.CheckWinningLines(grid, wager);

                    if (winAmount > 0)
                    {
                        playerMoney += winAmount;
                        UIMethods.DisplayWonAmount(winAmount, playerMoney);
                    }
                    else
                    {
                        UIMethods.DisplayNotWinning();
                    }

                    bool stopPlay = UIMethods.DisplayIfExitProgram();
                    if (stopPlay)
                    {
                        break;
                    }
                }
                bool newGame = UIMethods.DisplayCheckOnPlayAgain();
                if (newGame == false)
                {
                    break;
                }
            }
            UIMethods.ThankYouForPlaying();
        }
    }
}
