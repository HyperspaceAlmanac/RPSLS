using System;
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
                    Console.WriteLine("The nubmer is not 1 or 2. Please enter 1 or 2");
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
            // Game logic tests
        }
    }
}
