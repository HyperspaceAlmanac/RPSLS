using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class NPC : Player
    {
        private Random rand;
        public NPC(bool useRngSeed=false) {
            if (useRngSeed)
            {
                rand = new Random(Player.RNG_SEED);
            }
            else
            {
                rand = new Random();
            }
        }
        public override int SelectGesture()
        {
            // Return 1-5
            return rand.Next(1, 6);
        }
    }
}
