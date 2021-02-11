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
        // NPC will override it to randomly select a gesture from list
        public override Gesture SelectGesture()
        {
            return gestureList[rand.Next(gestureList.Count)];
        }
    }
}
