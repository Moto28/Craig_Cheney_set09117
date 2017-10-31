using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.MoveMechs
{
    class ForceMove
    {
        private List<string> mustPickRowAndCol = new List<string>();
        private List<string> mustMoveRowAndCol = new List<string>();
        private Dictionary<int, string> revert = new Dictionary<int, string>();
        private int tempRow;
        private int tempCol;
        int counter = 0;
        public bool forceMove;

        public ForceMove()
        {
            mustPickRowAndCol = MustPickRowAndCol;
            mustMoveRowAndCol = MustMoveRowAndCol;
            revert = Revert;
            tempRow = TempRow;
            tempCol = TempCol;
        }

        public List<string> MustPickRowAndCol
        {
            get
            {
                return mustPickRowAndCol;
            }
            set
            {
                mustPickRowAndCol = value;
            }
        }

        public List<string> MustMoveRowAndCol
        {
            get
            {
                return mustMoveRowAndCol;
            }
            set
            {
                mustMoveRowAndCol = value;
            }
        }
        public Dictionary<int, string> Revert
        {
            get
            {
                return revert;
            }
            set
            {
                revert = value;
            }

        }
        public int TempRow
        {
            get
            {
                return tempRow;
            }
            set
            {
                tempRow = value;
            }
        }
        public int TempCol
        {
            get
            {
                return tempCol;
            }
            set
            {
                tempCol = value;
            }
        }

        public void CreateRevert()
        {
            revert.Add(9, "a");
            revert.Add(8, "b");
            revert.Add(7, "c");
            revert.Add(6, "d");
            revert.Add(5, "e");
            revert.Add(4, "f");
            revert.Add(3, "g");
            revert.Add(2, "h");

        }


        public void ForceJumpUp(char[,] gameBg)
        {
            if (revert.Count == 0)
            {
                CreateRevert();
            }
            mustPickRowAndCol.Clear();
            mustMoveRowAndCol.Clear();
            //checkers on map
            for (int x = 9; x >= 2; x--)
            {
                for (int y = 2; y <= 9; y++)
                {
                    //checks left
                    if (gameBg[x, y].ToString() == "X" && gameBg[x - 1, y - 1].ToString() == "O" && gameBg[x - 2, y - 2].ToString() == "\0" || gameBg[x, y].ToString() == "X" && gameBg[x - 1, y - 1].ToString() == "O" && gameBg[x - 2, y - 2].ToString() == "X")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x - 1].ToUpper(), y - 2);
                        mustPickRowAndCol.Add(revert[x] + y.ToString());
                        int temp = y - 1;

                        mustMoveRowAndCol.Add(revert[x - 1] + temp.ToString());
                    }
                    //checks right
                    else if (gameBg[x, y].ToString() == "X" && gameBg[x - 1, y + 1].ToString() == "O" && gameBg[x - 2, y + 2].ToString() == "\0" || gameBg[x, y].ToString() == "X" && gameBg[x - 1, y + 1].ToString() == "O" && gameBg[x - 2, y + 2].ToString() == "X")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x - 1].ToUpper(), y);
                        mustPickRowAndCol.Add(revert[x] + y.ToString());
                        mustMoveRowAndCol.Add(revert[x - 1] + y.ToString());
                    }
                }
            }
        }
        public void ForceJumpDown(char[,] gameBg)
        {
            if (revert.Count == 0)
            {
                CreateRevert();
            }
            mustPickRowAndCol.Clear();
            mustMoveRowAndCol.Clear();
            //checkers on map
            for (int x = 2; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    //checks for a checker on the right side 
                    if (gameBg[x, y].ToString() == "O" && gameBg[x + 1, y - 1].ToString() == "X" && gameBg[x + 2, y - 2].ToString() == "\0")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x + 1].ToUpper(), y - 2);
                        int temp = y - 3;
                        mustPickRowAndCol.Add(revert[x] + temp.ToString());
                        mustMoveRowAndCol.Add(revert[x + 1] + temp.ToString());
                    }
                    //checks for a checker on the left side
                    else if (gameBg[x, y].ToString() == "O" && gameBg[x + 1, y + 1].ToString() == "X" && gameBg[x + 2, y + 2].ToString() == "\0")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x + 1].ToUpper(), y);
                        int temp = y - 1;
                        mustPickRowAndCol.Add(revert[x] + temp.ToString());
                        temp = +3;
                        mustMoveRowAndCol.Add(revert[x + 1] + temp.ToString());
                    }
                }
            }
        }
    }
}



