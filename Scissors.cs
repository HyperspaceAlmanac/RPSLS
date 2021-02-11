using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Scissors : Gesture
    {
        public Scissors() : base(GestureType.Scissors)
        {
        }
        public override string Display()
        {
            return "Scissors";
        }
    }
}
