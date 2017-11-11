using System;
using System.Collections.Generic;
using CheckersDA.ViewModels;
using CheckersDA.Players;

namespace CheckersDA.MoveMechs
{
    class UndoMove
    {

        GameBoard game = new GameBoard();
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
        public void UndoPlayerMove(string[,] gameBg, string player, string opponent, int convRow, int convCol, int newConvRow, int newConvCol, PlayerOne playerOne, PlayerTwo playerTwo, CollisionDect detect)
        {
            Console.WriteLine("Do you want to undo your move ?, y = Yes  n = No");

            // gets menu selection from console and converts to char
            char undoMenuSel = Console.ReadKey().KeyChar;

            switch (undoMenuSel)
            {
                case 'y':
                    //if yes player is restored to last point on map
                    gameBg[convRow, convCol] = player;
                    gameBg[newConvRow, newConvCol] = opponent;
                    //checks if up
                    if (convRow > newConvRow)
                    {
                        //checks if left
                        if (convCol > newConvCol)
                        {
                            gameBg[newConvRow - 1, newConvCol - 1] = "\0 ";
                        }
                        //checks if right
                        else if (newConvCol > convCol)
                        {
                            gameBg[newConvRow - 1, newConvCol + 1] = "\0 ";
                        }
                    }
                    //checks if down
                    else if (newConvRow > convRow)
                    {
                        //checks if left
                        if (convCol > newConvCol)
                        {
                            gameBg[newConvRow + 1, newConvCol - 1] = "\0 ";
                        }
                        //checks if right
                        else if (newConvCol > convCol)
                        {
                            gameBg[newConvRow + 1, newConvCol + 1] = "\0 ";
                        }
                    }
                    game.Draw(gameBg, playerOne, playerTwo);
                    detect.AnotherMove = true;
                    detect.MoveComplete = false;

                    Console.WriteLine("Do you want to redo your move ?, y = Yes  n = No");
                    char redoMenuSel = Console.ReadKey().KeyChar;

                    switch (redoMenuSel)
                    {
                        case 'y':
                            gameBg[convRow, convCol] = "\0 ";
                            gameBg[newConvRow, newConvCol] = "\0 ";
                            //checks if move is up
                            if (convRow > newConvRow)
                            {

                                //checks if left
                                if (convCol > newConvCol)
                                {
                                    gameBg[newConvRow - 1, newConvCol - 1] = player;
                                }
                                //checks if right
                                else if (newConvCol > convCol)
                                {
                                    gameBg[newConvRow - 1, newConvCol + 1] = player;
                                }
                            }
                            //checks if down
                            else if (newConvRow > convRow)
                            {
                                //checks if left
                                if (convCol > newConvCol)
                                {
                                    gameBg[newConvRow + 1, newConvCol - 1] = player;
                                }
                                //checks if right
                                else if (newConvCol > convCol)
                                {
                                    gameBg[newConvRow + 1, newConvCol + 1] = player;
                                }
                            }
                            game.Draw(gameBg, playerOne, playerTwo);
                            break;
                        case 'n':

                            break;
                        default:
                            Console.WriteLine("You Must Select a Y for yes or N for no to continue");
                            UndoPlayerMove(gameBg, player, opponent, convRow, convCol, newConvRow, newConvCol, playerOne, playerTwo, detect);
                            break;
                    }
                    break;
                case 'n':

                    break;
                default:
                    Console.WriteLine("You Must Select a Y for yes or N for no to continue");
                    UndoPlayerMove(gameBg, player, opponent, convRow, convCol, newConvRow, newConvCol, playerOne, playerTwo, detect);
                    break;
            }
        }
    }
}
