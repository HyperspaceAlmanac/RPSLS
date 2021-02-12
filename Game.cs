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
        WelcomeScreen,
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
            GameState state = GameState.WelcomeScreen;
            while (state != GameState.Exit)
            {
                switch (state)
                {
                    case GameState.WelcomeScreen:
                        state = WelcomeScreen();
                        break;
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
        private GameState WelcomeScreen()
        {
            Console.WriteLine("==================");
            Console.WriteLine("Welcome to Rock, Paper, Scissors, Lizard, Spock!");
            ExplainRules();
            return GameState.SelectMode;
        }

        private GameState SelectMode()
        {
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
            Console.WriteLine("Please enter how many rounds the game is best of(EX: Best of 5 is first to 3, Best of 7 is first to 4):");
            Console.WriteLine("It should be an odd number from 3 to 99");
            int result = HandleNumberInput(Console.ReadLine());
            if (result == 0)
            {
                return GameState.Exit;
            }
            // 1 is an interseting case... I guess just hardcode handle it here
            else if (result == -1 || result == 1 || result == 2)
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
                    Console.WriteLine(g2.Display() + $" {g2.GetVerb(g1.LoseVerbs())} " + g1.Display() + "\n");
                    DisplayRoundWinner(2);
                    player2.WinsRound();
                    break;
                case 0:
                    Console.WriteLine("Both players chose: " + g2.Display());
                    Console.WriteLine("It was a tie!");
                    break;
                case 1:
                    Console.WriteLine(g1.Display() + $" {g1.GetVerb(g2.LoseVerbs())} " + g2.Display() + "\n");
                    DisplayRoundWinner(1);
                    player1.WinsRound();
                    break;
                default:
                    Console.WriteLine("Should not reach here, need to debug");
                    break;
            }
            if (player1.Wins(totalRounds)) {
                DisplayWinner(1, totalRounds);
                return GameState.GameOver;
            }
            if (player2.Wins(totalRounds))
            {
                DisplayWinner(2, totalRounds);
                return GameState.GameOver;
            }
            else
            {
                Console.WriteLine("==============");
                Console.WriteLine("The score is " + (result == 0 ? "still " : "now ") + $"{player1.RoundsWon()} to {player2.RoundsWon()}. {totalRounds / 2 + 1} points to win");
                Console.WriteLine("==============");
                Console.WriteLine("Press \"Enter\" to contiue");
                Console.ReadLine();
                return GameState.TakeTurn;
            }
        }

        private void DisplayRoundWinner(int num)
        {
            Console.WriteLine("Player " + num + " wins this round!");
        }

        private void DisplayWinner(int num, int totalRounds)
        {
            Console.WriteLine("=================");
            Console.WriteLine($"Player {num} is the first to win {totalRounds / 2 + 1} round" + (totalRounds > 1 ? "s" : "") + " and is the winner!");
            Console.WriteLine("=================");
        }

        private void ExplainRules()
        {
            Console.WriteLine("==================");
            Console.WriteLine("This game is like Rock, Paper, Scissors, but with two more options");
            Console.WriteLine("Rock crushes Scissors");
            Console.WriteLine("Scissors cuts Paper");
            Console.WriteLine("Paper covers Rock");
            Console.WriteLine("Rock crushes Lizard");
            Console.WriteLine("Lizard poisons Spock");
            Console.WriteLine("Spock smashes Scissors");
            Console.WriteLine("Scissors decapitates Lizard");
            Console.WriteLine("Lizard eats Paper");
            Console.WriteLine("Paper disproves Spock");
            Console.WriteLine("Spock vaporizes Rock");
            Console.WriteLine("==================");
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
                return GameState.WelcomeScreen;
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
            if (str == "exit")
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
