using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Rock : Gesture
    {
        public Rock() : base(GestureType.Rock)
        {
        }
        public override string Display()
        {
            return "Rock";
        }
    }
}
