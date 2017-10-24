using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersDA.Players;
using CheckersDA.ViewModels;

namespace CheckersDA.MoveMechs
{
    class CollisionDect
    {

        string player;
        public bool moveComplete;


        public void CheckAndUpdate(char[,] gameBg, int row, int col, int moveRow, int moveCol, PlayerOne playerOne, PlayerTwo playerTwo, GameBoard gameboard)
        {
            //resets move complete when method has been restarted
            moveComplete = false;
            //take row and col passed in checks corrisponding location in array and sets the player as that location in array .ToString()
            player = gameBg[row, col].ToString();

            if (playerOne.PlayerChecker == "X" && playerOne.IsItMyTurn == true)
            {
                if (gameBg[row, col].ToString() == "O")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player one can only move X's on the board");
                    Console.ReadKey();
                    gameboard.Draw(gameBg, playerOne, playerTwo);


                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == player | gameBg[moveRow, moveCol] == 'N')
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();
                    gameboard.Draw(gameBg, playerOne, playerTwo);
                }
                //checks if the selected row is less than moveRow as the checker can only move one row at a time and the move is not backwards
                if (row - moveRow == 1 && row > moveRow)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol - 1].ToString() != "O")
                    {
                        if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol - 1].ToString() != "O" && gameBg[moveRow - 2, moveCol - 2].ToString() == "O" && gameBg[moveRow - 3, moveCol - 3].ToString() != "O")
                        {
                            Console.WriteLine("some message");
                            playerOne.GetPlayerTurnCount();
                        }
                        else
                        {
                            gameBg[row, col] = '\0';
                            gameBg[moveRow, moveCol] = '\0';
                            gameBg[moveRow - 1, moveCol - 2] = Convert.ToChar(player);
                            moveComplete = true;
                            playerOne.GetPlayerTurnCount();
                        }

                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol + 1].ToString() != "O")
                    {
                        if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol + 1].ToString() != "O" && gameBg[moveRow - 2, moveCol + 2].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 3, moveCol + 3].ToString() != "O")
                        {
                            Console.WriteLine("message ituytiut");
                            playerOne.GetPlayerTurnCount();
                        }
                        else
                        {
                            gameBg[row, col] = '\0';
                            gameBg[moveRow, moveCol] = '\0';
                            gameBg[moveRow - 1, moveCol + 1] = Convert.ToChar(player);
                            moveComplete = true;
                            playerOne.GetPlayerTurnCount();
                        }

                    }
                    // checks if the postion the player is moving to is a null character in the array
                    else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "\0")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = Convert.ToChar(player);
                        moveComplete = true;
                        playerOne.GetPlayerTurnCount();
                    }
                    else
                    {
                        Console.WriteLine("\n Another Checker Is Blocking Your Move");
                        Console.ReadKey();
                        gameboard.Draw(gameBg, playerOne, playerTwo);
                    }
                }
                else
                {
                    Console.WriteLine("\nyou can only move forward once per shot, and you can't move backwards");
                    Console.ReadKey();
                    gameboard.Draw(gameBg, playerOne, playerTwo);
                }
            }
            else if (playerTwo.PlayerChecker == "O" && playerTwo.IsItMyTurn == true)
            {
                if (player == "X")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player two can only move O's on the board");
                    Console.ReadKey();
                    gameboard.Draw(gameBg, playerOne, playerTwo);
                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == player | gameBg[moveRow, moveCol] == 'N')
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();
                    gameboard.Draw(gameBg, playerOne, playerTwo);
                }
                //checks if the selected row is less than moveRow as the checker can only move one row at a time
                if (moveRow - row == 1 && row < moveRow)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "X" && gameBg[moveRow + 1, moveCol - 1].ToString() != "X")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = '\0';
                        gameBg[moveRow + 1, moveCol - 1] = Convert.ToChar(player);
                        moveComplete = true;
                        playerTwo.GetPlayerTurnCount();

                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "X" && gameBg[moveRow + 1, moveCol + 1].ToString() != "X")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = '\0';
                        gameBg[moveRow + 1, moveCol + 1] = Convert.ToChar(player);
                        moveComplete = true;
                        playerTwo.GetPlayerTurnCount();

                    }
                    // checks if the postion the player is moving to is a null character in the array
                    else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "\0")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = Convert.ToChar(player);
                        moveComplete = true;
                        playerTwo.GetPlayerTurnCount();
                    }
                    else
                    {
                        Console.WriteLine("\n Another Checker Is Blocking Your Move");
                        Console.ReadKey();
                        gameboard.Draw(gameBg, playerOne, playerTwo);
                    }

                }
                else
                {
                    Console.WriteLine("\nyou can only move forward once per shot, and you can't move backwards");
                    Console.ReadKey();
                    gameboard.Draw(gameBg, playerOne, playerTwo);
                }
            }
            else
            {
                Console.WriteLine("\n you must select a tile with an X for player 1 and O for player 2");
                gameboard.Draw(gameBg, playerOne, playerTwo);
            }
        }
    }
}
