using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class NPC : Player
    {
        public NPC(bool rngSeed=false) {
        }
        public override int SelectGesture()
        {
            return 0;
        }
    }
}
