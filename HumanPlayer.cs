using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class HumanPlayer : Player
    {
        public override int SelectGesture()
        {
            Console.WriteLine("Please Enter a number 1-5");
            string str = Console.ReadLine();
            return Game.HandleNumberInput(str);
        }

    }
}
