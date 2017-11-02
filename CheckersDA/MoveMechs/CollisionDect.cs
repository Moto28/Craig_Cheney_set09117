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

        private string player;
        private bool moveComplete;
        private bool checkerTaken;
        public CollisionDect()
        {
            player = Player;
            moveComplete = MoveComplete;
            checkerTaken = CheckerTaken;
        }

        public string Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }
        }
        public bool MoveComplete
        {
            get
            {
                return moveComplete;
            }
            set
            {
                moveComplete = value;
            }
        }
        public bool CheckerTaken
        {
            get
            {
                return checkerTaken;
            }
            set
            {
                checkerTaken = value;
            }
        }


        public void CheckAndUpdate(char[,] gameBg, int row, int col, int moveRow, int moveCol, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            //resets move complete when method is restarted
            moveComplete = false;
            //take row and col passed in to check corrisponding location in array and sets the player as that location in array 
            player = gameBg[row, col].ToString();

            if (playerOne.PlayerChecker == "X" && playerOne.IsItMyTurn == true)
            {
                //checks if the player has selected the wrong checker
                if (gameBg[row, col].ToString() == "O")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player one can only move X's on the board");
                    Console.ReadKey();
                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == player | gameBg[moveRow, moveCol] == ' ')
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();
                }
                if (moveRow == 2 && gameBg[moveRow, moveCol] == '\0' || moveRow == 9 && gameBg[moveRow, moveCol] == '\0')
                {
                    gameBg[moveRow, moveCol] = 'K';
                    WriteFullLinePlayerOne('K'.ToString());
                }
                else if (moveRow == 9 && gameBg[moveRow, moveCol] == '\0' || moveRow == 9 && gameBg[moveRow, moveCol] == '\0')
                {
                    gameBg[moveRow, moveCol] = 'K';
                    WriteFullLinePlayerOne('K'.ToString());
                }
                //checks if the selected row is less than moveRow as the checker can only move one row at a time and the move is not backwards
                if (row - moveRow == 1 && row > moveRow)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol - 1].ToString() != "O")
                    {

                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = '\0';
                        gameBg[moveRow - 1, moveCol - 1] = Convert.ToChar(player);
                        checkerTaken = true;
                        playerOne.GetPlayerTurnCount();

                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "O" && gameBg[moveRow - 1, moveCol + 1].ToString() != "O")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = '\0';
                        gameBg[moveRow - 1, moveCol + 1] = Convert.ToChar(player);
                        checkerTaken = true;
                        playerOne.GetPlayerTurnCount();
                    }
                    // checks if the postion the player is moving to is a null character in the array
                    else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "\0")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = Convert.ToChar(player);
                        checkerTaken = true;
                        playerOne.GetPlayerTurnCount();
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
            else if (playerTwo.PlayerChecker == "O" && playerTwo.IsItMyTurn == true)
            {
                if (player == "X")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player two can only move O's on the board");
                    Console.ReadKey();

                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == player | gameBg[moveRow, moveCol] == 'N')
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();

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
                        checkerTaken = true;
                        playerTwo.GetPlayerTurnCount();
                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "X" && gameBg[moveRow + 1, moveCol + 1].ToString() != "X")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = '\0';
                        gameBg[moveRow + 1, moveCol + 1] = Convert.ToChar(player);
                        moveComplete = true;
                        checkerTaken = true;
                        playerTwo.GetPlayerTurnCount();
                    }
                    // checks if the postion the player is moving to is a null character in the array
                    else if (gameBg[row, col].ToString() == player && gameBg[moveRow, moveCol].ToString() == "\0")
                    {
                        gameBg[row, col] = '\0';
                        gameBg[moveRow, moveCol] = Convert.ToChar(player);
                        moveComplete = true;
                        checkerTaken = false;
                        playerTwo.GetPlayerTurnCount();
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

        public void WriteFullLinePlayerOne(string value)
        {
            //
            // This method writes an entire line to the console with the string.
            //           
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
                                                                        //
                                                                        // Reset the color.
                                                                        //
            Console.ResetColor();
        }
        public void WriteFullLinePlayerTwo(string value)
        {
            //
            // This method writes an entire line to the console with the string.
            //          
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1)); // <-- see note
                                                                        //
                                                                        // Reset the color.
                                                                        //
            Console.ResetColor();
        }
    }
}
