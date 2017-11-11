using CheckersDA.Players;
using CheckersDA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.MoveMechs
{
    class WatchReplay
    {
        private Queue<string[,]> replayQueue = new Queue<string[,]>();
        public WatchReplay()
        {
            replayQueue = ReplayQueue;
        }
        public Queue<string[,]> ReplayQueue
        {
            get
            {
                return replayQueue;
            }
            set
            {
                replayQueue = value;
            }
        }

        public void AddToQueue(string[,] gameBg)
        {
            string[,] arrayClone = gameBg.Clone() as string[,];
            replayQueue.Enqueue(arrayClone);
        }

        public void Replay(GameBoard game, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            while (replayQueue.Count > 0)
            {
                game.Draw(replayQueue.Dequeue(), playerOne, playerTwo);
                Console.ReadKey();
            }
        }
    }
}
