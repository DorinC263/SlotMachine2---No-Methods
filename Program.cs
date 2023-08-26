using SlotMachine2;

namespace SlotMachine
{
    internal class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            char playAgain = 'Y';            

            UIMethods.DisplayWelcomeMessage();

            while (playAgain == 'Y')
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
                        playerMoney -= winAmount;
                    }

                    bool stopPlay = UIMethods.ExitProgram();
                    if (stopPlay)
                    {
                        break;
                    }
                }
                bool exitOrPlay = UIMethods.CheckOnPlayAgain();
                if (exitOrPlay == false)
                {
                    break;
                }
            }
            UIMethods.ThankYouForPlaying();
        }
    }
}
