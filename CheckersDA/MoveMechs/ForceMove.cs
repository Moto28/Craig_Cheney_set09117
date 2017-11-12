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


        public ForceMove()
        {
            mustPickRowAndCol = MustPickRowAndCol;
            mustMoveRowAndCol = MustMoveRowAndCol;
            revert = Revert;
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

        public void ForceJumpUp(string[,] gameBg)
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

                    //checks up an left
                    if ((gameBg[x, y] == "X " || gameBg[x, y] == "kX") && (gameBg[x - 1, y - 1] == "O " || gameBg[x - 1, y - 1] == "kO") && gameBg[x - 2, y - 2] == "\0 ")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x - 1].ToUpper(), y - 2);
                        int temp = y - 1;
                        mustPickRowAndCol.Add(revert[x] + temp);
                        temp = y - 2;
                        mustMoveRowAndCol.Add(revert[x - 1] + temp);
                    }
                    //checks up and right
                    if ((gameBg[x, y] == "X " || gameBg[x, y] == "kX") && (gameBg[x - 1, y + 1] == "O " || gameBg[x - 1, y - 1] == "kO") && gameBg[x - 2, y + 2] == "\0 ")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x - 1].ToUpper(), y);
                        int temp = y - 1;
                        mustPickRowAndCol.Add(revert[x] + temp);
                        mustMoveRowAndCol.Add(revert[x - 1] + y);
                    }
                    //checks down and left
                    if (gameBg[x, y] == "kX" && (gameBg[x + 1, y - 1] == "O " || gameBg[x + 1, y - 1] == "kO ") && gameBg[x + 2, y - 2] == "\0 ")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x + 1].ToUpper(), y - 2);
                        int temp = y - 1;
                        mustPickRowAndCol.Add(revert[x] + temp);
                        temp = y - 2;
                        mustMoveRowAndCol.Add(revert[x + 1] + temp);
                    }
                    //checks down and right
                    if (gameBg[x, y] == "kX" && (gameBg[x + 1, y + 1] == "O " || gameBg[x + 1, y + 1] == "kO") && gameBg[x + 2, y + 2] == "\0 ")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x + 1].ToUpper(), y);
                        int temp = y - 1;
                        mustPickRowAndCol.Add(revert[x] + temp);
                        mustMoveRowAndCol.Add(revert[x + 1] + y);
                    }
                }
            }
        }
        public void ForceJumpDown(string[,] gameBg)
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
                    //checks down and up 
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && (gameBg[x + 1, y - 1] == "X " || gameBg[x + 1, y - 1] == "kX") && gameBg[x + 2, y - 2] == "\0 ")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x + 1].ToUpper(), y - 2);
                        int temp = y - 1;
                        mustPickRowAndCol.Add(revert[x] + temp);
                        temp = y - 2;
                        mustMoveRowAndCol.Add(revert[x + 1] + temp);
                    }
                    //checks down and right 
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && (gameBg[x + 1, y + 1] == "X " || gameBg[x + 1, y + 1] == "kX") && gameBg[x + 2, y + 2] == "\0 ")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x + 1].ToUpper(), y);
                        int temp = y - 1;
                        mustPickRowAndCol.Add(revert[x] + temp);
                        mustMoveRowAndCol.Add(revert[x + 1] + y);
                    }
                    //checks up and left
                    if (gameBg[x, y] == "kO" && (gameBg[x - 1, y - 1] == "X " || gameBg[x - 1, y - 1] == "kX") && gameBg[x - 2, y - 2] == "\0 ")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x - 1].ToUpper(), y - 2);
                        int temp = y - 1;
                        mustPickRowAndCol.Add(revert[x] + temp);
                        temp = y - 2;
                        mustMoveRowAndCol.Add(revert[x - 1] + temp);
                    }
                    //checks up and right
                    if (gameBg[x, y] == "kO" && (gameBg[x - 1, y + 1] == "X " || gameBg[x - 1, y + 1] == "kX") && gameBg[x - 2, y + 2] == "\0 ")
                    {
                        Console.WriteLine("{0}{1} TO {2}{3}", revert[x].ToUpper(), y - 1, revert[x - 1].ToUpper(), y);
                        int temp = y - 1;
                        mustPickRowAndCol.Add(revert[x] + temp);
                        mustMoveRowAndCol.Add(revert[x - 1] + y);
                    }
                }
            }
        }
    }
}



