using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersDA.MoveConvertor;
using CheckersDA.MoveMechs;

namespace CheckersDA.ViewModels
{
    class GameBoard
    {
        IsInputValid valid = new IsInputValid();
        CollisionDect detection = new CollisionDect();

        private char pickRow;
        private char pickCol;
        private char moveRow;
        private char moveCol;

        public GameBoard()
        {
            pickRow = PickRow;
            pickCol = PickCol;
            moveRow = MoveRow;
            moveCol = MoveCol;
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
        public void Draw(char[,] gameBg, bool win)
        {
            //creates a while loop that draws the board until the win condition is met. it then takes 
            while (!win)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("            1           2           3           4           5           6           7          8");
                Console.WriteLine("     ________________________________________________________________________________________________");
                Console.WriteLine("    |            |           |           |           |           |           |           |           |");
                Console.WriteLine(" H  |            |     {0}     |           |    {1}      |           |     {2}     |           |     {3}     | H", gameBg[0, 1], gameBg[0, 3], gameBg[0, 5], gameBg[0, 7]);
                Console.WriteLine("    |____________|___________|___________|___________|___________|___________|___________|___________|");
                Console.WriteLine("    |            |           |           |           |           |           |           |           |");
                Console.WriteLine(" G  |     {0}      |           |     {1}     |           |     {2}     |           |     {3}     |           | G", gameBg[1, 0], gameBg[1, 2], gameBg[1, 4], gameBg[1, 6]);
                Console.WriteLine("    |____________|___________|___________|___________|___________|___________|___________|___________|");
                Console.WriteLine("    |            |           |           |           |           |           |           |           |");
                Console.WriteLine(" F  |            |     {0}     |           |    {1}      |           |     {2}     |           |     {3}     | F", gameBg[2, 1], gameBg[2, 3], gameBg[2, 5], gameBg[2, 7]);
                Console.WriteLine("    |____________|___________|___________|___________|___________|___________|___________|___________|");
                Console.WriteLine("    |            |           |           |           |           |           |           |           |");
                Console.WriteLine(" E  |     {0}      |           |     {1}     |           |     {2}     |           |     {3}     |           | E", gameBg[3, 0], gameBg[3, 2], gameBg[3, 4], gameBg[3, 6]);
                Console.WriteLine("    |____________|___________|___________|___________|___________|___________|___________|___________|");
                Console.WriteLine("    |            |           |           |           |           |           |           |           |");
                Console.WriteLine(" D  |            |     {0}     |           |    {1}      |           |     {2}     |           |     {3}     | D", gameBg[4, 1], gameBg[4, 3], gameBg[4, 5], gameBg[4, 7]);
                Console.WriteLine("    |____________|___________|___________|___________|___________|___________|___________|___________|");
                Console.WriteLine("    |            |           |           |           |           |           |           |           |");
                Console.WriteLine(" C  |     {0}      |           |     {1}     |           |     {2}     |           |     {3}     |           | C", gameBg[5, 0], gameBg[5, 2], gameBg[5, 4], gameBg[5, 6]);
                Console.WriteLine("    |____________|___________|___________|___________|___________|___________|___________|___________|");
                Console.WriteLine("    |            |           |           |           |           |           |           |           |");
                Console.WriteLine(" B  |            |     {0}     |           |    {1}      |           |     {2}     |           |     {3}     | B", gameBg[6, 1], gameBg[6, 3], gameBg[6, 5], gameBg[6, 7]);
                Console.WriteLine("    |____________|___________|___________|___________|___________|___________|___________|___________|");
                Console.WriteLine("    |            |           |           |           |           |           |           |           |");
                Console.WriteLine(" A  |     {0}      |           |     {1}     |           |     {2}     |           |     {3}     |           | A", gameBg[7, 0], gameBg[7, 2], gameBg[7, 4], gameBg[7, 6]);
                Console.WriteLine("    |____________|___________|___________|___________|___________|___________|___________|___________|");
                Console.WriteLine("            1           2           3           4           5           6           7          8");

                Console.WriteLine("\n\n Enter the Row of the Checker you want to Move");
                pickRow = Console.ReadKey().KeyChar;
                Console.WriteLine("\n Enter the Column of the Checker you want to Move");
                pickCol = Console.ReadKey().KeyChar;
                valid.IsItValidFirstMove(pickRow, pickCol);


                if (valid.RowIsVaild == true && valid.ColIsVaild == true)
                {
                    Console.WriteLine("\n Enter the Row you want to move to");
                    moveRow = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n Enter the Column you want to move to ");
                    moveCol = Console.ReadKey().KeyChar;
                    valid.IsItValidSecondMove(moveRow, moveCol, valid.PickIsValid);
                }
                if (valid.MoveRowIsVaild && valid.MoveColIsVaild == true && valid.RowIsVaild && valid.ColIsVaild == true)
                {
                    Console.WriteLine("\n\nyou have elected to move\n       {0}{1}   To  {2}{3}", pickRow, pickCol, moveRow, moveCol);
                    Console.ReadKey();
                    detection.CheckAndUpdate(gameBg, valid.ConvRow, valid.ConvCol, valid.NewConvRow, valid.NewConvCol);
                }
            }
        }
    }
}
