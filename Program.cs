using static SlotMachine2.Constants;
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
                    int winAmount = 0;
                    int[,] grid = LogicMethods.GenerateGrid(random);
                    UIMethods.DisplayGrid(grid);
                    bool hasWon = LogicMethods.CheckWinningLines(grid, wager, out winAmount);

                    if (hasWon)
                    {
                        playerMoney += winAmount;
                        UIMethods.WonAmount(winAmount, playerMoney);
                    }

                    else
                    {
                        UIMethods.NotWinning();
                        playerMoney -= winAmount;
                    }

                    bool continuePlay = UIMethods.ContinueOrExit();
                    if (continuePlay)
                    {
                        break;
                    }
                }
                bool exitOrPlay = UIMethods.PlayAgain();
                if (exitOrPlay == false)
                {
                    break;
                }
            }
            UIMethods.ThankYouForPlaying();
        }
    }
}
