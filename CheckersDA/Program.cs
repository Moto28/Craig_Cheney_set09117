using System;
using CheckersDA.ViewModels;
using CheckersDA.MoveMechs;
using CheckersDA.MoveConvertor;
using CheckersDA.Players;


namespace CheckersDA
{
    class Program
    {
        static string[,] gameBg = new string[14, 14];
        static bool win;
        static char pickRow;
        static char pickCol;
        static char moveRow;
        static char moveCol;


        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            GameBackGround backGround = new GameBackGround();
            GameBoard game = new GameBoard();
            ForceMove move = new ForceMove();
            CollisionDect detection = new CollisionDect();
            IsInputValid valid = new IsInputValid();
            PlayerOne playerOne = new PlayerOne();
            PlayerTwo playerTwo = new PlayerTwo();
            UndoMove undo = new UndoMove();

            Console.Title = "Checkers";

            switch (menu.SwitchMenuSel)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n                                            you have selected a 1 player game");
                    backGround.Objects(gameBg);
                    playerOne.GetPlayerName();
                    game.Draw(gameBg, playerOne, playerTwo);
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("                                                     you have selected a 2 player game");
                    backGround.Objects(gameBg);
                    playerOne.GetPlayerName();
                    playerTwo.GetPlayerName();
                    game.Draw(gameBg, playerOne, playerTwo);
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("                                                    you have selected to load a game");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.WriteLine("                                                    you have selected to watch a previously played game");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.WriteLine("                                                    you have chosen to quit");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("invalid menu selection");
                    break;
            }

            //creates a while loop that draws the board until the win condition is met. it then takes user input to passes it to IsInputValid then CollisionDect if the input is valid passes move to next player 
            while (!win)
            {
                game.Draw(gameBg, playerOne, playerTwo);

                if (playerOne.IsItMyTurn == true)
                {
                    valid.PickIsValid = false;
                    valid.MoveIsValid = false;
                    move.ForceJumpUp(gameBg);
                    playerOne.SetPlayerTimer();

                    if (detection.CheckerTaken == true && detection.AnotherMove == false || detection.MoveComplete == true && detection.AnotherMove == false)
                    {
                        detection.CheckerTaken = false;
                        playerOne.YourTurn();
                        playerTwo.MyTurn();
                        game.Draw(gameBg, playerOne, playerTwo);
                    }
                    else
                    {
                        if (detection.MoveComplete == true)
                        {
                            undo.UndoPlayerMove(gameBg, detection.Player, detection.Opponent, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol);
                        }
                        Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerOne.PlayerName.ToUpper());
                        pickRow = Console.ReadKey().KeyChar;
                        Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                        pickCol = Console.ReadKey().KeyChar;
                        valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, playerTwo);
                    }
                    if (valid.PickIsValid == true)
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
                    if (valid.MoveIsValid == true)
                    {
                        if (move.MustMoveRowAndCol.Count > 0)
                        {
                            int convertedMoveCol = Convert.ToInt16(moveCol.ToString());

                            if (move.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                            {
                                Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                                Console.ReadKey();
                                undo.UndoStack.Push(pickRow.ToString().ToUpper() + "." + pickCol + "," + moveRow.ToString().ToUpper() + "." + moveCol);
                                detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
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
                            undo.UndoStack.Push(pickRow.ToString().ToUpper() + "." + pickCol + "," + moveRow.ToString().ToUpper() + "." + moveCol);
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                            game.Draw(gameBg, playerOne, playerTwo);
                        }
                    }
                    else
                    {
                        detection.MoveComplete = false;
                    }
                }
                if (detection.MoveComplete == true && detection.AnotherMove == false)
                {
                    undo.UndoPlayerMove(gameBg, detection.Player, detection.Opponent, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol);
                }
                //*******************************************************************************************************************************
                if (playerTwo.IsItMyTurn == true)
                {
                    valid.PickIsValid = false;
                    valid.MoveIsValid = false;
                    move.ForceJumpDown(gameBg);
                    playerOne.SetPlayerTimer();

                    if (detection.CheckerTaken == true && detection.AnotherMove == false || detection.MoveComplete == true && detection.AnotherMove == false)
                    {
                        detection.CheckerTaken = false;
                        playerTwo.YourTurn();
                        playerOne.MyTurn();
                        game.Draw(gameBg, playerOne, playerTwo);
                    }
                    else
                    {
                        Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerTwo.PlayerName.ToUpper());
                        pickRow = Console.ReadKey().KeyChar;
                        Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                        pickCol = Console.ReadKey().KeyChar;
                        valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, playerTwo);
                    }

                    if (valid.PickIsValid == true)
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
                    if (valid.MoveIsValid == true)
                    {
                        if (move.MustMoveRowAndCol.Count > 0)
                        {
                            int convertedMoveCol = Convert.ToInt16(moveCol.ToString());

                            if (move.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                            {
                                Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                                Console.ReadKey();
                                detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
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
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                        }
                    }
                    if (detection.MoveComplete == true && detection.AnotherMove == false)
                    {
                        undo.UndoPlayerMove(gameBg, detection.Player, detection.Opponent, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol);
                    }
                }
            }
        }
    }
}
