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
        private bool anotherMove;
        public CollisionDect()
        {
            player = Player;
            moveComplete = MoveComplete;
            checkerTaken = CheckerTaken;
            anotherMove = AnotherMove;
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
        public bool AnotherMove
        {
            get
            {
                return anotherMove;
            }
            set
            {
                anotherMove = value;
            }
        }

        public void CheckAndUpdate(string[,] gameBg, int row, int col, int moveRow, int moveCol, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            //take row and col passed in to check corrisponding location in array and sets the player as that location in array 
            player = gameBg[row, col];
            //**************Player One Movement**************
            if (player == "X " && playerOne.IsItMyTurn == true)
            {
                //checks if the player has selected the wrong checker
                if (gameBg[row, col] == "O " | gameBg[row, col] == "kO")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player one can only move X's or kX on the board");
                    Console.ReadKey();
                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col] == player && gameBg[moveRow, moveCol] == player || gameBg[row, col] == player && gameBg[moveRow, moveCol] == "N")
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();
                }
                //checks if the selected row is less than moveRow as the checker can only move one row at a time and the move is not backwards
                if (row - moveRow == 1 && row > moveRow)
                {

                    //checks if move is left
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && gameBg[moveRow - 1, moveCol - 1] != "O ")
                    {

                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol - 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow - 1, moveCol - 1] == player && (gameBg[moveRow - 2, moveCol - 2] == "O " || gameBg[moveRow - 2, moveCol - 2] == "kO") && gameBg[moveRow - 3, moveCol - 3] == "\0 " && gameBg[moveRow - 4, moveCol - 4] != "N ")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    else if (moveRow == 2 && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "kX";
                        anotherMove = false;
                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && gameBg[moveRow - 1, moveCol + 1] != "O ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol + 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow - 1, moveCol + 1] == player && (gameBg[moveRow - 2, moveCol + 2] == "O " || gameBg[moveRow - 2, moveCol + 2] == "kO") && gameBg[moveRow - 3, moveCol + 3] == "\0 " && gameBg[moveRow - 4, moveCol + 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    // checks if the postion the player is moving to is a null character in the array
                    else if (gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        moveComplete = true;
                        checkerTaken = false;
                        anotherMove = false;
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
            //**************Player Two Movement**************
            else if (player == "O " && playerTwo.IsItMyTurn == true)
            {
                if (player == "X ")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player two can only move O's on the board");
                    Console.ReadKey();

                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col] == player && gameBg[moveRow, moveCol] == player | gameBg[moveRow, moveCol] == "N")
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();

                }
                //checks if the selected row is less than moveRow as the checker can only move one row at a time
                if (moveRow - row == 1 && row < moveRow)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && gameBg[moveRow + 1, moveCol - 1] != "X ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol - 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow + 1, moveCol - 1] == player && (gameBg[moveRow + 2, moveCol + 2] == "X " || gameBg[moveRow + 2, moveCol + 2] == "kX") && gameBg[moveRow + 3, moveCol + 3] == "\0 " && gameBg[moveRow + 4, moveCol + 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    else if (moveRow == 9 && gameBg[moveRow, moveCol] == "\0 " || moveRow == 9 && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[moveRow, moveCol] = "kO";
                        anotherMove = false;
                    }
                    // checks if move is right
                    else if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && gameBg[moveRow + 1, moveCol + 1] != "X ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol + 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow + 1, moveCol - 1] == player && (gameBg[moveRow + 2, moveCol - 2] == "X " || gameBg[moveRow + 2, moveCol - 2] == "kX") && gameBg[moveRow + 3, moveCol - 3] == "\0 " && gameBg[moveRow + 4, moveCol - 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    // checks if the postion the player is moving to is a null character in the array
                    else if (gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        moveComplete = true;
                        checkerTaken = false;
                        anotherMove = false;
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
            //**************Player One King Movement**************
            else if (player == "kX" && playerOne.IsItMyTurn == true)
            {

                //checks if the player has selected the wrong checker
                if (gameBg[row, col] == "O " | gameBg[row, col] == "kO")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player one can only move X's or kX on the board");
                    Console.ReadKey();
                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col] == player && gameBg[moveRow, moveCol] == player || gameBg[row, col] == player && gameBg[moveRow, moveCol] == "N")
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();
                }
                //checks if the checker is moving down the board 
                if (moveRow - row == 1)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && (gameBg[moveRow + 1, moveCol + 1] != "O " || gameBg[moveRow + 1, moveCol + 1] != "kO"))
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol - 1] = player;
                        checkerTaken = true;

                        if (gameBg[moveRow + 1, moveCol + 1] == player && (gameBg[moveRow + 2, moveCol + 2] == "O " || gameBg[moveRow + 2, moveCol + 2] == "kO") && gameBg[moveRow + 3, moveCol + 3] == "\0 " && gameBg[moveRow + 4, moveCol + 4] == "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    else if (moveCol < col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        moveComplete = true;
                        checkerTaken = false;
                        anotherMove = false;
                    }
                    //checks if move is right
                    if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && (gameBg[moveRow - 1, moveCol + 1] != "O " || gameBg[moveRow - 1, moveCol + 1] != "kO"))
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol + 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow + 1, moveCol - 1] == player && (gameBg[moveRow + 2, moveCol - 2] == "O " || gameBg[moveRow + 2, moveCol - 2] == "kO") && gameBg[moveRow + 3, moveCol - 3] != "\0 " && gameBg[moveRow + 4, moveCol - 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }

                    }
                    else if (moveCol > col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                    }

                }
                //checks if the checker is moving up the board 
                else if (row - moveRow == 1)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && (gameBg[moveRow - 1, moveCol - 1] != "O " || gameBg[moveRow - 1, moveCol - 1] != "kO"))
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol - 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow - 1, moveCol - 1] == player && (gameBg[moveRow - 2, moveCol - 2] == "O " || gameBg[moveRow - 2, moveCol - 2] == "kO") && gameBg[moveRow - 3, moveCol - 3] == "\0 " && gameBg[moveRow - 4, moveCol - 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    else if (moveCol < col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                    }
                    //checks if move is right
                    if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && (gameBg[moveRow - 1, moveCol + 1] != "O " || gameBg[moveRow - 1, moveCol + 1] != "kO"))
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol + 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow - 1, moveCol + 1] == player && (gameBg[moveRow - 2, moveCol + 2] == "O " || gameBg[moveRow - 2, moveCol + 2] == "kO") && gameBg[moveRow - 3, moveCol + 3] == "\0 " && gameBg[moveRow - 4, moveCol + 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    else if (moveCol > col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                    }
                }
            }
            //**************Player Two King Movement***************
            else if (player == "kO" && playerTwo.IsItMyTurn == true)
            {
                //checks if the player has selected the wrong checker
                if (gameBg[row, col] == "X " | gameBg[row, col] == "kX")
                {
                    Console.WriteLine("you can only move your assigned checker e.g. Player one can only move X's or kX on the board");
                    Console.ReadKey();
                }
                //checks if the selected row and col in array is not the same and the move row and col and if the array has a N stored at that location
                if (gameBg[row, col] == player && gameBg[moveRow, moveCol] == player || gameBg[row, col] == player && gameBg[moveRow, moveCol] == "N")
                {
                    Console.WriteLine("\nSorry thats not a legal move press enter to try again");
                    Console.ReadKey();
                }
                //checks if the checker is moving down the board 
                if (moveRow - row == 1)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && (gameBg[moveRow + 1, moveCol + 1] != "X " || gameBg[moveRow + 1, moveCol + 1] != "kX"))
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol - 1] = player;
                        checkerTaken = true;

                        if (gameBg[moveRow + 1, moveCol + 1] == player && (gameBg[moveRow + 2, moveCol + 2] == "X " || gameBg[moveRow + 2, moveCol + 2] == "kX") && gameBg[moveRow + 3, moveCol + 3] == "\0 " && gameBg[moveRow + 4, moveCol + 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    else if (moveCol < col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        moveComplete = true;
                        checkerTaken = false;
                        anotherMove = false;
                    }
                    //checks if move is right
                    if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && (gameBg[moveRow - 1, moveCol + 1] != "X " || gameBg[moveRow - 1, moveCol + 1] != "kX"))
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol + 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow + 1, moveCol - 1] == player && (gameBg[moveRow + 2, moveCol - 2] == "X " || gameBg[moveRow + 2, moveCol - 2] == "kX") && gameBg[moveRow + 3, moveCol - 3] == "\0 " && gameBg[moveRow + 4, moveCol - 4] == "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }

                    }
                    else if (moveCol > col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                    }

                }
                //checks if the checker is moving up the board 
                else if (row - moveRow == 1)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && (gameBg[moveRow - 1, moveCol - 1] != "X " || gameBg[moveRow - 1, moveCol - 1] != "kX"))
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol - 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow - 1, moveCol - 1] == player && (gameBg[moveRow - 2, moveCol - 2] == "X " || gameBg[moveRow - 2, moveCol - 2] == "kX") && gameBg[moveRow - 3, moveCol - 3] == "\0 " && gameBg[moveRow - 4, moveCol - 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    else if (moveCol < col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                    }
                    //checks if move is right
                    if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && (gameBg[moveRow - 1, moveCol + 1] != "X " || gameBg[moveRow - 1, moveCol + 1] != "kX"))
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol + 1] = player;
                        checkerTaken = true;
                        if (gameBg[moveRow - 1, moveCol + 1] == player && (gameBg[moveRow - 2, moveCol + 2] == "X " || gameBg[moveRow - 2, moveCol + 2] == "kX") && gameBg[moveRow - 3, moveCol + 3] == "\0 " && gameBg[moveRow - 4, moveCol + 4] == "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    else if (moveCol > col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                    }
                }
                else
                {
                    Console.WriteLine("\n you must select a tile with an X for player 1 and O for player 2");
                }
            }
        }
    }
}
