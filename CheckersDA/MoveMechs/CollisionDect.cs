using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.MoveMechs
{
    class CollisionDect
    {
        string player;
        public bool moveComplete;


        public void CheckAndUpdate(char[,] gameBg, int row, int col, int moveRow, int moveCol)
        {
            //resets move complete when method has been restarted
            moveComplete = false;
            //take row and col passed in checks corrisponding location in array and sets the player as that location in array .ToString()
            player = gameBg[row, col].ToString();

            if (player == "X")
            {
                if (player == "O")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player one can only move X's on the board");
                    Console.ReadKey();
                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == player | gameBg[moveRow, moveCol] == 'N')
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();
                }
                //checks if the selected row is less than moveRow as the checker can only move one row at a time and the move is not backwards
                else if (row - moveRow == 1 && row > moveRow)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol - 1].ToString() != "O")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = '\0';
                        gameBg[moveRow - 1, moveCol - 2] = Convert.ToChar(player);
                        moveComplete = true;
                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol + 1].ToString() != "O")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = '\0';
                        gameBg[moveRow - 1, moveCol + 1] = Convert.ToChar(player);
                        moveComplete = true;
                    }
                    // checks if the postion the player is moving to is a null character in the array
                    else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "\0")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = Convert.ToChar(player);
                        moveComplete = true;
                    }
                    else
                    {
                        Console.WriteLine("\n Another Checker Is Blocking Your Move");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\nyou can only move forward once per shot, and you can't move backwards");
                    Console.ReadKey();
                }
            }
            else if (player == "O")
            {
                if (player == "X")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player two can only move O's on the board");
                    Console.ReadKey();
                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == player | gameBg[moveRow, moveCol] == 'N')
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();
                }
                //checks if the selected row is less than moveRow as the checker can only move one row at a time
                else if (moveRow - row == 1 && row < moveRow)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "X" && gameBg[moveRow + 1, moveCol - 1].ToString() != "X")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = '\0';
                        gameBg[moveRow + 1, moveCol - 1] = Convert.ToChar(player);
                        moveComplete = true;

                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "X" && gameBg[moveRow + 1, moveCol + 1].ToString() != "X")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = '\0';
                        gameBg[moveRow + 1, moveCol + 1] = Convert.ToChar(player);
                        moveComplete = true;

                    }
                    // checks if the postion the player is moving to is a null character in the array
                    else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "\0")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = Convert.ToChar(player);
                        moveComplete = true;
                    }
                    else
                    {
                        Console.WriteLine("\n Another Checker Is Blocking Your Move");
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("\nyou can only move forward once per shot, and you can't move backwards");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\n you must select a tile with an X for player 1 and O for player 2");
            }
        }
    }
}
