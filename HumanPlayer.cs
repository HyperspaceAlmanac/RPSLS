using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class HumanPlayer : Player
    {
        public HumanPlayer(int playerNum) : base(playerNum)
        {
            // Nothing to do here for now
        }
        public override Gesture SelectGesture()
        {
            DisplayPlayer();
            DisplayOptions();
            Gesture move = AskUserForInput();
            AfterChoice(move);
            return move;
        }

        // Ask user for input until they type something valid
        private Gesture AskUserForInput()
        {
            string str;
            int index = 1;
            bool tryAgain = true;
            do
            {
                Console.WriteLine("Please Enter a number 1-5:");
                str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                        index = Convert.ToInt32(str);
                        tryAgain = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again");
                        break;
                }

            } while (tryAgain);
            return gestureList[index - 1];
        }

        private void DisplayOptions()
        {
            Console.WriteLine("These are the available moves:");
            for (int i = 0; i < gestureList.Count; i++)
            {
                Console.Write((i == 0 ? "" : ", ") + $"{i + 1}: {gestureList[i].Display()}");
            }
            Console.WriteLine();

        }

    }
}
