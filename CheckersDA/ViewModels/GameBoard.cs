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
        private string[,] gameBg = new string[14, 14];

        public GameBoard()
        {
            gameBg = GameBg;
        }
        public string[,] GameBg
        {
            get
            {
                return gameBg;
            }
            set
            {
                gameBg = value;
            }
        }
        public void Draw(string[,] gameBg, PlayerOne playerOne, PlayerTwo playerTwo)
        {

            Console.Clear();
            Console.WriteLine("                     1           2           3           4           5           6           7          8");
            Console.WriteLine("              ________________________________________________________________________________________________");
            Console.WriteLine("             |            |           |           |           |           |           |           |           |");
            Console.WriteLine("          H  |     {0}       |     {1}    |      {2}     |     {3}    |     {4}      |     {5}    |     {6}      |     {7}    | H               {8}'s Stats         ", gameBg[2, 2], gameBg[2, 3], gameBg[2, 4], gameBg[2, 5], gameBg[2, 6], gameBg[2, 7], gameBg[2, 8], gameBg[2, 9], playerOne.PlayerName);
            Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Score: {0}", "placeholder");
            Console.WriteLine("             |            |           |           |           |           |           |           |           |                 Move Count: {0}     ", "placeholder");
            Console.WriteLine("          G  |     {0}     |     {1}      |     {2}    |       {3}    |     {4}    |      {5}     |     {6}    |      {7}     | G", gameBg[3, 2], gameBg[3, 3], gameBg[3, 4], gameBg[3, 5], gameBg[3, 6], gameBg[3, 7], gameBg[3, 8], gameBg[3, 9]);
            Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Checker: {0} ", playerOne.PlayerChecker);
            Console.WriteLine("             |            |           |           |           |           |           |           |           |                 Checker Count:{0}", "placeholder");
            Console.WriteLine("          F  |     {0}       |     {1}    |      {2}     |     {3}    |      {4}     |     {5}    |     {6}      |     {7}    | F", gameBg[4, 2], gameBg[4, 3], gameBg[4, 4], gameBg[4, 5], gameBg[4, 6], gameBg[4, 7], gameBg[4, 8], gameBg[4, 9]);
            Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
            Console.WriteLine("             |            |           |           |           |           |           |           |           |");
            Console.WriteLine("          E  |     {0}     |     {1}    |     {2}    |     {3}    |      {4}   |      {5}   |     {6}    |      {7}   | E", gameBg[5, 2], gameBg[5, 3], gameBg[5, 4], gameBg[5, 5], gameBg[5, 6], gameBg[5, 7], gameBg[5, 8], gameBg[5, 9]);
            Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
            Console.WriteLine("             |            |           |           |           |           |           |           |           |");
            Console.WriteLine("          D  |     {0}     |      {1}   |      {2}   |    {3}     |      {4}   |     {5}    |     {6}    |     {7}    | D               {8}'s Stats         ", gameBg[6, 2], gameBg[6, 3], gameBg[6, 4], gameBg[6, 5], gameBg[6, 6], gameBg[6, 7], gameBg[6, 8], gameBg[6, 9], playerTwo.PlayerName);
            Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Score: {0}", "placeholder");
            Console.WriteLine("             |            |           |           |           |           |           |           |           |                 Move Count: {0}     ");
            Console.WriteLine("          C  |     {0}     |     {1}      |     {2}    |     {3}      |     {4}    |     {5}      |     {6}    |     {7}      | C               Move Timer: {8}     ", gameBg[7, 2], gameBg[7, 3], gameBg[7, 4], gameBg[7, 5], gameBg[7, 6], gameBg[7, 7], gameBg[7, 8], gameBg[7, 9], "placeholder");
            Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|                 Checker: {0}        ", playerTwo.PlayerChecker);
            Console.WriteLine("             |            |           |           |           |           |           |           |           |  Checker Count:{0}", playerTwo.PlayerCheckerCount);
            Console.WriteLine("          B  |     {0}       |     {1}    |     {2}      |     {3}    |       {4}    |    {5}     |     {6}      |     {7}    | B", gameBg[8, 2], gameBg[8, 3], gameBg[8, 4], gameBg[8, 5], gameBg[8, 6], gameBg[8, 7], gameBg[8, 8], gameBg[8, 9]);
            Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
            Console.WriteLine("             |            |           |           |           |           |           |           |           |");
            Console.WriteLine("          A  |     {0}     |     {1}      |     {2}    |     {3}      |     {4}    |      {5}     |    {6}     |      {7}     | A", gameBg[9, 2], gameBg[9, 3], gameBg[9, 4], gameBg[9, 5], gameBg[9, 6], gameBg[9, 7], gameBg[9, 8], gameBg[9, 9]);
            Console.WriteLine("             |____________|___________|___________|___________|___________|___________|___________|___________|");
            Console.WriteLine("                     1           2           3           4           5           6           7          8");


        }
    }
}

