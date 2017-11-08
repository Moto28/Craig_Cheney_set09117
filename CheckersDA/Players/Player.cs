using CheckersDA.MoveMechs;

namespace CheckersDA
{
    abstract class Player
    {
        abstract public void GetPlayerName();

        //gets and store the players checker
        abstract public string GetPlayerChecker();

        //gets and store the players score
        abstract public int GetMoveScore(CollisionDect collisionDect);

        //gets and store the players score turn time
        abstract public int SetPlayerTimer();

        //gets and store the players when its the players turn
        abstract public int GetPlayerTurnCount();
        abstract public int GetPlayerCheckerCount(char[,] gameBg);
        abstract public bool MyTurn();
        abstract public bool YourTurn();

    }
}
