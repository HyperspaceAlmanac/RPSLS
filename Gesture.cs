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
        protected string[] winVerb;
        protected string[] loseVerb;

        // Rock = 0, Paper = 1, Scissors = 2, Lizard = 3, Spock = 4
        // Rock:     0, -1,  1,  1, -1
        // Paper:    1,  0, -1, -1,  1 
        // Scissors:-1,  1,  0,  1, -1
        // Lizard:  -1,  1, -1,  0,  1 
        // Spock:    1, -1,  1, -1,  0 

        private static readonly int[,] GESTURECOMPARISONTABLE = new int[5, 5] {
            {0, -1, 1, 1, -1},
            {1, 0, -1, -1, 1},
            {-1, 1, 0, 1, -1},
            {-1, 1, -1, 0, 1},
            {1, -1, 1, -1, 0}};

        // Internal value for accessing 
        public Gesture(GestureType gestType)
        {
            gestureType = gestType;
            winVerb = new string[] { "beat", "beat" };
            loseVerb = new string[] { "beat", "beat" };
            // Table is read as leftIndex beats rightIndex

        }
        // Prevent GestureType enum from being changed from outside
        // Only have this getter function
        public GestureType GetGesture()
        {
            return gestureType;
        }
        public string[] LoseVerbs()
        {
            return loseVerb;
        }
        // For fun. Cannot think of a really clean way to do this
        // For now each object has 2 verbs for winning, and 2 verbs for losing
        // Compare and find the ones that match
        public string GetVerb(string[] otherLoseVerb)
        {
            if (winVerb[0] == otherLoseVerb[0] || winVerb[0] == otherLoseVerb[1])
            {
                return winVerb[0];
            }
            else
            {
                return winVerb[1];
            }
        }

        public abstract string Display();
        // Compare this gesture to the other one
        public static int CompareGestures(Gesture left, Gesture right)
        {
            int leftIndex = GestureToIndex(left);
            int rightIndex = GestureToIndex(right);
            return GESTURECOMPARISONTABLE[leftIndex, rightIndex];
        }
        private static int GestureToIndex(Gesture gest)
        {
            if (gest.GetGesture() == GestureType.Rock)
            {
                return 0;
            }
            else if (gest.GetGesture() == GestureType.Paper)
            {
                return 1;
            }
            else if (gest.GetGesture() == GestureType.Scissors)
            {
                return 2;
            }
            else if (gest.GetGesture() == GestureType.Lizard)
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
