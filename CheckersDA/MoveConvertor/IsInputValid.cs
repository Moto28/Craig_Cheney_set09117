using System;
using System.Collections.Generic;
using CheckersDA.MoveMechs;
using CheckersDA.Players;

namespace CheckersDA.MoveConvertor
{
    class IsInputValid
    {
        #region instantiate's objects used by the class
        ForceMove forceMove = new ForceMove();
        CollisionDect collisionDect = new CollisionDect();
        private Dictionary<string, int> convertor = new Dictionary<string, int>();
        #endregion

        #region creates private varibles
        private int convRow;
        private int convCol;
        private int newConvRow;
        private int newConvCol;
        private bool rowIsVaild;
        private bool colIsVaild;
        private bool moveRowIsVaild;
        private bool moveColIsVaild;
        private bool pickIsValid;
        private bool moveIsValid;
        #endregion

        #region constructor
        public IsInputValid()
        {
            convertor = Convertor;
            convRow = ConvRow;
            convCol = ConvCol;
            newConvRow = NewConvRow;
            newConvCol = NewConvCol;
            rowIsVaild = RowIsVaild;
            colIsVaild = ColIsVaild;
            moveRowIsVaild = MoveRowIsVaild;
            moveColIsVaild = MoveColIsVaild;
            pickIsValid = PickIsValid;
            moveIsValid = MoveIsValid;
        }
        #endregion

        #region getters and setters
        public Dictionary<string, int> Convertor
        {
            get
            {
                return convertor;
            }
            set
            {
                convertor = value;
            }

        }
        public int ConvRow
        {
            get
            {
                return convRow;
            }
            set
            {
                convRow = value;
            }
        }
        public int ConvCol
        {
            get
            {
                return convCol;
            }
            set
            {
                convCol = value;
            }
        }
        public int NewConvRow
        {
            get
            {
                return newConvRow;
            }
            set
            {
                newConvRow = value;
            }
        }
        public int NewConvCol
        {
            get
            {
                return newConvCol;
            }
            set
            {
                newConvCol = value;
            }
        }
        public bool RowIsVaild
        {
            get
            {
                return rowIsVaild;
            }
            set
            {
                rowIsVaild = value;
            }
        }
        public bool ColIsVaild
        {
            get
            {
                return colIsVaild;
            }
            set
            {
                colIsVaild = value;
            }
        }
        public bool MoveRowIsVaild
        {
            get
            {
                return moveRowIsVaild;
            }
            set
            {
                moveRowIsVaild = value;
            }
        }
        public bool MoveColIsVaild
        {
            get
            {
                return moveColIsVaild;
            }
            set
            {
                moveColIsVaild = value;
            }
        }
        public bool PickIsValid
        {
            get
            {
                return pickIsValid;
            }
            set
            {
                pickIsValid = value;
            }
        }
        public bool MoveIsValid

        {
            get
            {
                return moveIsValid;
            }
            set
            {
                moveIsValid = value;
            }
        }
        #endregion

        #region adds key value pairs to add dictionary
        public void CreateConvertor()
        {
            convertor.Add("a", 9);
            convertor.Add("b", 8);
            convertor.Add("c", 7);
            convertor.Add("d", 6);
            convertor.Add("e", 5);
            convertor.Add("f", 4);
            convertor.Add("g", 3);
            convertor.Add("h", 2);
            convertor.Add("8", 9);
            convertor.Add("7", 8);
            convertor.Add("6", 7);
            convertor.Add("5", 6);
            convertor.Add("4", 5);
            convertor.Add("3", 4);
            convertor.Add("2", 3);
            convertor.Add("1", 2);

        }
        #endregion

        #region checks if first move is valid
        public void IsItValidFirstMove(string[,] gameBg, char row, char col, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            //checks if the data dictionary has been created 
            if (convertor.Count == 0)
            {
                CreateConvertor();
            }

            //the bool values back to false
            pickIsValid = false;
            rowIsVaild = false;
            colIsVaild = false;

            //checks if te user input is any of the values below
            if (row == 'a' | row == 'b' | row == 'c' | row == 'd' | row == 'e' | row == 'f' | row == 'g' | row == 'h' && col == '1' | col == '2' | col == '3' | col == '4' | col == '5' | col == '6' | col == '7' | col == '8')
            {
                //trys to match user input to value in data dictionary
                if (convertor.ContainsKey(row.ToString()))
                {
                    //sets convRow to Key in data dictionary
                    convRow = convertor[row.ToString()];
                    rowIsVaild = true;
                }
                if (convertor.ContainsKey(col.ToString()))
                {
                    //sets convCol to Key in data dictionary
                    convCol = convertor[col.ToString()];
                    colIsVaild = true;
                }
                //checks if both convRow and convCol are valid 
                if (colIsVaild == true && rowIsVaild == true)
                {
                    //sets pick to valid
                    pickIsValid = true;
                }
            }
            //if user input is not an allowed value this error message will appear and set pickValid is False
            else
            {
                Console.WriteLine("\n\nInvalid entry:COLUMN values accepted are: 1,2,3,4,5,6,7,8 OR ROW values are: a,b,c,d,e,f,g,h");
                Console.WriteLine("\nPress enter to start your move again");
                Console.ReadKey();
                pickIsValid = false;
            }

        }
        #endregion

        #region checks if second move is valid
        public void IsItValidSecondMove(char moveRow, char moveCol, bool moveValid)
        {
            //sets the values to false
            moveIsValid = false;
            moveRowIsVaild = false;
            moveColIsVaild = false;

            //checks if user input matchs values below
            if (moveRow == 'a' | moveRow == 'b' | moveRow == 'c' | moveRow == 'd' | moveRow == 'e' | moveRow == 'f' | moveRow == 'g' | moveRow == 'h' && moveCol == '1' | moveCol == '2' | moveCol == '3' | moveCol == '4' | moveCol == '5' | moveCol == '6' | moveCol == '7' | moveCol == '8')
            {
                //trys to match user input to value in data dictionary
                if (convertor.ContainsKey(moveRow.ToString()))
                {
                    //sets convCol to Key in data dictionary
                    newConvRow = convertor[moveRow.ToString()];
                    moveRowIsVaild = true;
                }
                //trys to match user input to value in data dictionary
                if (convertor.ContainsKey(moveCol.ToString()))
                {
                    //sets convCol to Key in data dictionary
                    newConvCol = convertor[moveCol.ToString()];
                    moveColIsVaild = true;
                }
                //checks if both convRow and convCol are valid 
                if (moveRowIsVaild == true && moveColIsVaild == true)
                {
                    moveIsValid = true;
                }
            }
            //if user input is not an allowed value this error message will appear and set pickValid is False
            else
            {
                moveIsValid = false;
                Console.WriteLine("\n\nInvalid entry:COLUMN values accepted are: 1,2,3,4,5,6,7,8 OR ROW values are: a,b,c,d,e,f,g,h");
                Console.WriteLine("\nPress enter to start your move again");
                Console.ReadKey();
            }
        }
        #endregion
    }
}
