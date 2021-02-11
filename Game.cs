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
        private List<Gesture> gestures = new List<Gesture>();
        private int roundsToWin;

        // Game constructor will generate the Gestures and put them into list
        public Game()
        {

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

        public GameState SelectMode()
        {
            Console.WriteLine("Starting Game");
            return GameState.Exit;
        }
        public GameState SelectRounds()
        {
            return GameState.Exit;
        }
        public GameState TakeTurn()
        {
            return GameState.Exit;
        }
        public GameState GameOver()
        {
            return GameState.Exit;
        }

    }
}
