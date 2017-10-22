using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.MoveConvertor
{
    class IsInputValid
    {
        private Dictionary<string, int> convertor = new Dictionary<string, int>();
        private int convRow;
        private int convCol;
        private int newConvRow;
        private int newConvCol;
        private bool rowIsVaild;
        private bool colIsVaild;
        private bool moveRowIsVaild;
        private bool moveColIsVaild;
        private bool pickIsValid;

        public IsInputValid()
        {
            convRow = ConvRow;
            convCol = ConvCol;
            newConvRow = NewConvRow;
            newConvCol = NewConvCol;
            rowIsVaild = RowIsVaild;
            colIsVaild = ColIsVaild;
            moveRowIsVaild = MoveRowIsVaild;
            moveColIsVaild = MoveColIsVaild;
            pickIsValid = PickIsValid;
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


        public void CreateDictionary()
        {
            convertor.Add("a", 7);
            convertor.Add("b", 6);
            convertor.Add("c", 5);
            convertor.Add("d", 4);
            convertor.Add("e", 3);
            convertor.Add("f", 2);
            convertor.Add("g", 1);
            convertor.Add("h", 0);
            convertor.Add("1", 0);
            convertor.Add("2", 1);
            convertor.Add("3", 2);
            convertor.Add("4", 3);
            convertor.Add("5", 4);
            convertor.Add("6", 5);
            convertor.Add("7", 6);
            convertor.Add("8", 7);
        }


        public void IsItValidFirstMove(char row, char col)
        {
            if (convertor.Count == 0)
            {
                CreateDictionary();
            }

            if (row == 'a' | row == 'b' | row == 'c' | row == 'd' | row == 'e' | row == 'f' | row == 'g' | row == 'h' && col == '1' | col == '2' | col == '3' | col == '4' | col == '5' | col == '6' | col == '7')
            {
                if (convertor.ContainsKey(row.ToString()))
                {
                    convRow = convertor[row.ToString()];
                    rowIsVaild = true;
                }
                if (convertor.ContainsKey(col.ToString()))
                {
                    convCol = convertor[col.ToString()];
                    colIsVaild = true;
                }
                if (colIsVaild == true && rowIsVaild == true)
                {
                    pickIsValid = true;
                }
            }
            else
            {
                Console.WriteLine("\n\nInvalid entry:COLUMN values accepted are: 1,2,3,4,5,6,7,8 OR ROW values are: a,b,c,d,e,f,g,h");
                Console.WriteLine("\nPress enter to start your move again");
                Console.ReadKey();
                pickIsValid = false;
            }

        }
        public void IsItValidSecondMove(char moveRow, char moveCol, bool moveValid)
        {
            if (moveRow == 'a' | moveRow == 'b' | moveRow == 'c' | moveRow == 'd' | moveRow == 'e' | moveRow == 'f' | moveRow == 'g' | moveRow == 'h' && moveCol == '1' | moveCol == '2' | moveCol == '3' | moveCol == '4' | moveCol == '5' | moveCol == '6' | moveCol == '7')
            {
                if (convertor.ContainsKey(moveRow.ToString()))
                {
                    newConvRow = convertor[moveRow.ToString()];
                    moveRowIsVaild = true;
                }
                if (convertor.ContainsKey(moveCol.ToString()))
                {
                    newConvCol = convertor[moveCol.ToString()];
                    moveColIsVaild = true;
                }
                if (moveRowIsVaild == true && moveColIsVaild == true)
                {
                    moveValid = true;
                }
            }
            else
            {
                Console.WriteLine("\n\nInvalid entry:COLUMN values accepted are: 1,2,3,4,5,6,7,8 OR ROW values are: a,b,c,d,e,f,g,h");
                Console.WriteLine("\nPress enter to start your move again");
                Console.ReadKey();
                moveValid = false;
            }
        }
    }
}
