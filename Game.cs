﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private int totalRounds;
        private bool playerOneTurn;
        private bool vsNPC;
        private bool displayedMessage;
        private Player player1;
        private Player player2;

        private static readonly Regex zeroRegex = new Regex(@"^0+$");
        private static readonly Regex numberRegex = new Regex(@"^\d+$");

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
            displayedMessage = false;
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
            Console.WriteLine("Exiting Game. Press \"Enter\" to close application");
            Console.ReadLine();
        }

        private GameState SelectMode()
        {
            if (!displayedMessage)
            {
                Console.WriteLine("Welcome to Rock Paper Scissors Lizard Spock!");
                ExplainRules();
                displayedMessage = true;
            }
            Console.WriteLine("Please enter 1 for single player, or 2 for multiplayer");
            ExitGamePrompt();
            int result = HandleNumberInput(Console.ReadLine());
            if (result == 0)
            {
                return GameState.Exit;
            }
            else if (result == -1)
            {
                Console.WriteLine("Invalid input, please try again");
                return GameState.SelectMode;
            }
            else
            {
                if (result == 1)
                {
                    vsNPC = true;
                    displayedMessage = false;
                    return GameState.SelectRounds;
                }
                else if (result == 2)
                {
                    vsNPC = false;
                    displayedMessage = false;
                    return GameState.SelectRounds;
                }
                else
                {
                    Console.WriteLine("Please enter 1 or 2");
                    return GameState.SelectMode;
                }
            }
        }

        private GameState SelectRounds()
        {
            Console.WriteLine("Please enter how many rounds the game is best of");
            Console.WriteLine("It should be an odd number from 1-99");
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

        private void ExplainRules()
        {
            Console.WriteLine("=============");
            Console.WriteLine("This game is like Rock, Paper, Scissors, but with two more options");
            Console.WriteLine("Rock beats Scissors and Lizard, but loses to Paper and Spock");
            Console.WriteLine("Paper beats Rock and Spock, but loses to Scissors and Lizard");
            Console.WriteLine("Scissors beats Paper and Lizard, but loses to Spock and Rock");
            Console.WriteLine("Lizard beats Spock and Paper, but loses to Rock and Scissors");
            Console.WriteLine("Spock beats Scissors and Rock, but loses to Lizard and Paper");
            Console.WriteLine("=============");
        }
        private void ExitGamePrompt()
        {
            Console.WriteLine("Or enter \"exit\" to exit the game");
        }
        private bool GestureIndexIsValid(int index)
        {
            return index < gestureList.Count;
        }
        private bool PlayerWins(Player player)
        {
            return player.Wins(totalRounds);
        }
        private GameState GameOver()
        {
            return GameState.Exit;
        }

        // Static function to handle IO
        // 0 for exit, -1 for not number
        // Otherwise return a number
        public static int HandleNumberInput(string str)
        {
            if (str == "Exit")
            {
                return 0;
            } else if (str.Length > 2 || Game.zeroRegex.IsMatch(str)) {
                return -1;
            }
            if (Game.numberRegex.IsMatch(str))
            {
                return Convert.ToInt32(str);
            }
            else
            {
                return -1;
            }
        }

        public void runTests()
        {
            // Basic Gesture functionality tests
            //DisplayTest();
            //RockSanityTest();
            //CheckAllCases();
            //DisplayOptions();

            // Game logic tests
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
