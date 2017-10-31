using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.MoveMechs
{
    class UndoMove
    {
        private Queue<string> undoQueue = new Queue<string>();
        public UndoMove()
        {
            undoQueue = UndoQueue;
        }

        public Queue<string> UndoQueue
        {
            get
            {
                return undoQueue;
            }
            set
            {
                undoQueue = value;
            }
        }


        public void UndoPlayerMove(char[,] gameBg, int row, int col, int moveRow, int moveCol)
        {
            Console.WriteLine("do you want to undo your move?: Press Y for yes and N for no");
            char switchMenuSel = Console.ReadKey().KeyChar;

            switch (switchMenuSel)
            {
                case 'Y':

                    break;
                case 'N':

                    break;
                default:
                    Console.WriteLine("You Must Select a Y for yes or N for no to continue");
                    break;

            }

        }
    }
}
