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
        }
        public override string Display()
        {
            return "Lizard";
        }
    }
}
