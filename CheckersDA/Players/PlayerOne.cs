using System;

namespace CheckersDA.Players
{
    class PlayerOne : Player
    {
        #region creates private varibles
        private string playerName;
        private string playerChecker;
        private int playerCheckerCount = 0;
        private int playerScore;
        private int playerTimer;
        private int playerTurnCount;
        private bool isItMyTurn = true;
        #endregion

        #region constructor
        public PlayerOne()
        {
            //creates refrences to private varibales to allow access outside class
            playerName = PlayerName;
            playerChecker = PlayerChecker;
            playerCheckerCount = PlayerCheckerCount;
            playerScore = PlayerScore;
            playerTimer = PlayerTimer;
            playerTurnCount = PlayerTurnCount;
            isItMyTurn = IsItMyTurn;
        }
        #endregion

        #region getters and setters
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }
        public string PlayerChecker
        {
            get
            {
                playerChecker = "X ";
                return playerChecker;
            }
            set
            {
                playerChecker = value;
            }
        }
        public int PlayerCheckerCount
        {
            get
            {

                return playerCheckerCount;
            }
            set
            {
                playerCheckerCount = value;
            }
        }
        public int PlayerScore
        {
            get
            {
                return playerScore;
            }
            set
            {
                playerScore = value;
            }
        }
        public int PlayerTimer
        {
            get
            {
                return playerTimer;
            }
            set
            {
                playerTimer = value;
            }
        }
        public int PlayerTurnCount
        {
            get
            {
                return playerTurnCount;
            }
            set
            {
                playerTurnCount = value;
            }
        }
        public bool IsItMyTurn
        {
            get
            {

                return isItMyTurn;
            }
            set
            {
                isItMyTurn = value;
            }
        }
        #endregion

        #region gets and stores player name
        public void GetPlayerName()
        {
            Console.WriteLine("\nPLAYER ONE ENTER YOUR NAME");
            playerName = Console.ReadLine();
            //checks the player is more than 3 chars long
            if (playerName.Length <= 3)
            {
                Console.WriteLine("\nyour name must be more than 3 characters");
                GetPlayerName();
                Console.Clear();
            }
        }
        #endregion

        #region gets player turn count
        override public int GetPlayerTurnCount()
        {
            playerTurnCount++;
            return playerTurnCount;
        }
        #endregion

        #region sets player turn
        override public bool MyTurn()
        {
            //sets turn to true
            isItMyTurn = true;
            return isItMyTurn;
        }
        #endregion

        #region sets player turn
        override public bool YourTurn()
        {
            //sets turn to false
            isItMyTurn = false;
            return isItMyTurn;
        }
        #endregion
    }
}
