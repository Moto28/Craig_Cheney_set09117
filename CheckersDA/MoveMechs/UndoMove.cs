using System;
using System.Collections.Generic;
using CheckersDA.MoveConvertor;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.MoveMechs
{
    class UndoMove
    {
        private Stack<string> undoStack = new Stack<string>();
        public UndoMove()
        {
            undoStack = UndoStack;
        }

        public Stack<string> UndoStack
        {
            get
            {
                return undoStack;
            }
            set
            {
                undoStack = value;
            }
        }

        public void UndoPlayerMove(string[,] gameBg, string player, string opponent, int convRow, int convCol, int newConvRow, int newConvCol)
        {
            Console.WriteLine("Do you want to undo your move ?, y = Yes  n = No");
            char switchMenuSel = Console.ReadKey().KeyChar;

            switch (switchMenuSel)
            {
                case 'y':
                    Console.WriteLine("{0}{1}", convRow, convCol);
                    Console.ReadKey();
                    gameBg[convRow, convCol] = player;
                    gameBg[newConvRow, newConvCol] = opponent;
                    break;
                case 'n':

                    break;
                default:
                    Console.WriteLine("You Must Select a Y for yes or N for no to continue");
                    UndoPlayerMove(gameBg, player, opponent, convRow, convCol, newConvRow, newConvCol);
                    break;
            }
        }
    }
}
