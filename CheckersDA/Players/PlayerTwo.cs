using System;
using CheckersDA.MoveMechs;

namespace CheckersDA.Players
{
    class PlayerTwo : Player
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
        public PlayerTwo()
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
                playerChecker = "O ";
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
        override public void GetPlayerName()
        {
            Console.WriteLine("\nPLAYER TWO ENTER YOUR NAME");
            playerName = Console.ReadLine();
            //checks the player is more than 3 chars long
            if (playerName.Length <= 3)
            {
                Console.WriteLine("\nyour name must be more than 3 characters, try again");
                GetPlayerName();
                Console.Clear();
            }
        }
        #endregion

        override public void GetMoveScore()
        {

        }

        #region gets player turn count
        override public int GetPlayerTurnCount()
        {
            playerTurnCount++;
            return playerTurnCount;
        }
        #endregion

        #region sets player turn
        public override bool MyTurn()
        {
            //sets turn to true
            isItMyTurn = true;
            return isItMyTurn;
        }
        #endregion

        #region sets player turn
        public override bool YourTurn()
        {
            //sets turn to false
            isItMyTurn = false;
            return isItMyTurn;
        }
        #endregion

    }
}
