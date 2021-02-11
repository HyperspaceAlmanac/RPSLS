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
        }
        public override string Display()
        {
            return "Spock";
        }
    }
}
