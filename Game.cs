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
        private bool displayRules;
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
            displayRules = true;
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
            if (displayRules)
            {
                Console.WriteLine("Welcome to Rock Paper Scissors Lizard Spock!");
                ExplainRules();
                displayRules = false;
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
                    player1 = new HumanPlayer(1);
                    player2 = new NPC(2);
                    return GameState.SelectRounds;
                }
                else if (result == 2)
                {
                    vsNPC = false;
                    player1 = new HumanPlayer(1);
                    player2 = new HumanPlayer(2);
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
            Console.WriteLine("Please enter how many rounds the game is best of(Best of 5 is first to 3, Best of 7 is first to 4):");
            Console.WriteLine("It should be an odd number from 1-99");
            int result = HandleNumberInput(Console.ReadLine());
            if (result == 0)
            {
                return GameState.Exit;
            }
            else if (result == -1)
            {
                Console.WriteLine("Invalid Input. Please try again");
                return GameState.SelectRounds;
            }
            else if (result % 2 == 0)
            {
                Console.WriteLine("Even number can lead to ties. Please enter an odd number.");
                return GameState.SelectRounds;
            }
            else
            {
                totalRounds = result;
                Console.WriteLine($"This will be a best of {result}. First player to win {result / 2 + 1} rounds will be the winner");
                Console.WriteLine("=============");
                Console.WriteLine("Starting game");
                Console.WriteLine("=============");
                return GameState.TakeTurn;
            }
        }
        // Have the players choose Gestures
        private GameState TakeTurn()
        {
            Gesture g1 = player1.SelectGesture();
            Gesture g2 = player2.SelectGesture();
            int result = Gesture.CompareGestures(g1, g2);
            switch (result)
            {
                case -1:
                    Console.WriteLine(g2.Display() + " beats " + g1.Display());
                    Console.WriteLine("Player 2 wins this round!");
                    player2.WinsRound();
                    break;
                case 0:
                    Console.WriteLine("Both players chose: " + g2.Display());
                    Console.WriteLine("It was a tie!");
                    break;
                case 1:
                    Console.WriteLine(g1.Display() + " beats " + g2.Display());
                    Console.WriteLine("Player 1 wins this round!");
                    player1.WinsRound();
                    break;
                default:
                    Console.WriteLine("Should not reach here, need to debug");
                    break;
            }
            if (player1.Wins(totalRounds)) {
                Console.WriteLine("=================");
                Console.WriteLine($"Player 1 has won {totalRounds / 2 + 1} rounds and is the winner!");
                Console.WriteLine("=================");
                return GameState.GameOver;
            }
            if (player2.Wins(totalRounds))
            {
                Console.WriteLine("=================");
                Console.WriteLine($"Player 2 has won {totalRounds / 2 + 1} rounds and is the winner!");
                Console.WriteLine("=================");
                return GameState.GameOver;
            }
            else
            {
                Console.WriteLine("The score is " + (result == 0 ? "still " : "now ") + $"{player1.RoundsWon()} to {player2.RoundsWon()}");
                Console.WriteLine("Press \"Enter\" to contiue");
                Console.ReadLine();
                return GameState.TakeTurn;
            }
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
            Console.WriteLine("Play again? Enter \"yes\" to restart the game.");
            string str = Console.ReadLine();
            if (str == "yes")
            {
                displayRules = true;
                return GameState.SelectMode;
            }
            else
            {
                return GameState.Exit;
            }
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
