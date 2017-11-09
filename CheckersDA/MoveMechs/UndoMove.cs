using System;
using System.Collections.Generic;
using CheckersDA.ViewModels;
using CheckersDA.Players;

namespace CheckersDA.MoveMechs
{
    class UndoMove
    {
        private Stack<string> undoStack = new Stack<string>();
        GameBoard game = new GameBoard();
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

        public void UndoPlayerMove(string[,] gameBg, string player, string opponent, int convRow, int convCol, int newConvRow, int newConvCol, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            Console.WriteLine("Do you want to undo your move ?, y = Yes  n = No");
            char undoMenuSel = Console.ReadKey().KeyChar;

            switch (undoMenuSel)
            {
                case 'y':
                    gameBg[convRow, convCol] = player;
                    gameBg[newConvRow, newConvCol] = opponent;
                    game.Draw(gameBg, playerOne, playerTwo);

                    Console.WriteLine("Do you want to redo your move ?, y = Yes  n = No");
                    char redoMenuSel = Console.ReadKey().KeyChar;

                    switch (redoMenuSel)
                    {
                        case 'y':
                            gameBg[newConvRow, newConvCol] = player;
                            gameBg[convRow, convCol] = opponent;
                            break;
                        case 'n':

                            break;
                        default:
                            Console.WriteLine("You Must Select a Y for yes or N for no to continue");
                            UndoPlayerMove(gameBg, player, opponent, convRow, convCol, newConvRow, newConvCol, playerOne, playerTwo);
                            break;
                    }
                    break;
                case 'n':

                    break;
                default:
                    Console.WriteLine("You Must Select a Y for yes or N for no to continue");
                    UndoPlayerMove(gameBg, player, opponent, convRow, convCol, newConvRow, newConvCol, playerOne, playerTwo);
                    break;
            }
        }
    }
}
