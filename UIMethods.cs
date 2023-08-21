using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine2
{
    public static class UIMethods
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("\t\tWelcome to the Slot Machine");
            Console.WriteLine("\tFor each winning line you need to increase your bet by 5$ !!");
            Console.WriteLine("\tOnly vertical lines - 5$ bet");
            Console.WriteLine("\tHorizontal and vertical lines - 10$ bet");
            Console.WriteLine("\tHorizontal, vertical and diagonaly lines - 15$ bet");
        }

        public static void AddMoney()
        {
            Console.Write("How much $ would you like to add? : ");
        }

        public static void NotValidDigit()
        {
            Console.WriteLine("Please enter a valid digit!");
        }

        public static void CurentMoney(int playerMoney)
        {
            Console.WriteLine($"Your current money: {playerMoney} $");
            Console.Write("Enter your wager amount: ");
        }

        public static void WageAmount()
        {
            Console.WriteLine("Please enter a valid wager amount!");
        }

        public static void NotEnoughMoney()
        {
            Console.WriteLine("You don't have enough money to place that wager!");
        }

        public static void WonAmount(int winAmount, int playerMoney)
        {
            Console.WriteLine($"Congratulations! You have won ${winAmount}. Your new total is ${playerMoney}.");
        }

        public static void NotWinning()
        {
            Console.WriteLine("Sorry, try again.");
        }

        public static bool ContinueOrExit()
        {
            Console.WriteLine("Please enter 'E' to exit or 'Enter' to continue");
            string userInput = Console.ReadLine().ToLower();
            if (userInput.ToLower() == "e")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool PlayAgain()
        {
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("Press any key to EXIT or 'Y' to start again!");
            string exitOrStartAgain = Console.ReadLine().ToLower();
            if (exitOrStartAgain.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
