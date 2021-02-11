using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    enum GestureType {
        Rock,
        Paper,
        Scissors,
        Lizard,
        Spock
    }
    abstract class Gesture
    {
        protected GestureType gestureType;

        // Rock = 0, Paper = 1, Scissors = 2, Lizard = 3, Spock = 4
        // Rock:     0, -1,  1,  1, -1
        // Paper:    1,  0, -1, -1,  1 
        // Scissors:-1,  1,  0,  1, -1
        // Lizard:  -1,  1, -1,  0,  1 
        // Spock:    1, -1,  1, -1,  0 

        private static readonly int[,] gestureComparisonTable = new int[5, 5] {
            {0, -1, 1, 1, -1},
            {1, 0, -1, -1, 1},
            {-1, 1, 0, 1, -1},
            {-1, 1, -1, 0, 1},
            {1, -1, 1, -1, 0}};

        // Internal value for accessing 
        public Gesture(GestureType gestType=GestureType.Rock)
        {
            gestureType = gestType;
            // Table is read as leftIndex beats rightIndex

        }
        // Compare this gesture to the other one
        public static int CompareGestures(Gesture left, Gesture right)
        {
            return 0;
        }
        private static int GestureToIndex(GestureType gest)
        {
            if (gest == GestureType.Rock)
            {
                return 0;
            }
            else if (gest == GestureType.Paper)
            {
                return 1;
            }
            else if (gest == GestureType.Scissors)
            {
                return 2;
            }
            else if (gest == GestureType.Spock)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

    }
    

}
