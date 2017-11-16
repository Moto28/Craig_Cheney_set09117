using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CheckersDA.ViewModels
{
    class LeaderBoard
    {
        #region creates private varibles
        private List<string> leaderboard = new List<string>();
        #endregion

        #region constructor
        public LeaderBoard()
        {
            leaderboard = Leaderboard;
        }
        #endregion

        #region getters and setters
        public List<string> Leaderboard
        {
            get
            {
                return leaderboard;
            }
            set
            {
                leaderboard = value;
            }
        }
        #endregion

        #region displays sorted leaderboard
        public void SortedLeaderboard()
        {
            string[] defaultScores = new string[] { " 50: Fenix", "45: Sean", "40: Lizzy", "35: Kayden", "100: Joe", "70: Kelly", "60: Scott", "55: Bussa", "80: Pickle Rick", "75: Craig", };

            //displays each element in leaderboard list
            foreach (var score in defaultScores)
            {
                leaderboard.Add(score);
            }

            //sorts the leaderboard based on the highest number
            leaderboard.Sort((a, b) =>
            {
                var x = int.Parse(Regex.Replace(a, "[^0-9]", ""));
                var y = int.Parse(Regex.Replace(b, "[^0-9]", ""));
                if (x != y) return y - x;
                return -1 * string.Compare(a, b);
            });

            //prints the leaderboard to screen
            Console.Clear();
            int i = 0;
            foreach (var score in leaderboard)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, score);
            }

            Console.ReadKey();
            Console.Clear();
        }
        #endregion

    }
}
