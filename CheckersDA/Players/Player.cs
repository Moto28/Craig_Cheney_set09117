using CheckersDA.MoveMechs;

namespace CheckersDA
{
    abstract class Player
    {
        abstract public void GetPlayerName();

        abstract public void GetMoveScore();

        abstract public int GetPlayerTurnCount();

        abstract public bool MyTurn();

        abstract public bool YourTurn();

    }
}
