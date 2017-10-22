using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA
{
    class Player
    {
        // creates varibles and makes them private
        private string playerName;
        private string playerChecker;
        private int playerScore;
        private int playerTimer;
        private int playerTurnCount;
        private bool isItMyTurn;

        //constructor
        public Player()
        {
            //creates refrences to private vairbales to allow access outside class
            playerName = PlayerName;
            playerChecker = PlayerChecker;
            playerScore = PlayerScore;
            playerTimer = PlayerTimer;
            playerTurnCount = PlayerTurnCount;
            isItMyTurn = IsItMyTurn;
        }

        public string PlayerName
        {
            get
            {
                Console.WriteLine("Enter your name");
                playerName = Console.ReadLine();
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
                return playerChecker;
            }
            set
            {
                playerChecker = value;
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
        public string GetPlayerName()
        {
            return playerName;
        }
        //gets and store the players checker
        public string GetPlayerChecker()
        {
            return playerChecker;
        }
        //gets and store the players score
        public int GetPlayerScore()
        {
            return playerScore;
        }
        //gets and store the players score turn time
        public int SetPlayerTimer()
        {
            return playerScore;
        }
        //gets and store the players when its the players turn
        public int GetPlayerTurnCount()
        {
            return playerTurnCount;
        }



    }
}
