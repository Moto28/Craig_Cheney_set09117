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
        public bool moveComplete = false;


        public void CheckAndUpdate(char[,] gameBg, int row, int col, int moveRow, int moveCol)
        {
            //take row and col passed in checks corrisponding location in array and sets the player as that location in array .ToString()
            player = gameBg[row, col].ToString();

            if (player == "X")
            {
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == player | gameBg[moveRow, moveCol] == 'N')
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();
                }
                //checks if the selected row is less than moveRow as the checker can only move one row at a time
                else if (row - moveRow == 1 && row > moveRow)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol - 1].ToString() != "O")
                    {
                        gameBg[row, col] = ' ';
                        gameBg[moveRow, moveCol] = ' ';
                        gameBg[moveRow - 1, moveCol - 2] = Convert.ToChar(player);
                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol + 1].ToString() != "O")
                    {
                        gameBg[row, col] = ' ';
                        gameBg[moveRow, moveCol] = ' ';
                        gameBg[moveRow - 1, moveCol + 1] = Convert.ToChar(player);
                    }
                    // checks if the postion the player is moving to is not a null character in the array
                    else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "\0" | gameBg[moveRow, moveCol].ToString() == " ")
                    {
                        gameBg[row, col] = ' ';
                        gameBg[moveRow, moveCol] = Convert.ToChar(player);
                    }
                    else
                    {
                        Console.WriteLine("\n Another Checker Is Blocking Your Move");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\nYou Can Only Move One Space at a Time");
                    Console.ReadKey();
                }
            }
            else if (player == "O")
            {
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == player | gameBg[moveRow, moveCol] == 'N')
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
                        gameBg[row, col] = ' ';
                        gameBg[moveRow, moveCol] = ' ';
                        gameBg[moveRow + 1, moveCol - 1] = Convert.ToChar(player);

                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "X" && gameBg[moveRow + 1, moveCol + 1].ToString() != "X")
                    {
                        gameBg[row, col] = ' ';
                        gameBg[moveRow, moveCol] = ' ';
                        gameBg[moveRow + 1, moveCol + 1] = Convert.ToChar(player);

                    }
                    else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "\0")
                    {
                        gameBg[row, col] = ' ';
                        gameBg[moveRow, moveCol] = Convert.ToChar(player);
                    }
                    else
                    {
                        Console.WriteLine("\n Another Checker Is Blocking Your Move");
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.WriteLine("\nYou Can Only Move One Space at a Time");
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
