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
        }
        public override string Display()
        {
            return "Paper";
        }
    }
}
