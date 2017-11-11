using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.MoveMechs
{
    class WatchReplay
    {
        private Queue<string> replayQueue = new Queue<string>();
        public WatchReplay()
        {
            replayQueue = ReplayQueue;
        }
        public Queue<string> ReplayQueue
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

        public void Replay()
        {
            while (replayQueue.Count >= 0)
            {
                Console.WriteLine("{0}", replayQueue.Dequeue());
                Console.ReadKey();
            }
        }
    }
}
