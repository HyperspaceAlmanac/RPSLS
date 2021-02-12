using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Player p = new HumanPlayer(1);
            // p.RunGestureTests();
            Game game = new Game();
            //game.runTests();
            game.RunGame();
        }
    }
}
