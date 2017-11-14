using CheckersDA.MoveConvertor;
using CheckersDA.MoveMechs;
using CheckersDA.Players;
using CheckersDA.ViewModels;
using System;

namespace CheckersDA.Game
{
    class GameLogic
    {
        #region instantiate's objects used by the class
        MainMenu menu = new MainMenu();
        GameBoard game = new GameBoard();
        ForceMove move = new ForceMove();
        CollisionDect detection = new CollisionDect();
        IsInputValid valid = new IsInputValid();
        UndoMove undo = new UndoMove();
        #endregion

        #region private variables
        private bool win;
        private char pickRow;
        private char pickCol;
        private char moveRow;
        private char moveCol;
        #endregion

        #region Constructor
        public GameLogic()
        {
            win = Win;
            pickRow = PickRow;
            pickCol = PickCol;
            moveRow = MoveRow;
            moveCol = MoveCol;
        }
        #endregion

        #region getters and setters
        public bool Win
        {
            get
            {
                return win;
            }
            set
            {
                win = value;
            }
        }
        public char PickRow
        {
            get
            {
                return pickRow;
            }
            set
            {
                pickRow = value;
            }
        }
        public char PickCol
        {
            get
            {
                return pickCol;
            }
            set
            {
                pickCol = value;
            }
        }
        public char MoveRow
        {
            get
            {
                return moveRow;
            }
            set
            {
                moveRow = value;
            }
        }
        public char MoveCol
        {
            get
            {
                return moveCol;
            }
            set
            {
                moveCol = value;
            }
        }
        #endregion

        #region human vs human game logic
        public void Logic(string[,] gameBg, PlayerOne playerOne, PlayerTwo playerTwo, WatchReplay watchReplay)
        {
            //checks if there any checkers left on the board
            IsItWin(gameBg, playerOne, playerTwo);
            //adds first move to replay
            watchReplay.AddToQueue(gameBg);

            //checks if its players one turn
            if (playerOne.IsItMyTurn == true)
            {
                //draws the gameboard
                game.Draw(gameBg, playerOne, playerTwo);

                //sets pickIsValid and MoveIsValid
                valid.PickIsValid = false;
                valid.MoveIsValid = false;

                //checks if if a checkertaken is true and anothermove is false or Movecomplete is true and anotherMove is false... checks if the players turn has ended then passes to the next player
                if (detection.CheckerTaken == true && detection.AnotherMove == false || detection.MoveComplete == true && detection.AnotherMove == false)
                {
                    detection.CheckerTaken = false;
                    playerOne.YourTurn();
                    playerTwo.MyTurn();
                    game.Draw(gameBg, playerOne, playerTwo);

                }
                else
                {
                    Console.Clear();
                    game.Draw(gameBg, playerOne, playerTwo);
                    //checks if the player has anyforce moves to make
                    move.ForceJumpPlayerOne(gameBg);
                    //gets players move input
                    Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerOne.PlayerName.ToUpper());
                    pickRow = Console.ReadKey().KeyChar;
                    Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                    pickCol = Console.ReadKey().KeyChar;
                    //checks if the player input is valid
                    valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, playerTwo);
                }
                //checks if player pick row and column is valid
                if (playerOne.IsItMyTurn == true && valid.PickIsValid == true)
                {
                    detection.MoveComplete = false;

                    //checks if the force move list has any elements
                    if (move.MustPickRowAndCol.Count > 0)
                    {
                        int convertedPickCol = Convert.ToInt16(pickCol.ToString());

                        //checks if the player pick input is contained in the list
                        if (move.MustPickRowAndCol.Contains(pickRow.ToString() + convertedPickCol.ToString()) == true)
                        {
                            Console.WriteLine("\nEnter the Row you want to move to", playerOne.PlayerName);
                            moveRow = Console.ReadKey().KeyChar;
                            Console.WriteLine("\nEnter the Column you want to move to", playerOne.PlayerName);
                            moveCol = Console.ReadKey().KeyChar;
                            //checks if the player input is valid
                            valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                        }
                        else
                        {
                            Console.WriteLine("\nyou must must pick one of the moves in the list above");
                            Console.ReadKey();
                        }

                    }
                    //checks if the list contains any values
                    else
                    {
                        Console.WriteLine("\nEnter the Row you want to move to", playerOne.PlayerName);
                        moveRow = Console.ReadKey().KeyChar;
                        Console.WriteLine("\nEnter the Column you want to move to", playerOne.PlayerName);
                        moveCol = Console.ReadKey().KeyChar;
                        //checks if the player input is valid
                        valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                    }
                }
                //checks if playerOne and moveIsValid  is true
                if (playerOne.IsItMyTurn == true && valid.MoveIsValid == true)
                {
                    //checks if the list contains any values
                    if (move.MustMoveRowAndCol.Count > 0)
                    {
                        int convertedMoveCol = Convert.ToInt16(moveCol.ToString());

                        //checks if the players move input is contained in the list
                        if (move.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                        {
                            Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                            Console.ReadKey();
                            //adds gameBg move to stack
                            undo.AddToUndoStack(gameBg);
                            //updates the gameboard
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                            //adds gameBg move to Queue
                            watchReplay.AddToQueue(gameBg);
                            //adds gameBg to redo stack
                            undo.AddToRedoStack(gameBg);
                            //redraws the gameboard
                            game.Draw(gameBg, playerOne, playerTwo);

                            //if the players move is complete and asks if they want to undo thier move
                            if (detection.AnotherMove == false && playerOne.PlayerTurnCount != 0)
                            {
                                undo.UndoPlayerMove(gameBg, playerOne, playerTwo);

                            }
                        }
                        //if the move is not in list shows error message
                        else
                        {
                            Console.WriteLine("you must select one of the moves above");
                            Console.ReadKey();
                            detection.MoveComplete = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                        Console.ReadKey();
                        //adds gameBg move to stack
                        undo.AddToUndoStack(gameBg);
                        //updates the gameboard
                        detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                        //adds gameBg move to Queue
                        watchReplay.AddToQueue(gameBg);
                        //adds gameBg to redo stack
                        undo.AddToRedoStack(gameBg);
                        //redraws the gameboard
                        game.Draw(gameBg, playerOne, playerTwo);

                        //if the players move is complete and asks if they want to undo thier move
                        if (detection.AnotherMove == false && playerOne.PlayerTurnCount != 0)
                        {
                            undo.UndoPlayerMove(gameBg, playerOne, playerTwo);

                        }
                    }
                }
                else
                {
                    detection.MoveComplete = false;
                }
            }
            //checks if it's player twos turn
            else if (playerTwo.IsItMyTurn == true)
            {
                //redraws gameboard
                game.Draw(gameBg, playerOne, playerTwo);

                //set bools to false
                valid.PickIsValid = false;
                valid.MoveIsValid = false;

                //checks if if a checkertaken is true and anothermove is false or Movecomplete is true and anotherMove is false... checks if the players turn has ended then passes to the next player
                if (detection.CheckerTaken == true && detection.AnotherMove == false || detection.MoveComplete == true && detection.AnotherMove == false)
                {
                    detection.CheckerTaken = false;
                    playerTwo.YourTurn();
                    playerOne.MyTurn();
                    game.Draw(gameBg, playerOne, playerTwo);
                }
                else
                {
                    Console.Clear();
                    game.Draw(gameBg, playerOne, playerTwo);
                    //checks if player has any force move to complete
                    move.ForceJumpPlayerTwo(gameBg);
                    Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerTwo.PlayerName.ToUpper());
                    pickRow = Console.ReadKey().KeyChar;
                    Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                    pickCol = Console.ReadKey().KeyChar;
                    //checks if player input is valid
                    valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, playerTwo);
                }
                //checks if player two move and pickIsValid is true
                if (playerTwo.IsItMyTurn == true && valid.PickIsValid == true)
                {
                    detection.MoveComplete = false;

                    //checks if list contains any values
                    if (move.MustPickRowAndCol.Count > 0)
                    {
                        int convertedPickCol = Convert.ToInt16(pickCol.ToString());
                        //checks if the players move input is contained in the list
                        if (move.MustPickRowAndCol.Contains(pickRow.ToString() + convertedPickCol.ToString()) == true)
                        {
                            Console.WriteLine("\nEnter the Row you want to move to", playerTwo.PlayerName);
                            moveRow = Console.ReadKey().KeyChar;
                            Console.WriteLine("\nEnter the Column you want to move to", playerTwo.PlayerName);
                            moveCol = Console.ReadKey().KeyChar;
                            //checks if move is valid
                            valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                        }
                        else
                        {
                            Console.WriteLine("\nyou must must pick one of the moves in the list above");
                            Console.ReadKey();
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nEnter the Row you want to move to", playerTwo.PlayerName);
                        moveRow = Console.ReadKey().KeyChar;
                        Console.WriteLine("\nEnter the Column you want to move to", playerTwo.PlayerName);
                        moveCol = Console.ReadKey().KeyChar;
                        //checks if move is valid
                        valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                    }
                }
                else
                {
                    detection.MoveComplete = false;
                }
                //checks if playerTwo and moveIsValid is true
                if (playerTwo.IsItMyTurn == true && valid.MoveIsValid == true)
                {
                    //checks if list contains any values
                    if (move.MustMoveRowAndCol.Count > 0)
                    {
                        int convertedMoveCol = Convert.ToInt16(moveCol.ToString());
                        //checks if player input matchs the list
                        if (move.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                        {
                            Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                            Console.ReadKey();
                            //adds gameBg move to stack
                            undo.AddToUndoStack(gameBg);
                            //updates the gameboard
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                            //adds gameBg move to Queue
                            watchReplay.AddToQueue(gameBg);
                            //adds gameBg to redo stack
                            undo.AddToRedoStack(gameBg);
                            //redraws the gameboard
                            game.Draw(gameBg, playerOne, playerTwo);
                            if (detection.AnotherMove == false && playerOne.PlayerTurnCount != 0)
                            {
                                undo.UndoPlayerMove(gameBg, playerOne, playerTwo);

                            }
                        }
                        else
                        {
                            Console.WriteLine("you must select one of the moves above");
                            Console.ReadKey();
                            detection.MoveComplete = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                        Console.ReadKey();
                        //adds gameBg move to stack
                        undo.AddToUndoStack(gameBg);
                        //updates the gameboard
                        detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                        //adds gameBg move to Queue
                        watchReplay.AddToQueue(gameBg);
                        //adds gameBg to redo stack
                        undo.AddToRedoStack(gameBg);
                        //redraws the gameboard
                        game.Draw(gameBg, playerOne, playerTwo);

                        //checks if move completed and asks if they want to undo thier move
                        if (detection.AnotherMove == false && playerOne.PlayerTurnCount != 0)
                        {
                            undo.UndoPlayerMove(gameBg, playerOne, playerTwo);

                        }
                    }
                }
            }
        }
        #endregion

        #region human vs computer logic
        public void Logic(string[,] gameBg, PlayerOne playerOne, AiPlayer aiPlayer, WatchReplay watchReplay)
        {
            //checks if there any checkers left on the board
            IsItWin(gameBg, playerOne, aiPlayer);
            //adds first move to replay
            watchReplay.AddToQueue(gameBg);

            //checks if its players one turn
            if (playerOne.IsItMyTurn == true)
            {
                //draws the gameboard
                game.Draw(gameBg, playerOne, aiPlayer);

                //sets pickIsValid and MoveIsValid
                valid.PickIsValid = false;
                valid.MoveIsValid = false;

                //checks if if a checkertaken is true and anothermove is false or Movecomplete is true and anotherMove is false... checks if the players turn has ended then passes to the next player
                if (detection.CheckerTaken == true && detection.AnotherMove == false || detection.MoveComplete == true && detection.AnotherMove == false)
                {
                    detection.CheckerTaken = false;
                    playerOne.YourTurn();
                    aiPlayer.MyTurn();
                    game.Draw(gameBg, playerOne, aiPlayer);

                }
                else
                {
                    Console.Clear();
                    game.Draw(gameBg, playerOne, aiPlayer);
                    //checks if the player has anyforce moves to make
                    move.ForceJumpPlayerOne(gameBg);
                    //gets players move input
                    Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerOne.PlayerName.ToUpper());
                    pickRow = Console.ReadKey().KeyChar;
                    Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                    pickCol = Console.ReadKey().KeyChar;
                    //checks if the player input is valid
                    valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, aiPlayer);
                }
                //checks if player pick row and column is valid
                if (playerOne.IsItMyTurn == true && valid.PickIsValid == true)
                {
                    detection.MoveComplete = false;

                    //checks if the force move list has any elements
                    if (move.MustPickRowAndCol.Count > 0)
                    {
                        int convertedPickCol = Convert.ToInt16(pickCol.ToString());

                        //checks if the player pick input is contained in the list
                        if (move.MustPickRowAndCol.Contains(pickRow.ToString() + convertedPickCol.ToString()) == true)
                        {
                            Console.WriteLine("\nEnter the Row you want to move to", playerOne.PlayerName);
                            moveRow = Console.ReadKey().KeyChar;
                            Console.WriteLine("\nEnter the Column you want to move to", playerOne.PlayerName);
                            moveCol = Console.ReadKey().KeyChar;
                            //checks if the player input is valid
                            valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                        }
                        else
                        {
                            Console.WriteLine("\nyou must must pick one of the moves in the list above");
                            Console.ReadKey();
                        }

                    }
                    //checks if the list contains any values
                    else
                    {
                        Console.WriteLine("\nEnter the Row you want to move to", playerOne.PlayerName);
                        moveRow = Console.ReadKey().KeyChar;
                        Console.WriteLine("\nEnter the Column you want to move to", playerOne.PlayerName);
                        moveCol = Console.ReadKey().KeyChar;
                        //checks if the player input is valid
                        valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                    }
                }
                //checks if playerOne and moveIsValid  is true
                if (playerOne.IsItMyTurn == true && valid.MoveIsValid == true)
                {
                    //checks if the list contains any values
                    if (move.MustMoveRowAndCol.Count > 0)
                    {
                        int convertedMoveCol = Convert.ToInt16(moveCol.ToString());

                        //checks if the players move input is contained in the list
                        if (move.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                        {
                            Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                            Console.ReadKey();
                            //adds gameBg move to stack
                            undo.AddToUndoStack(gameBg);
                            //updates the gameboard
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, aiPlayer);
                            //adds gameBg move to Queue
                            watchReplay.AddToQueue(gameBg);
                            //adds gameBg to redo stack
                            undo.AddToRedoStack(gameBg);
                            //redraws the gameboard
                            game.Draw(gameBg, playerOne, aiPlayer);

                            //if the players move is complete and asks if they want to undo thier move
                            if (detection.AnotherMove == false && playerOne.PlayerTurnCount != 0)
                            {
                                undo.UndoPlayerMove(gameBg, playerOne, aiPlayer);

                            }
                        }
                        //if the move is not in list shows error message
                        else
                        {
                            Console.WriteLine("you must select one of the moves above");
                            Console.ReadKey();
                            detection.MoveComplete = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                        Console.ReadKey();
                        //adds gameBg move to stack
                        undo.AddToUndoStack(gameBg);
                        //updates the gameboard
                        detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, aiPlayer);
                        //adds gameBg move to Queue
                        watchReplay.AddToQueue(gameBg);
                        //adds gameBg to redo stack
                        undo.AddToRedoStack(gameBg);
                        //redraws the gameboard
                        game.Draw(gameBg, playerOne, aiPlayer);

                        //if the players move is complete and asks if they want to undo thier move
                        if (detection.AnotherMove == false && playerOne.PlayerTurnCount != 0)
                        {
                            undo.UndoPlayerMove(gameBg, playerOne, aiPlayer);

                        }
                    }
                }
                else
                {
                    detection.MoveComplete = false;
                }
            }
            //**************ai player movement*****************************************************************************************************************
            else if (aiPlayer.IsItMyTurn == true)
            {
                //ai checks if it can move any checkers
                aiPlayer.AvailableMoves(gameBg);
                //randomly picks a move from one of it lists
                aiPlayer.PickMove();
                //converts the move to row and col format
                aiPlayer.CovertMove();
                //ai player makes the move
                aiPlayer.MakeMove(gameBg);
                //redraws the board
                game.Draw(gameBg, playerOne, aiPlayer);
                //ends ai players turn
                aiPlayer.IsItMyTurn = false;
                //starts playerOnes turn
                playerOne.IsItMyTurn = true;
            }
        }
        #endregion

        #region checks for a win
        public void IsItWin(string[,] gameBg, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            playerOne.PlayerCheckerCount = 0;
            playerTwo.PlayerCheckerCount = 0;

            //checks the array for playerOne checkers
            foreach (var checker in gameBg)
            {
                if (checker == "X " || checker == "kX")
                {
                    //adds one everytime it finds a checker
                    playerOne.PlayerCheckerCount++;
                }
                //checks the array for playerTwo checkers
                else if (checker == "O " || checker == "kO")
                {
                    //adds one everytime it finds a checker
                    playerTwo.PlayerCheckerCount++;
                }
            }
            //if no playerOne checkers found 
            if (playerOne.PlayerCheckerCount == 0)
            {
                //set win to true
                win = true;
            }
            //if no playerTwo checkers found 
            else if (playerTwo.PlayerCheckerCount == 0)
            {
                //set win to true
                win = true;
            }
        }
        #endregion
    }
}



