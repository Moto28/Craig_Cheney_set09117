using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.ViewModels
{
    class LeaderBoard
    {
        #region creates private varibles
        private List<string> leadboard = new List<string>();
        #endregion

        #region constructor
        public LeaderBoard()
        {
            leadboard = Leadboard;
        }
        #endregion

        #region getters and setters
        public List<string> Leadboard
        {
            get
            {
                return leadboard;
            }
            set
            {
                leadboard = value;
            }
        }
        #endregion

        #region displays sorted leaderboard
        public void SortedLeaderboard()
        {
            //sorts leaderboard
            leadboard.Sort();

            //if the leaderboard has no scores displays error message
            if (leadboard.Count == 0)
            {
                Console.WriteLine("you need to play a game for your score to be stored, score are only there until you close the game");
            }

            //displays each element in leaderboard list
            foreach (var score in leadboard)
            {
                Console.WriteLine("{0}", score);
            }
            Console.ReadKey();
        }
        #endregion

    }
}
