using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Lizard : Gesture
    {
        public Lizard() : base(GestureType.Lizard)
        {
            winVerb = new string[] { "poisons", "eats" };
            loseVerb = new string[] { "crushes", "decapitates" };
        }
        public override string Display()
        {
            return "Lizard";
        }
    }
}
