using System;
using CheckersDA.MoveMechs;

namespace CheckersDA.Players
{
    class PlayerOne : Player
    {
        // creates varibles and makes them private
        private string playerName;
        private string playerChecker;
        private int playerCheckerCount = 0;
        private int playerScore;
        private int playerTimer;
        private int playerTurnCount;
        private bool isItMyTurn = true;

        //constructor
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


        /// <summary>
        /// gets and stores play name
        /// </summary>
        override public void GetPlayerName()
        {
            Console.WriteLine("\nPLAYER ONE ENTER YOUR NAME");
            playerName = Console.ReadLine();
            if (playerName.Length <= 3)
            {
                Console.WriteLine("\nyour name must be more than 3 characters");
                GetPlayerName();
                Console.Clear();
            }
        }
        /// <summary>
        /// gets and stores playerChecker
        /// </summary>  
        override public void GetPlayerChecker()
        {

        }
        /// <summary>
        ///  //gets and store the players score
        /// </summary>     
        override public void GetMoveScore()
        {

        }

        /// <summary>
        /// sets players turn to false
        /// </summary>
        /// <returns></returns>
        override public int GetPlayerTurnCount()
        {
            playerTurnCount++;
            return playerTurnCount;
        }
        public override bool MyTurn()
        {
            isItMyTurn = true;
            return isItMyTurn;
        }
        public override bool YourTurn()
        {
            isItMyTurn = false;
            return isItMyTurn;
        }
    }
}
