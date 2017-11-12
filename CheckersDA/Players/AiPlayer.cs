using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersDA.MoveMechs;
using CheckersDA.MoveConvertor;

namespace CheckersDA.Players
{
    class AiPlayer : PlayerTwo
    {
        private List<string> score0 = new List<string>();
        private List<string> score1 = new List<string>();
        private List<string> score2 = new List<string>();
        private List<string> score3 = new List<string>();
        private List<string> score4 = new List<string>();
        private string aiMove;
        private int row;
        private int col;
        private int moveRow;
        private int moveCol;

        override public void GetPlayerName()
        {
            aiMove = AiMove;
            score0 = Score0;
            score1 = Score1;
            score2 = Score2;
            score3 = Score3;
            score4 = Score4;
            PlayerName = "Pickle Rick";
            row = Row;
            col = Col;
            moveRow = MoveRow;
            moveCol = MoveCol;
        }

        public List<string> Score0
        {
            get
            {
                return score0;
            }
            set
            {
                score0 = value;
            }
        }
        public List<string> Score1
        {
            get
            {
                return score1;
            }
            set
            {
                score1 = value;
            }
        }
        public List<string> Score2
        {
            get
            {
                return score2;
            }
            set
            {
                score2 = value;
            }
        }
        public List<string> Score3
        {
            get
            {
                return score3;
            }
            set
            {
                score3 = value;
            }
        }
        public List<string> Score4
        {
            get
            {
                return score4;
            }
            set
            {
                score4 = value;
            }
        }
        public string AiMove
        {
            get
            {
                return aiMove;
            }
            set
            {
                aiMove = value;
            }
        }
        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }
        public int Col
        {
            get
            {
                return col;
            }
            set
            {
                col = value;
            }
        }
        public int MoveRow
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
        public int MoveCol
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

        public void AvailableMoves(string[,] gameBg)
        {
            Score0.Clear();
            Score1.Clear();
            Score2.Clear();
            Score3.Clear();

            for (int x = 2; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    //down for downward movement
                    //finds moves for O or kO looks looks for a space DOWN and RIGHT and ethier a X or kX          
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y - 1] == "\0 " && gameBg[x + 2, y - 2] == "X " || gameBg[x + 2, y - 2] == "kX")
                    {
                        int tempX = x + 1;
                        int tempY = y - 1;
                        score0.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());

                    }
                    //finds moves for O or kO looks looks for a space DOWN and LEFT and ethier a X or kX     
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y + 1] == "\0 " && gameBg[x + 2, y + 2] == "X " || gameBg[x + 2, y + 2] == "kX")
                    {
                        int tempX = x + 1;
                        int tempY = y + 1;
                        score0.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());

                    }
                    //finds moves for O or kO looks looks for a space DOWN and RIGHT and a space DOWN and RIGHT        
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y - 1] == "\0 " && gameBg[x + 2, y - 2] == "\0 ")
                    {
                        int tempX = x + 1;
                        int tempY = y - 1;
                        score1.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                    //finds moves for O or kO looks looks for a space DOWN and RIGHT and a space DOWN and LEFT        
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y + 1] == "\0 " && gameBg[x + 2, y + 2] == "\0 ")
                    {
                        int tempX = x + 1;
                        int tempY = y + 1;
                        score1.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                    //finds moves for O or kO looks looks for a space DOWN and RIGHT and a space DOWN and RIGHT        
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y - 1] == "\0 " && gameBg[x + 2, y - 2] == "N ")
                    {
                        int tempX = x + 1;
                        int tempY = y - 1;
                        score1.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                    //finds moves for O or kO looks looks for a space DOWN and LEFT and a space DOWN and LEFT        
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y + 1] == "\0 " && gameBg[x + 2, y + 2] == "N ")
                    {
                        int tempX = x + 1;
                        int tempY = y + 1;
                        score1.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                    //finds moves for O or kO looks looks for a space DOWN and RIGHT and a space DOWN and RIGHT        
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y - 1] == "X " && (gameBg[x + 2, y - 2] == "\0 "))
                    {
                        int tempX = x + 1;
                        int tempY = y - 1;
                        score2.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                    //finds moves for O or kO looks looks for a space DOWN and LEFT and a space DOWN and LEFT        
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y + 1] == "X " && gameBg[x + 2, y + 2] == "\0 ")
                    {
                        int tempX = x + 1;
                        int tempY = y + 1;
                        score2.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                    //finds moves for O or kO looks looks for a space DOWN and RIGHT and a space DOWN and RIGHT        
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y - 1] == "kX" && (gameBg[x + 2, y - 2] == "\0 "))
                    {
                        int tempX = x + 1;
                        int tempY = y - 1;
                        score3.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                    //finds moves for O or kO looks looks for a space DOWN and LEFT and a space DOWN and LEFT        
                    if ((gameBg[x, y] == "O " || gameBg[x, y] == "kO") && gameBg[x + 1, y + 1] == "kX" && gameBg[x + 2, y + 2] == "\0 ")
                    {
                        int tempX = x + 1;
                        int tempY = y + 1;
                        score3.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                    //checks for O and kO checks if the row is 9 so checker changes to king down and RIGHT for space 
                    if (gameBg[x, y] == "O " && x == 9 && gameBg[x + 1, y - 1] == "\0 ")
                    {
                        int tempX = x + 1;
                        int tempY = y - 1;
                        score4.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                    //checks for O and kO checks if the row is 9 so checker changes to king down and LEFT for space 
                    if (gameBg[x, y] == "O " && x == 9 && gameBg[x + 1, y + 1] == "\0 ")
                    {
                        int tempX = x + 1;
                        int tempY = y + 1;
                        score4.Add(x.ToString() + "," + y.ToString() + "-" + tempX.ToString() + "," + tempY.ToString());
                    }
                }
            }
        }
        public void PickMove()
        {
            string[] pickMove = new string[10];
            Random random = new Random();
            int i = 0;
            if (Score4.Count >= 1)
            {
                foreach (var move in score3)
                {
                    pickMove[i] = move;
                    i++;
                }
                int rnd = random.Next(0, i);
                aiMove = pickMove[rnd].ToString();
            }
            if (Score3.Count >= 1)
            {
                foreach (var move in score3)
                {
                    pickMove[i] = move;
                    i++;
                }
                int rnd = random.Next(0, i);
                aiMove = pickMove[rnd].ToString();
            }
            else if (Score2.Count >= 1)
            {
                foreach (var move in score2)
                {
                    pickMove[i] = move;
                    i++;
                }
                int rnd = random.Next(0, i);
                aiMove = pickMove[rnd].ToString();
            }
            else if (Score1.Count >= 1)
            {
                foreach (var move in score1)
                {
                    pickMove[i] = move;
                    i++;
                }
                int rnd = random.Next(0, i);
                aiMove = pickMove[rnd].ToString();
            }
            else if (Score0.Count >= 1)
            {
                foreach (var move in score0)
                {
                    pickMove[i] = move;
                    i++;
                }
                int rnd = random.Next(0, i);
                aiMove = pickMove[rnd].ToString();
            }
        }
        public void CovertMove()
        {
            string[] separators = { ",", "-" };
            string[] words = aiMove.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("{0} now for the hard part\n {1} long", aiMove.ToString(), words.Length);
            row = Convert.ToInt16(words[0]);
            col = Convert.ToInt16(words[1]);
            moveRow = Convert.ToInt16(words[2]);
            moveCol = Convert.ToInt16(words[3]);
        }
        public void MakeMove(string[,] gameBg)
        {
            //stores the type checkers to be moved
            string checker = gameBg[row, col].ToString();
            string opponent = gameBg[moveRow, moveCol].ToString();
            //checks if the move is DOWN
            if (moveRow > row)
            {   //checks if move is RIGHT and an empty space
                if (col > moveCol && opponent == "\0 ")
                {
                    gameBg[row, col] = "\0 ";
                    gameBg[moveRow, moveCol] = checker;
                }
                //checks if move is LEFT and an empty space
                else if (moveCol > col && opponent == "\0 ")
                {
                    gameBg[row, col] = "\0 ";
                    gameBg[moveRow, moveCol] = checker;
                }
                //checks if move is RIGHT and taking checker
                else if (col > moveCol && (checker == "O " || checker == "kO"))
                {
                    gameBg[row, col] = "\0 ";
                    gameBg[moveRow, moveCol] = "\0 ";
                    gameBg[moveRow + 1, moveCol - 1] = checker;
                }
                //checks if move is LEFT and taking checker
                else if (moveCol > col && (checker == "O " || checker == "kO"))
                {
                    gameBg[row, col] = "\0 ";
                    gameBg[moveRow, moveCol] = "\0 ";
                    gameBg[moveRow + 1, moveCol + 1] = checker;
                }
            }


        }
    }
}
