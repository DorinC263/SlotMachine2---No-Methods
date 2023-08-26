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

                playerMoney = UIMethods.GetMoneyAmount(); 

                while (playerMoney > 0)
                {
                    UIMethods.CurentMoney(playerMoney);

                    wager = UIMethods.GetWagerAmount();
                                        
                    if (wager > playerMoney)
                    {
                        UIMethods.NotEnoughMoney();
                        continue;
                    }

                    playerMoney -= wager;
                    int[,] grid = LogicMethods.GenerateGrid(random);
                    UIMethods.DisplayGrid(grid);
                    int winAmount = LogicMethods.CheckWinningLines(grid, wager);

                    if (winAmount > 0)
                    {
                        playerMoney += winAmount;
                        UIMethods.WonAmount(winAmount, playerMoney);
                    }
                    else
                    {
                        UIMethods.NotWinning();
                    }

                    bool stopPlay = UIMethods.ExitProgram();
                    if (stopPlay)
                    {
                        break;
                    }
                }
                bool newGame = UIMethods.CheckOnPlayAgain();
                if (newGame == false)
                {
                    break;
                }
            }
            UIMethods.ThankYouForPlaying();
        }
    }
}
