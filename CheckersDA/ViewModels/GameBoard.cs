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
        #region creates private varibles 
        private string[,] gameBg = new string[14, 14];
        #endregion

        #region constructors
        public GameBoard()
        {
            gameBg = GameBg;
        }
        #endregion

        #region getters and setters
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
        #endregion

        #region draws the game board with the array used for a background for objects
        public void Draw(string[,] gameBg, PlayerOne playerOne, PlayerTwo playerTwo)
        {
            Console.Clear();
            //sets window size
            Console.SetWindowSize(200, 45);
            Console.WriteLine("        1    2    3    4    5    6    7    8          ");
            Console.WriteLine("           _____     _____     _____     _____");
            Console.WriteLine("     |:::::     :::::     :::::     :::::     |       ");
            Console.WriteLine("    H|:::::  {0} :::::  {1} :::::  {2} :::::  {3} |H         {4}'s STATS", gameBg[2, 3], gameBg[2, 5], gameBg[2, 7], gameBg[2, 9], playerOne.PlayerName);
            Console.WriteLine("     |:::::_____:::::_____:::::_____:::::_____|          Move Count:{0}", playerOne.PlayerTurnCount);
            Console.WriteLine("     |     :::::     :::::     :::::     :::::|          Score:{0}", playerOne.PlayerScore);
            Console.WriteLine("    G|  {0} :::::  {1} :::::  {2} :::::  {3} :::::|G  ", gameBg[3, 2], gameBg[3, 4], gameBg[3, 6], gameBg[3, 8]);
            Console.WriteLine("     |_____:::::_____:::::_____:::::____ :::::|");
            Console.WriteLine("     |:::::     :::::     :::::     :::::     |          {0}'s STATS", playerTwo.PlayerName);
            Console.WriteLine("    F|:::::  {0} :::::  {1} :::::  {2} :::::  {3} |F         Move Count:{4}", gameBg[4, 3], gameBg[4, 5], gameBg[4, 7], gameBg[4, 9], playerTwo.PlayerTurnCount);
            Console.WriteLine("     |:::::_____:::::_____:::::_____:::::_____|          Score:{0}", playerTwo.PlayerScore);
            Console.WriteLine("     |     :::::     :::::     :::::     :::::|       ");
            Console.WriteLine("    E|  {0} :::::  {1} :::::  {2} :::::  {3} :::::|E  ", gameBg[5, 2], gameBg[5, 4], gameBg[5, 6], gameBg[5, 8]);
            Console.WriteLine("     |_____:::::_____:::::_____:::::____ :::::|");
            Console.WriteLine("     |:::::     :::::     :::::     :::::     |       ");
            Console.WriteLine("    D|:::::  {0} :::::  {1} :::::  {2} :::::  {3} |D", gameBg[6, 3], gameBg[6, 5], gameBg[6, 7], gameBg[6, 9]);
            Console.WriteLine("     |:::::_____:::::_____:::::_____:::::_____|       ");
            Console.WriteLine("     |     :::::     :::::     :::::     :::::|       ");
            Console.WriteLine("    C|  {0} :::::  {1} :::::  {2} :::::  {3} :::::|C  ", gameBg[7, 2], gameBg[7, 4], gameBg[7, 6], gameBg[7, 8]);
            Console.WriteLine("     |_____:::::_____:::::_____:::::____ :::::|");
            Console.WriteLine("     |:::::     :::::     :::::     :::::     |       ");
            Console.WriteLine("    B|:::::  {0} :::::  {1} :::::  {2} :::::  {3} |B", gameBg[8, 3], gameBg[8, 5], gameBg[8, 7], gameBg[8, 9]);
            Console.WriteLine("     |:::::_____:::::_____:::::_____:::::_____|       ");
            Console.WriteLine("     |     :::::     :::::     :::::     :::::|       ");
            Console.WriteLine("    A|  {0} :::::  {1} :::::  {2} :::::  {3} :::::|A  ", gameBg[9, 2], gameBg[9, 4], gameBg[9, 6], gameBg[9, 8]);
            Console.WriteLine("     |_____:::::_____:::::_____:::::____ :::::|");
            Console.WriteLine("        1    2    3    4    5    6    7    8");

        }
        #endregion
    }
}

