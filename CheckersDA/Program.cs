using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersDA.ViewModels;
using CheckersDA.MoveConvertor;

namespace CheckersDA
{
    class Program
    {



        static char[,] gameBg = new char[8, 8];
        static bool win;

        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            GameBackGround backGround = new GameBackGround();
            GameBoard game = new GameBoard();
            Player playerOne = new Player();
            IsInputValid valid = new IsInputValid();


            Console.Title = "Checkers";

            switch (menu.SwitchMenuSel)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n                                            you have selected a 1 player game");
                    playerOne.GetPlayerName();
                    backGround.Objects(gameBg);
                    game.Draw(gameBg, win);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("you have selected a 2 player game");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("you have selected to load a game");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.WriteLine("you have selected to watch a previously played game");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.WriteLine("you have chosen to quit");
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
