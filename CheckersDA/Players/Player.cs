using CheckersDA.MoveMechs;

namespace CheckersDA
{
    abstract class Player
    {
        /// <summary>
        /// gets and stores play name
        /// </summary>
        abstract public void GetPlayerName();

        /// <summary>
        /// gets and stores playerChecker
        /// </summary>       
        abstract public void GetPlayerChecker();

        /// <summary>
        ///  //gets and store the players score
        /// </summary>       
        abstract public void GetMoveScore();

        /// <summary>
        ///gets and store the players when its the players turn
        /// </summary>
        /// <returns></returns>
        abstract public int GetPlayerTurnCount();

        /// <summary>
        /// sets players turn to false
        /// </summary>
        /// <returns></returns>
        abstract public bool MyTurn();

        /// <summary>
        /// sets playerturn to true
        /// </summary>
        /// <returns></returns>
        abstract public bool YourTurn();

    }
}
