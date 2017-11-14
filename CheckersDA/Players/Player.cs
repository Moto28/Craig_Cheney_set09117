using CheckersDA.MoveMechs;

namespace CheckersDA
{
    abstract class Player
    {

        abstract public int GetPlayerTurnCount();


        abstract public bool MyTurn();


        abstract public bool YourTurn();


    }
}
