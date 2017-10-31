using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.ViewModels
{
    class GameBackGround
    {
        public void Objects(char[,] gameBg)
        {
            for (int x = 2; x <= 4; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = 'O';
                    }
                }
            }
            for (int x = 7; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = 'X';
                    }
                }
            }
            for (int x = 6; x <= 8; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 == 0) || (y % 2 != 0 && x % 2 != 0))
                    {
                        gameBg[x, y] = '\0';
                    }
                }
            }
            for (int x = 0; x < 2; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    gameBg[x, y] = 'N';
                }
            }
            for (int x = 0; x < 11; x++)
            {
                for (int y = 0; y <= 1; y++)
                {
                    gameBg[x, y] = 'N';
                }
            }
            for (int x = 10; x <= 11; x++)
            {
                for (int y = 0; y <= 11; y++)
                {
                    gameBg[x, y] = 'N';
                }
            }
            for (int x = 0; x <= 11; x++)
            {
                for (int y = 10; y <= 11; y++)
                {
                    gameBg[x, y] = 'N';
                }
            }

            gameBg[6, 5] = 'O';
            gameBg[3, 8] = '\0';
        }

    }
}
