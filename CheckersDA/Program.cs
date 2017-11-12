﻿using System;
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
            MainMenu menu = new MainMenu();
            Win isItWin = new Win();
            GameBoard game = new GameBoard();
            GameLogic logic = new GameLogic();
            PlayerOne playerOne = new PlayerOne();
            PlayerTwo playerTwo = new PlayerTwo();
            AiPlayer aiPlayer = new AiPlayer();
            GameBackGround background = new GameBackGround();
            WatchReplay watch = new WatchReplay();

            while (menu.MenuSel != 4)
            {
                menu.Menu(game.GameBg);

                switch (menu.MenuSel)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n                                            you have selected a 1 player game");
                        background.Objects(game.GameBg);
                        playerOne.GetPlayerName();
                        aiPlayer.GetPlayerName();
                        game.Draw(game.GameBg, playerOne, aiPlayer);
                        Console.Clear();
                        while (logic.Win != true)
                        {
                            logic.Logic(game.GameBg, playerOne, aiPlayer, watch);
                        }

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
                        watch.Replay(game, playerOne, playerTwo);
                        break;
                    case 4:
                        Console.WriteLine("                                                    you have chosen to quit");
                        Environment.Exit(0);
                        break;
                }

                //creates a while loop that draws the board until the win condition is met. it then takes user input to passes it to IsInputValid then CollisionDect if the input is valid passes move to next player 



            }
        }

    }
}
