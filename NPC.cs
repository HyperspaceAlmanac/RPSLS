using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class NPC : Player
    {
        private Random rand;
        public NPC(int playerNum, bool useRngSeed=false) : base(playerNum)
        {
            playerNumber = playerNum;
            if (useRngSeed)
            {
                rand = new Random(Player.RNG_SEED);
            }
            else
            {
                rand = new Random();
            }
        }
        // NPC will override it to randomly select a gesture from list
        public override Gesture SelectGesture()
        {
            DisplayPlayer();
            Gesture npcMove = gestureList[rand.Next(gestureList.Count)];
            AfterChoice(npcMove);
            return npcMove;
        }
        public override void DisplayPlayer()
        {
            Console.WriteLine("=============");
            Console.WriteLine("NPC Player " + playerNumber + "'s turn");
            Console.WriteLine("=============");
        }

        public override void AfterChoice(Gesture g)
        {
            Console.WriteLine("NPC Player " + playerNumber + " has selected " + g.Display());
            Console.WriteLine("Press \"Enter\" to contiue");
            Console.ReadLine();
        }
    }
}
