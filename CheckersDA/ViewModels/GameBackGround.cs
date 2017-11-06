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
            for (int x = 5; x <= 6; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    gameBg[x, y] = "\0 ";
                }
            }
            for (int x = 0; x < 2; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    gameBg[x, y] = "N";
                }
            }
            for (int x = 0; x < 11; x++)
            {
                for (int y = 0; y <= 1; y++)
                {
                    gameBg[x, y] = "N";
                }
            }
            for (int x = 10; x <= 11; x++)
            {
                for (int y = 0; y <= 11; y++)
                {
                    gameBg[x, y] = "N";
                }
            }
            for (int x = 0; x <= 11; x++)
            {
                for (int y = 10; y <= 11; y++)
                {
                    gameBg[x, y] = "N";
                }
            }

            gameBg[7, 4] = "\0 ";
            gameBg[7, 8] = "\0 ";
            ////gameBg[7, 7] = "\0 ";
            gameBg[6, 5] = "kX";
            gameBg[6, 7] = "kX";
            gameBg[4, 5] = "kX";
            gameBg[4, 7] = "kX";
            gameBg[5, 6] = "kO";
            gameBg[4, 3] = "\0 ";
            gameBg[3, 4] = "\0 ";
            gameBg[3, 8] = "\0 ";




        }

    }
}
