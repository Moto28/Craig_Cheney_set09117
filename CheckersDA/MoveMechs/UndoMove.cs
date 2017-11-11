using System;
using System.Collections.Generic;
using CheckersDA.ViewModels;
using CheckersDA.Players;

namespace CheckersDA.MoveMechs
{
    class UndoMove
    {

        GameBoard game = new GameBoard();
        private Stack<string[,]> undoStack = new Stack<string[,]>();
        private Stack<string[,]> redoStack = new Stack<string[,]>();

        public UndoMove()
        {
            undoStack = UndoStack;
            redoStack = RedoStack;
        }
        public Stack<string[,]> UndoStack
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
        public Stack<string[,]> RedoStack
        {
            get
            {
                return redoStack;
            }
            set
            {
                redoStack = value;
            }
        }

        /// <summary>
        /// this method allows a player to undo thier move and redo it before handing the control to the other player
        /// </summary>
        /// <param name="gameBg"></param>
        /// <param name="player"></param>
        /// <param name="opponent"></param>
        /// <param name="convRow"></param>
        /// <param name="convCol"></param>
        /// <param name="newConvRow"></param>
        /// <param name="newConvCol"></param>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        public void UndoPlayerMove(string[,] gameBg, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            Console.WriteLine("Do you want to undo your move ?, y = Yes  n = No");

            // gets menu selection from console and converts to char
            char undoMenuSel = Console.ReadKey().KeyChar;

            switch (undoMenuSel)
            {
                case 'y':
                    if (undoStack.Count > 0)
                    {
                        game.Draw(undoStack.Pop(), playerOne, playerTwo);
                        Console.ReadKey();
                    }
                    Console.WriteLine("Would you like to Redo your move?, y = Yes  n = No");
                    char redoMenuSel = Console.ReadKey().KeyChar;

                    switch (redoMenuSel)
                    {
                        case 'y':

                            break;
                        case 'n':
                            break;
                        default:
                            Console.WriteLine("You Must Select a Y for yes or N for no to continue");
                            UndoPlayerMove(gameBg, playerOne, playerTwo);
                            break;
                    }
                    break;
                case 'n':
                    break;
                default:
                    Console.WriteLine("You Must Select a Y for yes or N for no to continue");
                    UndoPlayerMove(gameBg, playerOne, playerTwo);
                    break;
            }

        }
        public void AddToUndoStack(string[,] gameBg)
        {
            string[,] arrayClone = gameBg.Clone() as string[,];
            UndoStack.Push(arrayClone);
        }
        public void AddToRedoStack(string[,] gameBg)
        {
            string[,] arrayClone = gameBg.Clone() as string[,];
            RedoStack.Push(arrayClone);
        }
    }
}
