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
            switch (str)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    return Convert.ToInt32(str);
                case "Exit":
                    return 0;
                default:
                    return -1;
            }
        }

    }
}
