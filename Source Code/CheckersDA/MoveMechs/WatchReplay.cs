using CheckersDA.Players;
using CheckersDA.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CheckersDA.MoveMechs
{
    class WatchReplay
    {
        #region instantiates objects used by class
        private Queue<string[,]> replayQueue = new Queue<string[,]>();
        #endregion

        #region constructor
        public WatchReplay()
        {
            replayQueue = ReplayQueue;
        }
        #endregion

        #region getter and setters
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
        #endregion

        #region adds array to queue
        public void AddToQueue(string[,] gameBg)
        {
            //clones array and adds to queue
            string[,] arrayClone = gameBg.Clone() as string[,];
            replayQueue.Enqueue(arrayClone);
        }
        #endregion

        #region watch replay
        public void Replay(GameBoard game, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            // if the queue has elements
            while (replayQueue.Count > 0)
            {
                //redraw gameboard using queue until empty
                game.Draw(replayQueue.Dequeue(), playerOne, playerTwo);
                //adds 2 sec delay
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
            }
        }
    }
    #endregion
}
