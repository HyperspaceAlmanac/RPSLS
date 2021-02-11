using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    abstract class Player
    {
        protected int wins;
        public abstract int SelectGesture();
        public void WinsRound()
        {
            wins += 1;
        }
        public bool Wins(int numRounds)
        {
            // 3 rounds = 2 to win, 5 -> 3 , 7 -> 4, 9 -> 5
            // 4 = can tie, 6 = can tie
            // Game's responsibility to ensure that it is odd
            return wins >= numRounds / 2 + 1;
        }
    }
}
