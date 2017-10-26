using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.MoveMechs
{
    class ForceMove
    {
        List<int> forceMoveList = new List<int>();
        int[,] force = new int[4, 4];
        public void ForceJump(char[,] gameBg, int row, int col)
        {
            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    string test = gameBg[x, y].ToString();

                    if (test.Contains("X") && gameBg[x - 1, y] == '\0')
                    {

                        forceMoveList.Add(x);
                        forceMoveList.Sort();
                    }
                }
            }
            int testv = forceMoveList.First();

            for (int y = 1; y < 9; y++)
            {
                string test = gameBg[testv - 1, y].ToString();
                if (test.Contains("O") && gameBg[testv - 2, y].ToString() == "\0")
                {
                    int gTR = testv - 1;
                    int gTC = y;
                    for (int x = 0; x < 5; x++)
                    {
                        force[x, y] = gTR;
                        for (int z = 0; z < 5; y++)
                        {
                            force[x, z] = gTC;
                        }
                    }
                }

            }

        }
    }
}
