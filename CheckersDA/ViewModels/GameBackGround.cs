using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.ViewModels
{
    class GameBackGround
    {
        public void Objects(string[,] gameBg)
        {
            for (int x = 0; x <= 13; x++)
            {
                for (int y = 0; y <= 13; y++)
                {
                    gameBg[x, y] = "N ";
                }
            }
            for (int x = 2; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {

                    gameBg[x, y] = "\0 ";

                }
            }
            for (int x = 2; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 == 0) || (y % 2 != 0 && x % 2 != 0))
                    {
                        gameBg[x, y] = "N ";
                    }
                }
            }
            for (int x = 2; x <= 4; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = "O ";
                    }
                }
            }
            for (int x = 7; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = "X ";
                    }
                }
            }
        }
    }
}
