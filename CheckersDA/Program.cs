using System;
using CheckersDA.ViewModels;
using CheckersDA.Game;
using CheckersDA.Players;

namespace CheckersDA
{
    class Program
    {

        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            GameBoard game = new GameBoard();
            GameLogic logic = new GameLogic();
            PlayerOne playerOne = new PlayerOne();
            PlayerTwo playerTwo = new PlayerTwo();
            GameBackGround background = new GameBackGround();

            menu.Menu(game.GameBg);

            switch (menu.MenuSel)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n                                            you have selected a 1 player game");
                    background.Objects(game.GameBg);
                    playerOne.GetPlayerName();
                    game.Draw(game.GameBg, playerOne, playerTwo);
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("                                                     you have selected a 2 player game");
                    background.Objects(game.GameBg);
                    playerOne.GetPlayerName();
                    playerTwo.GetPlayerName();
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("                                                    you have chosen to quit");
                    Environment.Exit(0);
                    break;
            }

            //creates a while loop that draws the board until the win condition is met. it then takes user input to passes it to IsInputValid then CollisionDect if the input is valid passes move to next player 
            while (logic.Win != true)
            {
                logic.Logic(game.GameBg, playerOne, playerTwo);
            }
        }

    }
}
