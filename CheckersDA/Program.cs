using System;
using CheckersDA.ViewModels;
using CheckersDA.MoveMechs;
using CheckersDA.Game;
using CheckersDA.Players;

namespace CheckersDA
{
    class Program
    {

        static void Main(string[] args)
        {
            #region instantiates classes needed 
            MainMenu menu = new MainMenu();
            Win isItWin = new Win();
            GameBoard game = new GameBoard();
            GameLogic logic = new GameLogic();
            PlayerOne playerOne = new PlayerOne();
            PlayerTwo playerTwo = new PlayerTwo();
            AiPlayer aiPlayer = new AiPlayer();
            GameBackGround background = new GameBackGround();
            WatchReplay watch = new WatchReplay();
            #endregion

            #region draws menu and allows user to exit, pick game mode or watch replay 
            while (menu.MenuSel != 4)
            {
                menu.Menu(game.GameBg);

                switch (menu.MenuSel)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n                                            you have selected a 1 player game");
                        //adds objects to array
                        background.Objects(game.GameBg);
                        //gets players names
                        playerOne.GetPlayerName();
                        aiPlayer.GetPlayerName();
                        //draws game board
                        game.Draw(game.GameBg, playerOne, aiPlayer);
                        Console.Clear();
                        //loops through logic until win not true
                        while (logic.Win != true)
                        {
                            logic.Logic(game.GameBg, playerOne, aiPlayer, watch);
                        }
                        //when logic is true draws win screen
                        if (logic.Win == true)
                        {
                            Console.Clear();
                            isItWin.Winner();
                        }
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("                                                     you have selected a 2 player game");
                        background.Objects(game.GameBg);
                        playerOne.GetPlayerName();
                        playerTwo.GetPlayerName();
                        Console.Clear();
                        while (logic.Win != true)
                        {
                            logic.Logic(game.GameBg, playerOne, playerTwo, watch);
                        }

                        if (logic.Win == true)
                        {
                            Console.Clear();
                            isItWin.Winner();
                        }
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("                                                    you have chosen to watch the replay of the last game");
                        //starts replay
                        watch.Replay(game, playerOne, playerTwo);
                        break;
                    case 4:
                        Console.WriteLine("                                                    you have chosen to quit");
                        Environment.Exit(0);
                        break;
                }
                #endregion
            }
        }
    }
}
