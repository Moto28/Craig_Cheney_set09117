using System;
using CheckersDA.MoveMechs;

namespace CheckersDA.Players
{
    class PlayerTwo : Player
    {
        // creates varibles and makes them private
        private string playerName;
        private string playerChecker;
        private int playerCheckerCount;
        private int playerScore;
        private int playerTimer;
        private int playerTurnCount;
        private bool isItMyTurn;

        //constructor
        public PlayerTwo()
        {
            //creates refrences to private vairbales to allow access outside class
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


        //gets and store the player name
        override public void GetPlayerName()
        {
            Console.WriteLine("\nPLAYER TWO ENTER YOUR NAME");
            playerName = Console.ReadLine();
            if (playerName.Length <= 3)
            {
                Console.WriteLine("\nyour name must be more than 3 characters, try again");
                GetPlayerName();
                Console.Clear();
            }
        }
        //gets and store the players checker
        override public void GetPlayerChecker()
        {
            playerChecker = "O ";
        }
        //gets and store the players score
        override public void GetMoveScore()
        {

        }

        //gets and store the players when its the players turn
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
