using System;
using CheckersDA.Players;

namespace CheckersDA.MoveMechs
{
    class CollisionDect
    {
        #region creates private varibles
        private string player;
        private string opponent;
        private bool moveComplete;
        private bool checkerTaken;
        private bool anotherMove;
        #endregion

        #region creates getteres and setters
        public CollisionDect()
        {
            player = Player;
            opponent = Opponent;
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
        public string Opponent
        {
            get
            {
                return opponent;
            }
            set
            {
                opponent = value;
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
        #endregion

        #region player movement
        public void CheckAndUpdate(string[,] gameBg, int row, int col, int moveRow, int moveCol, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            //takes row and col passed in to check corrisponding location in array and sets player as the object at the location in array 
            player = gameBg[row, col];
            //take moveRow and moveCol passed in to check corrisponding location in array and sets the opponent as that location in array 
            opponent = gameBg[moveRow, moveCol];

            #region playerOne checker movement
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

                    //checks if move is LEFT and the space ahead contians a checker or king 
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && gameBg[moveRow - 1, moveCol - 1] != "O ")
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol - 1] = player;
                        checkerTaken = true;

                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "O ")
                            playerOne.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kO")
                            playerOne.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
                        if (gameBg[moveRow - 1, moveCol - 1] == player && (gameBg[moveRow - 2, moveCol - 2] == "O " || gameBg[moveRow - 2, moveCol - 2] == "kO") && gameBg[moveRow - 3, moveCol - 3] == "\0 " && gameBg[moveRow - 4, moveCol - 4] != "N ")
                        {
                            anotherMove = true;
                            moveComplete = true;
                        }
                        else
                        {
                            anotherMove = false;
                            moveComplete = true;
                        }
                    }
                    //turns the players checker into a king if it get to the end of the board
                    else if (moveRow == 2 && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "kX";
                        anotherMove = false;
                        moveComplete = true;
                        //adds to player score for getting a king
                        playerOne.PlayerScore = +5;
                    }
                    // checks if move is right and space ahead contians a checkers or a king
                    else if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && gameBg[moveRow - 1, moveCol + 1] != "O ")
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol + 1] = player;
                        checkerTaken = true;
                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "O ")
                            playerOne.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kO")
                            playerOne.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
                        if (gameBg[moveRow - 1, moveCol + 1] == player && (gameBg[moveRow - 2, moveCol + 2] == "O " || gameBg[moveRow - 2, moveCol + 2] == "kO") && gameBg[moveRow - 3, moveCol + 3] == "\0 " && gameBg[moveRow - 4, moveCol + 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                            moveComplete = true;
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
                        //adds to player one score
                        playerOne.PlayerScore++;
                    }
                    //displays error message
                    else
                    {
                        Console.WriteLine("\n Another Checker Is Blocking Your Move");
                        Console.ReadKey();
                    }
                }
                //displays error message
                else
                {
                    Console.WriteLine("\nyou can only move forward once per shot, and you can't move backwards");
                    Console.ReadKey();
                }

            }
            #endregion

            #region playerTwo checker movement
            else if (player == "O " && playerTwo.IsItMyTurn == true)
            {
                //checks player has picked the right checker or king
                if (player == "X " || player == "kX")
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
                    //checks if move is left and checker or king
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && gameBg[moveRow + 1, moveCol - 1] != "X ")
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol - 1] = player;
                        checkerTaken = true;
                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "X ")
                            playerTwo.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kX")
                            playerTwo.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
                        if (gameBg[moveRow + 1, moveCol - 1] == player && (gameBg[moveRow + 2, moveCol + 2] == "X " || gameBg[moveRow + 2, moveCol + 2] == "kX") && gameBg[moveRow + 3, moveCol + 3] == "\0 " && gameBg[moveRow + 4, moveCol + 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                            moveComplete = true;
                        }
                    }
                    //checks if a checker has been moved to the bottom of the board and changes it to a king
                    else if (moveRow == 9 && gameBg[moveRow, moveCol] != "X " || moveRow == 9 && gameBg[moveRow, moveCol] == "kX ")
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "kO";
                        anotherMove = false;
                        moveComplete = true;
                        playerTwo.PlayerScore = +5;
                    }
                    // checks if move is right and checker of king 
                    else if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && gameBg[moveRow + 1, moveCol + 1] != "X ")
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol + 1] = player;
                        checkerTaken = true;
                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "X ")
                            playerTwo.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kX")
                            playerTwo.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
                        if (gameBg[moveRow + 1, moveCol - 1] == player && (gameBg[moveRow + 2, moveCol - 2] == "X " || gameBg[moveRow + 2, moveCol - 2] == "kX") && gameBg[moveRow + 3, moveCol - 3] == "\0 " && gameBg[moveRow + 4, moveCol - 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                            moveComplete = true;
                        }
                    }
                    // checks if the postion the player is moving to is a null character in the array
                    else if (gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        moveComplete = true;
                        checkerTaken = false;
                        anotherMove = false;
                        playerTwo.PlayerScore++;
                    }
                    //displays error message
                    else
                    {
                        Console.WriteLine("\n Another Checker Is Blocking Your Move");
                        Console.ReadKey();
                    }

                }
                //displys error message
                else
                {
                    Console.WriteLine("\nyou can only move forward once per shot, and you can't move backwards");
                    Console.ReadKey();
                }
            }
            #endregion

            #region playerOne King movement
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
                    //checks if move is left and the space ahead is a checker or a king
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && (gameBg[moveRow + 1, moveCol + 1] != "O " || gameBg[moveRow + 1, moveCol + 1] != "kO"))
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol - 1] = player;
                        checkerTaken = true;

                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "O ")
                            playerOne.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kO")
                            playerOne.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
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
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        moveComplete = true;
                        checkerTaken = false;
                        anotherMove = false;
                        playerOne.PlayerScore++;
                    }
                    //checks if move is right
                    if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && (gameBg[moveRow - 1, moveCol + 1] != "O " || gameBg[moveRow - 1, moveCol + 1] != "kO"))
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol + 1] = player;
                        checkerTaken = true;
                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "O ")
                            playerOne.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kO")
                            playerOne.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
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
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                        playerOne.PlayerScore++;
                    }

                }
                //checks if the checker is moving up the board************************************* 
                else if (row - moveRow == 1)
                {
                    //checks if move is left and the space ahead has a checker or a king 
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && (gameBg[moveRow - 1, moveCol - 1] != "O " || gameBg[moveRow - 1, moveCol - 1] != "kO"))
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol - 1] = player;
                        checkerTaken = true;
                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "O ")
                            playerOne.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kO")
                            playerOne.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
                        if (gameBg[moveRow - 1, moveCol - 1] == player && (gameBg[moveRow - 2, moveCol - 2] == "O " || gameBg[moveRow - 2, moveCol - 2] == "kO") && gameBg[moveRow - 3, moveCol - 3] == "\0 " && gameBg[moveRow - 4, moveCol - 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    // checks if the king has a space ahead of it
                    else if (moveCol < col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                        playerOne.PlayerScore++;
                    }
                    //checks if move is right
                    if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "O " || gameBg[moveRow, moveCol] == "kO") && (gameBg[moveRow - 1, moveCol + 1] != "O " || gameBg[moveRow - 1, moveCol + 1] != "kO"))
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol + 1] = player;
                        checkerTaken = true;

                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "O ")
                            playerOne.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kO")
                            playerOne.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
                        if (gameBg[moveRow - 1, moveCol + 1] == player && (gameBg[moveRow - 2, moveCol + 2] == "O " || gameBg[moveRow - 2, moveCol + 2] == "kO") && gameBg[moveRow - 3, moveCol + 3] == "\0 " && gameBg[moveRow - 4, moveCol + 4] != "N")
                        {
                            anotherMove = true;
                        }
                        else
                        {
                            anotherMove = false;
                        }
                    }
                    //checks if the king has a space ahead of it
                    else if (moveCol > col && gameBg[row, col] == player && gameBg[moveRow, moveCol] == "\0 ")
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                        playerOne.PlayerScore++;
                    }
                }
            }
            #endregion

            #region playerTwo King Movement
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
                    //checks if move is left and the space ahead is a checker or a king
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && (gameBg[moveRow + 1, moveCol + 1] != "X " || gameBg[moveRow + 1, moveCol + 1] != "kX"))
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol - 1] = player;
                        checkerTaken = true;
                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "X ")
                            playerTwo.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kX")
                            playerTwo.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
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
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        moveComplete = true;
                        checkerTaken = false;
                        anotherMove = false;
                        playerTwo.PlayerScore++;
                    }
                    //checks if move is right
                    if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && (gameBg[moveRow - 1, moveCol + 1] != "X " || gameBg[moveRow - 1, moveCol + 1] != "kX"))
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow + 1, moveCol + 1] = player;
                        checkerTaken = true;

                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "X ")
                            playerTwo.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kX")
                            playerTwo.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
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
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                        playerTwo.PlayerScore++;
                    }

                }
                //checks if the checker is moving up the board ***********************************************
                else if (row - moveRow == 1)
                {
                    //checks if move is left
                    if (moveCol < col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && (gameBg[moveRow - 1, moveCol - 1] != "X " || gameBg[moveRow - 1, moveCol - 1] != "kX"))
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol - 1] = player;
                        checkerTaken = true;

                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "X ")
                            playerTwo.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kX")
                            playerTwo.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
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
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                    }
                    //checks if move is right and a checker or king is ahead
                    if (moveCol > col && gameBg[row, col] == player && (gameBg[moveRow, moveCol] == "X " || gameBg[moveRow, moveCol] == "kX") && (gameBg[moveRow - 1, moveCol + 1] != "X " || gameBg[moveRow - 1, moveCol + 1] != "kX"))
                    {
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow - 1, moveCol + 1] = player;
                        checkerTaken = true;

                        //checks what check has been taken and adds the appropriate score
                        if (gameBg[moveRow, moveCol] == "X ")
                            playerTwo.PlayerScore = +2;
                        if (gameBg[moveRow, moveCol] == "kX")
                            playerTwo.PlayerScore = +4;

                        //checks if the player has another move they can make if they can't end thier turn if it can send the player back to the move input screen
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
                        //resets the players checker to new postion
                        gameBg[row, col] = "\0 ";
                        gameBg[moveRow, moveCol] = "\0 ";
                        gameBg[moveRow, moveCol] = player;
                        checkerTaken = true;
                        playerTwo.PlayerScore++;
                    }
                }
                else
                {
                    Console.WriteLine("\n you must select a tile with an X for player 1 and O for player 2");
                }
            }
            #endregion
        }
        #endregion
    }
}
