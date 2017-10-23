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
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = 'O';
                    }
                }
            }
            for (int x = 5; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = 'X';
                    }
                }
            }
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((y % 2 == 0 && x % 2 == 0) || (y % 2 != 0 && x % 2 != 0))
                    {
                        gameBg[x, y] = 'N';
                    }
                }
            }
        }
    }
}
