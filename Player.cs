using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    abstract class Player
    {
        public static readonly int RNG_SEED = 100;
        protected List<Gesture> gestureList;
        protected int wins;
        protected int playerNumber;

        public Player(int playerNum)
        {
            // For now, gesture list will be the same for every player
            // It can be extended to have different set of available options
            playerNumber = playerNum;
            gestureList = new List<Gesture>() { new Rock(), new Scissors(), new Paper(), new Lizard(), new Spock() };
        }
        public virtual void DisplayPlayer()
        {
            Console.WriteLine("=============");
            Console.WriteLine("Player " + playerNumber + "'s turn");
            Console.WriteLine("=============");
        }
        public virtual void AfterChoice(Gesture g)
        {
            Console.WriteLine("Player " + playerNumber + " has selected " + g.Display());
            Console.WriteLine("Press \"Enter\" to contiue");
            Console.ReadLine();
        }
        public abstract Gesture SelectGesture();
        public void WinsRound()
        {
            wins += 1;
        }
        public int RoundsWon()
        {
            return wins;
        }
        public bool Wins(int numRounds)
        {
            // 3 rounds = 2 to win, 5 -> 3 , 7 -> 4, 9 -> 5
            // 4 = can tie, 6 = can tie
            // Game's responsibility to ensure that it is odd
            // Enforce rounds > 2 on Game side
            return wins >= numRounds / 2 + 1;
        }

        public void RunGestureTests()
        {
            // Basic Gesture functionality tests
            DisplayTest();
            RockSanityTest();
            CheckAllCases();
            Console.ReadLine();
        }

        private void DisplayTest()
        {
            Console.WriteLine("Gesture.Display() Test");
            foreach (Gesture g in gestureList)
            {
                Console.WriteLine(g.Display());
            }
        }

        private void RockSanityTest()
        {
            Console.WriteLine("Basic Rock comparison test");
            Console.WriteLine($"Rock equals Rock, should return 0. {gestureList[0]}, {gestureList[0]}: {Gesture.CompareGestures(gestureList[0], gestureList[0])}");
            Console.WriteLine($"Rock beats Scissors, should return 1. {gestureList[0]}, {gestureList[2]}: {Gesture.CompareGestures(gestureList[0], gestureList[2])}");
            Console.WriteLine($"Rock beats Lizard, should return 1. {gestureList[0]}, {gestureList[3]}: {Gesture.CompareGestures(gestureList[0], gestureList[3])}");
            Console.WriteLine($"Rock loses to Paper, should return -1. {gestureList[0]}, {gestureList[1]}: {Gesture.CompareGestures(gestureList[0], gestureList[1])}");
            Console.WriteLine($"Rock loses to Spock, should return -1. {gestureList[0]}, {gestureList[4]}: {Gesture.CompareGestures(gestureList[0], gestureList[4])}");
        }

        private void CheckAllCases()
        {
            int result;
            for (int i = 0; i < gestureList.Count; i++)
            {
                for (int j = 0; j < gestureList.Count; j++)
                {
                    // Fun with 2x ternary operator
                    result = Gesture.CompareGestures(gestureList[i], gestureList[j]);
                    Console.WriteLine($"{gestureList[i].Display()}" + (result == 0 ? " is equal to " : result == 1 ? " " + gestureList[i].GetVerb(gestureList[j].LoseVerbs()) + " " : " loses to ") + $"{gestureList[j].Display()}");
                }
            }
        }
    }
}
