using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Paper : Gesture
    {
        public Paper() : base(GestureType.Paper)
        {
            winVerb = new string[] { "disproves", "covers" };
            loseVerb = new string[] { "cuts", "eats" };
        }
        public override string Display()
        {
            return "Paper";
        }
    }
}
