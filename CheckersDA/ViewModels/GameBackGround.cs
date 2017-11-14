namespace CheckersDA.ViewModels
{
    class GameBackGround
    {
        #region add game objects to gameBg array
        public void Objects(string[,] gameBg)
        {
            //draws N all over the Board
            for (int x = 0; x <= 13; x++)
            {
                for (int y = 0; y <= 13; y++)
                {
                    gameBg[x, y] = "N ";
                }
            }
            //then emptys spaces for the gameboard
            for (int x = 2; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {

                    gameBg[x, y] = "\0 ";

                }
            }
            //adds N to the squares on the gameboard players can't move into 
            for (int x = 2; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 == 0) || (y % 2 != 0 && x % 2 != 0))
                    {
                        gameBg[x, y] = "N ";
                    }
                }
            }
            //adds PlayerTwo chekers to the board
            for (int x = 2; x <= 4; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = "O ";
                    }
                }
            }
            //adds playerOne checkers to the board
            for (int x = 7; x <= 9; x++)
            {
                for (int y = 2; y <= 9; y++)
                {
                    if ((y % 2 == 0 && x % 2 != 0) || (y % 2 != 0 && x % 2 == 0))
                    {
                        gameBg[x, y] = "X ";
                    }
                }
            }
        }
        #endregion
    }
}
