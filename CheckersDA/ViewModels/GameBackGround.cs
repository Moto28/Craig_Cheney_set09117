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
            for (int x = 1; x < 4; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = 'O';
                    }
                }
            }
            for (int x = 6; x <= 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = 'X';
                    }
                }
            }
            for (int x = 4; x < 6; x++)
            {
                for (int y = 1; y < 8; y++)
                {
                    if ((y % 2 == 0 && x % 2 == 0) || (y % 2 != 0 && x % 2 != 0))
                    {
                        gameBg[x, y] = '\0';
                    }
                }
            }
            gameBg[5, 2] = 'O';
            gameBg[5, 4] = 'O';
            gameBg[5, 6] = 'O';
        }
    }
}
