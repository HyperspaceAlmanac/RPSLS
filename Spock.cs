using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Spock : Gesture
    {
        public Spock() : base(GestureType.Spock)
        {
            winVerb = new string[] { "smashes", "vaporizes" };
            loseVerb = new string[] { "poisons", "disproves" };
        }
        public override string Display()
        {
            return "Spock";
        }
    }
}
