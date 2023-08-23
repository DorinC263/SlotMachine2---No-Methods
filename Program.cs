
using SlotMachine2;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char playAgain = 'Y';
            Random random = new Random();

            UIMethods.DisplayWelcomeMessage();

            while (playAgain == 'Y')
            {
                int playerMoney = 0;
                int wager;
                bool validInput = false;

                while (!validInput)
                {
                    UIMethods.AddMoney();
                    validInput = int.TryParse(Console.ReadLine(), out playerMoney);

                    if (!validInput)
                    {
                        UIMethods.NotValidDigit();
                    }
                }

                while (playerMoney > 0)
                {
                    UIMethods.CurentMoney(playerMoney);

                    validInput = int.TryParse(Console.ReadLine(), out wager);
                    if (!validInput)
                    {
                        UIMethods.WageAmount();
                        continue;
                    }

                    if (wager > playerMoney)
                    {
                        UIMethods.NotEnoughMoney();
                        continue;
                    }

                    playerMoney -= wager;
                    int winAmount = 0;
                    int[,] grid = LogicMethods.GenerateGrid(random);

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
