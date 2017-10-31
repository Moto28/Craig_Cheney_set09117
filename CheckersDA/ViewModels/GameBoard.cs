using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersDA.MoveConvertor;
using CheckersDA.MoveMechs;
using CheckersDA.Players;


namespace CheckersDA.ViewModels
{
    class GameBoard
    {
        IsInputValid valid = new IsInputValid();
        CollisionDect detection = new CollisionDect();
        ForceMove forceMoves = new ForceMove();
        UndoMove undo = new UndoMove();

        private char pickRow;
        private char pickCol;
        private char moveRow;
        private char moveCol;
        private bool win;


        public GameBoard()
        {
            pickRow = PickRow;
            pickCol = PickCol;
            moveRow = MoveRow;
            moveCol = MoveCol;
            win = Win;
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


        public void Draw(char[,] gameBg, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            //creates a while loop that draws the board until the win condition is met. it then takes user input to passes it to IsInputValid then CollisionDect if the input is valid passes move to next player 
            while (!win)
            {

                if (playerOne.IsItMyTurn == true)
                {
                    Console.Clear();
                    Console.WriteLine("                     1           2           3           4           5           6           7          8");
                    Console.WriteLine("              ________________________________________________________________________________________________");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          H  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |     {7}     | H               {8}'s Stats         ", gameBg[2, 2], gameBg[2, 3], gameBg[2, 4], gameBg[2, 5], gameBg[2, 6], gameBg[2, 7], gameBg[2, 8], gameBg[2, 9], playerOne.PlayerName);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Score: {0}", "placeholder");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |                 Move Count: {0}     ", playerOne.PlayerTurnCount);
                    Console.WriteLine("          G  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |      {7}    | G               Move Timer: {8}     ", gameBg[3, 2], gameBg[3, 3], gameBg[3, 4], gameBg[3, 5], gameBg[3, 6], gameBg[3, 7], gameBg[3, 8], gameBg[3, 9], "placeholder");
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Checker: {0} ", playerOne.PlayerChecker);
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          F  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |     {7}     | F", gameBg[4, 2], gameBg[4, 3], gameBg[4, 4], gameBg[4, 5], gameBg[4, 6], gameBg[4, 7], gameBg[4, 8], gameBg[4, 9]);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          E  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |      {7}    | E", gameBg[5, 2], gameBg[5, 3], gameBg[5, 4], gameBg[5, 5], gameBg[5, 6], gameBg[5, 7], gameBg[5, 8], gameBg[5, 9]);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          D  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |     {7}     | D               {8}'s Stats         ", gameBg[6, 2], gameBg[6, 3], gameBg[6, 4], gameBg[6, 5], gameBg[6, 6], gameBg[6, 7], gameBg[6, 8], gameBg[6, 9], playerTwo.PlayerName);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Score: {0}", "placeholder");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |                 Move Count: {0}     ", playerTwo.PlayerTurnCount);
                    Console.WriteLine("          C  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |      {7}    | C               Move Timer: {8}     ", gameBg[7, 2], gameBg[7, 3], gameBg[7, 4], gameBg[7, 5], gameBg[7, 6], gameBg[7, 7], gameBg[7, 8], gameBg[7, 9], "placeholder");
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Checker: {0}        ", playerTwo.PlayerChecker);
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          B  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |     {7}     | B", gameBg[8, 2], gameBg[8, 3], gameBg[8, 4], gameBg[8, 5], gameBg[8, 6], gameBg[8, 7], gameBg[8, 8], gameBg[8, 9]);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          A  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |      {7}    | A", gameBg[9, 2], gameBg[9, 3], gameBg[9, 4], gameBg[9, 5], gameBg[9, 6], gameBg[9, 7], gameBg[9, 8], gameBg[9, 9]);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
                    Console.WriteLine("                     1           2           3           4           5           6           7          8");
                    valid.PickIsValid = false;
                    valid.MoveIsValid = false;
                    forceMoves.ForceJumpUp(gameBg);
                    if (detection.checkerTaken == true && forceMoves.MustMoveRowAndCol.Count == 0 || detection.checkerTaken == true && forceMoves.MustPickRowAndCol.Count == 0)
                    {
                        if (playerOne.IsItMyTurn == true)
                        {
                            playerOne.YourTurn();
                            playerTwo.MyTurn();
                            Draw(gameBg, playerOne, playerTwo);
                        }
                    }
                    Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerOne.PlayerName.ToUpper());
                    pickRow = Console.ReadKey().KeyChar;
                    Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                    pickCol = Console.ReadKey().KeyChar;
                    valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, playerTwo);
                    //hererererererererere                   
                    if (valid.PickIsValid == true)
                    {
                        detection.moveComplete = false;

                        if (forceMoves.MustPickRowAndCol.Count > 0)
                        {
                            int convertedPickCol = Convert.ToInt16(pickCol.ToString());
                            convertedPickCol++;

                            if (forceMoves.MustPickRowAndCol.Contains(PickRow.ToString() + convertedPickCol.ToString()) == true)
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
                    else
                    {
                        Draw(gameBg, playerOne, playerTwo);
                    }
                    if (valid.MoveIsValid == true)
                    {
                        if (forceMoves.MustMoveRowAndCol.Count > 0)
                        {
                            int convertedMoveCol = Convert.ToInt16(moveCol.ToString());


                            if (forceMoves.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                            {
                                Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                                Console.ReadKey();
                                detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                            }
                            else
                            {
                                Console.WriteLine("you must select one of the moves above");
                                Console.ReadKey();
                                detection.moveComplete = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                            Console.ReadKey();
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                        }
                    }
                    else
                    {
                        Draw(gameBg, playerOne, playerTwo);
                    }
                    if (detection.moveComplete == true)
                    {
                        if (playerOne.IsItMyTurn == true)
                        {
                            playerOne.YourTurn();
                            playerTwo.MyTurn();
                        }
                    }

                }
                else if (playerTwo.IsItMyTurn == true)
                {
                    Console.Clear();
                    Console.WriteLine("                     1           2           3           4           5           6           7          8");
                    Console.WriteLine("              ________________________________________________________________________________________________");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          H  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |     {7}     | H               {8}'s Stats         ", gameBg[2, 2], gameBg[2, 3], gameBg[2, 4], gameBg[2, 5], gameBg[2, 6], gameBg[2, 7], gameBg[2, 8], gameBg[2, 9], playerOne.PlayerName);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Score: {0}", "placeholder");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |                 Move Count: {0}     ", playerOne.PlayerTurnCount);
                    Console.WriteLine("          G  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |      {7}    | G               Move Timer: {8}     ", gameBg[3, 2], gameBg[3, 3], gameBg[3, 4], gameBg[3, 5], gameBg[3, 6], gameBg[3, 7], gameBg[3, 8], gameBg[3, 9], "placeholder");
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Checker: {0} ", playerOne.PlayerChecker);
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          F  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |     {7}     | F", gameBg[4, 2], gameBg[4, 3], gameBg[4, 4], gameBg[4, 5], gameBg[4, 6], gameBg[4, 7], gameBg[4, 8], gameBg[4, 9]);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          E  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |      {7}    | E", gameBg[5, 2], gameBg[5, 3], gameBg[5, 4], gameBg[5, 5], gameBg[5, 6], gameBg[5, 7], gameBg[5, 8], gameBg[5, 9]);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          D  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |     {7}     | D               {8}'s Stats         ", gameBg[6, 2], gameBg[6, 3], gameBg[6, 4], gameBg[6, 5], gameBg[6, 6], gameBg[6, 7], gameBg[6, 8], gameBg[6, 9], playerTwo.PlayerName);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Score: {0}", "placeholder");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |                 Move Count: {0}     ", playerTwo.PlayerTurnCount);
                    Console.WriteLine("          C  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |      {7}    | C               Move Timer: {8}     ", gameBg[7, 2], gameBg[7, 3], gameBg[7, 4], gameBg[7, 5], gameBg[7, 6], gameBg[7, 7], gameBg[7, 8], gameBg[7, 9], "placeholder");
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Checker: {0}        ", playerTwo.PlayerChecker);
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          B  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |     {7}     | B", gameBg[8, 2], gameBg[8, 3], gameBg[8, 4], gameBg[8, 5], gameBg[8, 6], gameBg[8, 7], gameBg[8, 8], gameBg[8, 9]);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
                    Console.WriteLine("             |            |           |           |           |           |           |           |           |");
                    Console.WriteLine("          A  |     {0}      |     {1}     |      {2}    |     {3}     |      {4}    |     {5}     |     {6}     |      {7}    | A", gameBg[9, 2], gameBg[9, 3], gameBg[9, 4], gameBg[9, 5], gameBg[9, 6], gameBg[9, 7], gameBg[9, 8], gameBg[9, 9]);
                    Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
                    Console.WriteLine("                     1           2           3           4           5           6           7          8");
                    valid.PickIsValid = false;
                    valid.MoveIsValid = false;
                    forceMoves.ForceJumpDown(gameBg);
                    if (detection.checkerTaken == true && forceMoves.MustMoveRowAndCol.Count == 0 || detection.checkerTaken == true && forceMoves.MustPickRowAndCol.Count == 0)
                    {
                        if (detection.checkerTaken == false)
                        {
                            if (playerTwo.IsItMyTurn == true)
                            {
                                playerTwo.YourTurn();
                                playerOne.MyTurn();
                            }

                        }
                    }
                    Console.WriteLine("\n\n{0} Enter the Row of the Checker you want to Move", playerTwo.PlayerName.ToUpper());
                    pickRow = Console.ReadKey().KeyChar;
                    Console.WriteLine("\nEnter the Column of the Checker you want to Move");
                    pickCol = Console.ReadKey().KeyChar;
                    valid.IsItValidFirstMove(gameBg, pickRow, pickCol, playerOne, playerTwo);


                    if (valid.PickIsValid == true)
                    {
                        if (forceMoves.MustPickRowAndCol.Count > 0)
                        {
                            int convertedPickCol = Convert.ToInt16(pickCol.ToString());

                            if (forceMoves.MustPickRowAndCol.Contains(PickRow.ToString() + convertedPickCol.ToString()) == true)
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
                            detection.moveComplete = false;
                            valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);

                        }

                    }
                    else
                    {
                        Draw(gameBg, playerOne, playerTwo);
                    }
                    if (valid.MoveIsValid == true)
                    {
                        if (forceMoves.MustMoveRowAndCol.Count > 0)
                        {
                            int convertedMoveCol = Convert.ToInt16(moveCol.ToString());


                            if (forceMoves.MustMoveRowAndCol.Contains(moveRow.ToString() + convertedMoveCol.ToString()) == true)
                            {
                                Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                                Console.ReadKey();
                                detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                            }
                            else
                            {
                                Console.WriteLine("you must select one of the moves above");
                                Console.ReadKey();
                                detection.moveComplete = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nyou have elected to move\n    {0}{1}  To  {2}{3}", pickRow.ToString().ToUpper(), pickCol, moveRow.ToString().ToUpper(), moveCol);
                            Console.ReadKey();
                            detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol, playerOne, playerTwo);
                        }
                    }
                    else
                    {
                        Draw(gameBg, playerOne, playerTwo);
                    }
                    if (detection.moveComplete == true)
                    {
                        if (detection.checkerTaken == false)
                        {
                            if (playerTwo.IsItMyTurn == true)
                            {
                                playerTwo.YourTurn();
                                playerOne.MyTurn();
                            }

                        }

                    }


                }
            }
        }
    }
}
