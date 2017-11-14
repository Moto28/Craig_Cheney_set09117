using System;
using System.Collections.Generic;
using CheckersDA.ViewModels;
using CheckersDA.Players;

namespace CheckersDA.MoveMechs
{
    class UndoMove
    {
        #region instantiates objects needed by class
        GameBoard game = new GameBoard();
        #endregion

        #region creates private varibles
        private Stack<string[,]> undoStack = new Stack<string[,]>();
        private Stack<string[,]> redoStack = new Stack<string[,]>();
        #endregion

        #region constructor

        public UndoMove()
        {
            undoStack = UndoStack;
            redoStack = RedoStack;
        }

        #endregion

        #region getters and setters 
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
        #endregion

        #region control structure of undo and redo move
        public void UndoPlayerMove(string[,] gameBg, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            Console.WriteLine("Do you want to undo your move ?, y = Yes  n = No");

            // gets menu selection from console and converts to char
            char undoMenuSel = Console.ReadKey().KeyChar;

            switch (undoMenuSel)
            {
                case 'y':
                    //if the player presses y and the undo stack contains an elements the gamebaord is redrawen
                    if (undoStack.Count > 0)
                    {
                        //checks if its player one or player twos turn
                        if (playerOne.IsItMyTurn == true)
                        {
                            playerOne.PlayerTurnCount--;
                        }
                        else
                        {
                            playerTwo.PlayerTurnCount--;
                        }
                        game.Draw(undoStack.Pop(), playerOne, playerTwo);
                    }
                    // the user is then asked if they would like to redo the move the have just done
                    Console.WriteLine("Would you like to Redo your move?, y = Yes  n = No");
                    char redoMenuSel = Console.ReadKey().KeyChar;

                    switch (redoMenuSel)
                    {
                        case 'y':
                            //checks if its player one or player twos turn
                            if (playerOne.IsItMyTurn == true)
                            {
                                playerOne.PlayerTurnCount++;
                            }
                            else
                            {
                                playerTwo.PlayerTurnCount++;
                            }
                            //if the redo move is selected is redraws the board back the way it was before te move
                            game.Draw(redoStack.Pop(), playerOne, playerTwo);
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
        #endregion

        #region adds array to stack
        public void AddToUndoStack(string[,] gameBg)
        {
            //clone a ref of gameBg array and adds to undo stack
            string[,] arrayClone = gameBg.Clone() as string[,];
            UndoStack.Push(arrayClone);
        }
        #endregion

        #region adds array to stack
        public void AddToRedoStack(string[,] gameBg)
        {
            // clone a ref of gameBg array and adds to redo stack
            string[,] arrayClone = gameBg.Clone() as string[,];
            RedoStack.Push(arrayClone);
        }
        #endregion
    }
}
