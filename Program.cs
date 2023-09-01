using SlotMachine2;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.DisplayWelcomeMessage();

            while (true)
            {
                int wager;

                int playerMoney = UIMethods.PromptAddMoneyAmount(); 

                while (playerMoney > 0)
                {
                    UIMethods.DisplayCurrentMoney(playerMoney);

                    wager = UIMethods.PromptWagerAmount();
                                        
                    if (wager > playerMoney)
                    {
                        UIMethods.DisplayNotEnoughMoney();
                        continue;
                    }

                    playerMoney -= wager;
                    int[,] grid = LogicMethods.GenerateGrid();
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

                    bool stopPlay = UIMethods.PromptIfExitProgram();
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
