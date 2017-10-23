using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA
{
    abstract class Player
    {
        abstract public string GetPlayerName();

        //gets and store the players checker
        abstract public string GetPlayerChecker();

        //gets and store the players score
        abstract public int GetPlayerScore();

        //gets and store the players score turn time
        abstract public int SetPlayerTimer();

        //gets and store the players when its the players turn
        abstract public int GetPlayerTurnCount();

    }
}
