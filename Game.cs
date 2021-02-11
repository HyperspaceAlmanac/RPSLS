using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    enum GameState
    {
        SelectMode,
        SelectRounds,
        TakeTurn,
        GameOver,
        Exit
    }
    class Game
    {
        private List<Gesture> gestureList = new List<Gesture>();
        private int roundsToWin;

        // Game constructor will generate the Gestures and put them into list
        public Game()
        {
            gestureList.Add(new Rock());
            gestureList.Add(new Paper());
            gestureList.Add(new Scissors());
            gestureList.Add(new Lizard());
            gestureList.Add(new Spock());
        }
        // Handles all of the game logic
        public void RunGame()
        {
            GameState state = GameState.SelectMode;
            while (state != GameState.Exit)
            {
                switch (state)
                {
                    case GameState.SelectMode:
                        state = SelectMode();
                        break;
                    case GameState.SelectRounds:
                        state = SelectRounds();
                        break;
                    case GameState.TakeTurn:
                        state = TakeTurn();
                        break;
                    case GameState.GameOver:
                        state = GameOver();
                        break;
                    default:
                        state = GameState.Exit;
                        break;
                }
            }
            Console.ReadLine();
        }

        private GameState SelectMode()
        {
            Console.WriteLine("Starting Game");
            return GameState.Exit;
        }
        private GameState SelectRounds()
        {
            return GameState.Exit;
        }
        private GameState TakeTurn()
        {
            return GameState.Exit;
        }
        private void DisplayOptions()
        {
            Console.WriteLine("These are the available gestures:");
            for (int i = 0; i < gestureList.Count; i++)
            {
                Console.Write((i == 0 ? "" : ", ") + $"{i + 1}: {gestureList[i].Display()}");
            }
            Console.WriteLine();

        }

        private bool GestureIndexIsValid(int index)
        {
            return index < gestureList.Count;
        }
        private bool PlayerWins(Player player)
        {
            return false;
        }
        private GameState GameOver()
        {
            return GameState.Exit;
        }

        public void runTests()
        {
            // Basic Gesture functionality tests
            //DisplayTest();
            //RockSanityTest();
            //CheckAllCases();
            DisplayOptions();

        }

        // Tests kept as private, only called by public runTests() method
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
                    Console.WriteLine($"{gestureList[i].Display()}" + (result == 0 ? " is equal to " : result == 1 ? " beats " : " loses to ") + $"{gestureList[j].Display()}");
                }
            }
        }

    }
}
