using CheckersDA.MoveConvertor;
using CheckersDA.MoveMechs;
using CheckersDA.Players;
using CheckersDA.ViewModels;
using System;

namespace CheckersDA.Game
{
    class GameLogic
    {
        MainMenu menu = new MainMenu();
        GameBoard game = new GameBoard();
        ForceMove move = new ForceMove();
        CollisionDect detection = new CollisionDect();
        IsInputValid valid = new IsInputValid();
        UndoMove undo = new UndoMove();

        private bool win;
        private char pickRow;
        private char pickCol;
        private char moveRow;
        private char moveCol;

        public GameLogic()
        {
            win = Win;
            pickRow = PickRow;
            pickCol = PickCol;
            moveRow = MoveRow;
            moveCol = MoveCol;
        }

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

        public void Logic(string[,] gameBg, PlayerOne playerOne, PlayerTwo playerTwo, WatchReplay watchReplay)
        {
            IsItWin(gameBg, playerOne, playerTwo);
            watchReplay.AddToQueue(gameBg);


            if (playerOne.IsItMyTurn == true)
            {
                game.Draw(gameBg, playerOne, playerTwo);

                valid.PickIsValid = false;
                valid.MoveIsValid = false;

                if (detection.AnotherMove == false && playerOne.PlayerTurnCount != 0)
                {
                    undo.UndoPlayerMove(gameBg, playerOne, playerTwo);

                }

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
                    move.ForceJumpUp(gameBg);
                    //adds one on for multi moves
                    playerOne.GetPlayerTurnCount();

                    Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerOne.PlayerName.ToUpper());
                    pickRow = Console.ReadKey().KeyChar;
                    Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                    pickCol = Console.ReadKey().KeyChar;
                    valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, playerTwo);
                }
                if (playerOne.IsItMyTurn == true && valid.PickIsValid == true)
                {
                    detection.MoveComplete = false;

                    if (move.MustPickRowAndCol.Count > 0)
                    {
                        int convertedPickCol = Convert.ToInt16(pickCol.ToString());

                        if (move.MustPickRowAndCol.Contains(pickRow.ToString() + convertedPickCol.ToString()) == true)
                        {
                            Console.WriteLine("\nEnter the Row you want to move to", playerOne.PlayerName);
                            moveRow = Console.ReadKey().KeyChar;
                            Console.WriteLine("\nEnter the Column you want to move to", playerOne.PlayerName);
                            moveCol = Console.ReadKey().KeyChar;
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
                        Console.WriteLine("\nEnter the Row you want to move to", playerOne.PlayerName);
                        moveRow = Console.ReadKey().KeyChar;
                        Console.WriteLine("\nEnter the Column you want to move to", playerOne.PlayerName);
                        moveCol = Console.ReadKey().KeyChar;
                        valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                    }
                }
                if (playerOne.IsItMyTurn == true && valid.MoveIsValid == true)
                {
                    if (move.MustMoveRowAndCol.Count > 0)
                    {
                        int convertedMoveCol = Convert.ToInt16(moveCol.ToString());

                        if (move.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                        {
                            Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                            Console.ReadKey();
                            undo.AddToUndoStack(gameBg);
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                            playerOne.GetPlayerTurnCount();
                            watchReplay.AddToQueue(gameBg);
                            undo.AddToRedoStack(gameBg);
                            game.Draw(gameBg, playerOne, playerTwo);
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
                        undo.AddToUndoStack(gameBg);
                        detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                        playerOne.GetPlayerTurnCount();
                        watchReplay.AddToQueue(gameBg);
                        undo.AddToRedoStack(gameBg);
                        game.Draw(gameBg, playerOne, playerTwo);
                    }
                }
                else
                {
                    detection.MoveComplete = false;
                }

            }
            //**************Player Two movement*****************************************************************************************************************
            else if (playerTwo.IsItMyTurn == true)
            {
                game.Draw(gameBg, playerOne, playerTwo);

                valid.PickIsValid = false;
                valid.MoveIsValid = false;


                if (detection.AnotherMove == false && playerTwo.PlayerTurnCount != 0)
                {
                    undo.UndoPlayerMove(gameBg, playerOne, playerTwo);
                }

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
                    move.ForceJumpDown(gameBg);
                    Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerTwo.PlayerName.ToUpper());
                    pickRow = Console.ReadKey().KeyChar;
                    Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                    pickCol = Console.ReadKey().KeyChar;
                    valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, playerTwo);
                }

                if (playerTwo.IsItMyTurn == true && valid.PickIsValid == true)
                {
                    detection.MoveComplete = false;

                    if (move.MustPickRowAndCol.Count > 0)
                    {
                        int convertedPickCol = Convert.ToInt16(pickCol.ToString());

                        if (move.MustPickRowAndCol.Contains(pickRow.ToString() + convertedPickCol.ToString()) == true)
                        {
                            Console.WriteLine("\nEnter the Row you want to move to", playerTwo.PlayerName);
                            moveRow = Console.ReadKey().KeyChar;
                            Console.WriteLine("\nEnter the Column you want to move to", playerTwo.PlayerName);
                            moveCol = Console.ReadKey().KeyChar;
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
                        valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                    }
                }
                else
                {
                    detection.MoveComplete = false;
                }
                if (playerTwo.IsItMyTurn == true && valid.MoveIsValid == true)
                {
                    if (move.MustMoveRowAndCol.Count > 0)
                    {
                        int convertedMoveCol = Convert.ToInt16(moveCol.ToString());

                        if (move.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                        {
                            Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                            Console.ReadKey();
                            undo.AddToUndoStack(gameBg);
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                            watchReplay.AddToQueue(gameBg);
                            undo.AddToRedoStack(gameBg);
                            game.Draw(gameBg, playerOne, playerTwo);
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
                        undo.AddToUndoStack(gameBg);
                        detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                        watchReplay.AddToQueue(gameBg);
                        undo.AddToRedoStack(gameBg);
                        game.Draw(gameBg, playerOne, playerTwo);
                    }
                }
            }
        }

        public void Logic(string[,] gameBg, PlayerOne playerOne, AiPlayer aiPlayer, WatchReplay watchReplay)
        {
            IsItWin(gameBg, playerOne, aiPlayer);
            watchReplay.AddToQueue(gameBg);


            if (playerOne.IsItMyTurn == true)
            {
                game.Draw(gameBg, playerOne, aiPlayer);

                valid.PickIsValid = false;
                valid.MoveIsValid = false;

                if (detection.AnotherMove == false && playerOne.PlayerTurnCount != 0)
                {
                    undo.UndoPlayerMove(gameBg, playerOne, aiPlayer);

                }

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
                    move.ForceJumpUp(gameBg);
                    //adds one on for multi moves
                    playerOne.GetPlayerTurnCount();

                    Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerOne.PlayerName.ToUpper());
                    pickRow = Console.ReadKey().KeyChar;
                    Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                    pickCol = Console.ReadKey().KeyChar;
                    valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, aiPlayer);
                }
                if (playerOne.IsItMyTurn == true && valid.PickIsValid == true)
                {
                    detection.MoveComplete = false;

                    if (move.MustPickRowAndCol.Count > 0)
                    {
                        int convertedPickCol = Convert.ToInt16(pickCol.ToString());

                        if (move.MustPickRowAndCol.Contains(pickRow.ToString() + convertedPickCol.ToString()) == true)
                        {
                            Console.WriteLine("\nEnter the Row you want to move to", playerOne.PlayerName);
                            moveRow = Console.ReadKey().KeyChar;
                            Console.WriteLine("\nEnter the Column you want to move to", playerOne.PlayerName);
                            moveCol = Console.ReadKey().KeyChar;
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
                        Console.WriteLine("\nEnter the Row you want to move to", playerOne.PlayerName);
                        moveRow = Console.ReadKey().KeyChar;
                        Console.WriteLine("\nEnter the Column you want to move to", playerOne.PlayerName);
                        moveCol = Console.ReadKey().KeyChar;
                        valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                    }
                }
                if (playerOne.IsItMyTurn == true && valid.MoveIsValid == true)
                {
                    if (move.MustMoveRowAndCol.Count > 0)
                    {
                        int convertedMoveCol = Convert.ToInt16(moveCol.ToString());

                        if (move.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                        {
                            Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                            Console.ReadKey();
                            undo.AddToUndoStack(gameBg);
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, aiPlayer);
                            playerOne.GetPlayerTurnCount();
                            watchReplay.AddToQueue(gameBg);
                            undo.AddToRedoStack(gameBg);
                            game.Draw(gameBg, playerOne, aiPlayer);
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
                        undo.AddToUndoStack(gameBg);
                        detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, aiPlayer);
                        playerOne.GetPlayerTurnCount();
                        watchReplay.AddToQueue(gameBg);
                        undo.AddToRedoStack(gameBg);
                        game.Draw(gameBg, playerOne, aiPlayer);
                    }
                }
                else
                {
                    detection.MoveComplete = false;
                }

            }
            //**************Player Two movement*****************************************************************************************************************
            else if (aiPlayer.IsItMyTurn == true)
            {
                game.Draw(gameBg, playerOne, aiPlayer);

                valid.PickIsValid = false;
                valid.MoveIsValid = false;


                if (detection.AnotherMove == false && aiPlayer.PlayerTurnCount != 0)
                {
                    undo.UndoPlayerMove(gameBg, playerOne, aiPlayer);
                }

                if (detection.CheckerTaken == true && detection.AnotherMove == false || detection.MoveComplete == true && detection.AnotherMove == false)
                {
                    detection.CheckerTaken = false;
                    aiPlayer.YourTurn();
                    playerOne.MyTurn();
                    game.Draw(gameBg, playerOne, aiPlayer);
                }
                else
                {
                    Console.Clear();
                    game.Draw(gameBg, playerOne, aiPlayer);
                    move.ForceJumpDown(gameBg);
                    Console.WriteLine("\n\n{0}'s turn", aiPlayer.PlayerName.ToUpper());
                    valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, aiPlayer);
                }

                if (aiPlayer.IsItMyTurn == true && valid.PickIsValid == true)
                {
                    detection.MoveComplete = false;

                    if (move.MustPickRowAndCol.Count > 0)
                    {
                        int convertedPickCol = Convert.ToInt16(pickCol.ToString());

                        if (move.MustPickRowAndCol.Contains(pickRow.ToString() + convertedPickCol.ToString()) == true)
                        {
                            Console.WriteLine("\n\n{0}'s turn", aiPlayer.PlayerName.ToUpper());
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
                        Console.WriteLine("\n\n{0}'s turn", aiPlayer.PlayerName.ToUpper());
                        valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                    }
                }
                else
                {
                    detection.MoveComplete = false;
                }
                if (aiPlayer.IsItMyTurn == true && valid.MoveIsValid == true)
                {
                    if (move.MustMoveRowAndCol.Count > 0)
                    {
                        int convertedMoveCol = Convert.ToInt16(moveCol.ToString());

                        if (move.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                        {
                            Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                            Console.ReadKey();
                            undo.AddToUndoStack(gameBg);
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, aiPlayer);
                            watchReplay.AddToQueue(gameBg);
                            undo.AddToRedoStack(gameBg);
                            game.Draw(gameBg, playerOne, aiPlayer);
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
                        undo.AddToUndoStack(gameBg);
                        detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, aiPlayer);
                        watchReplay.AddToQueue(gameBg);
                        undo.AddToRedoStack(gameBg);
                        game.Draw(gameBg, playerOne, aiPlayer);
                    }
                }
            }
        }
        public void IsItWin(string[,] gameBg, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            playerOne.PlayerCheckerCount = 0;
            playerTwo.PlayerCheckerCount = 0;

            foreach (var checker in gameBg)
            {
                if (checker == "X " || checker == "kX")
                {
                    playerOne.PlayerCheckerCount++;
                    Console.WriteLine("{0}", playerOne.PlayerCheckerCount);
                }
                else if (checker == "O " || checker == "kO")
                {
                    playerTwo.PlayerCheckerCount++;
                    Console.WriteLine("{0}", playerTwo.PlayerCheckerCount);
                }
            }
            if (playerOne.PlayerCheckerCount == 0)
            {
                Console.WriteLine("Player One wins");
                win = true;
            }
            else if (playerTwo.PlayerCheckerCount == 0)
            {
                Console.WriteLine("Player Two wins");
                win = true;
            }
        }
    }
}



