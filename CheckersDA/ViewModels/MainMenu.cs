using CheckersDA.Players;
using System;
using CheckersDA.Game;


namespace CheckersDA.ViewModels
{
    class MainMenu
    {
        PlayerOne playerOne = new PlayerOne();
        PlayerTwo playerTwo = new PlayerTwo();
        GameBackGround backGround = new GameBackGround();
        GameBoard game = new GameBoard();


        private int menuSel;
        private int switchMenuSel;

        public MainMenu()
        {
            menuSel = MenuSel;
            switchMenuSel = SwitchMenuSel;
        }
        public int MenuSel
        {
            get
            {
                return menuSel;
            }
            set
            {
                menuSel = MenuSel;
            }
        }
        public int SwitchMenuSel
        {
            get
            {
                return switchMenuSel;
            }
            set
            {
                switchMenuSel = SwitchMenuSel;
            }
        }

        public void Menu(string[,] gameBg)
        {
            Console.Title = "Checkers";
            Console.ForegroundColor = ConsoleColor.Blue;
            var height = Console.LargestWindowHeight - 10;
            var width = Console.LargestWindowWidth - 10;
            Console.WindowHeight = height;
            Console.WindowWidth = width;
            Console.Title = "Checkers";
            Console.WriteLine("\n\n\n\n\n\n\n         *******************************************COMMAND LINE CHECKERS*****************************************      ");
            Console.WriteLine("         *********************************************************************************************************      ");
            Console.WriteLine("         *************************************************MAIN MENU***********************************************      ");
            Console.WriteLine("         *************************************PRESS 1 FOR A 1 PLAYER GAME*****************************************      ");
            Console.WriteLine("         *************************************PRESS 2 FOR A 2 PLAYER GAME*****************************************      ");
            Console.WriteLine("         *********************************************PRESS 3 TO QUIT*********************************************      ");
            Console.WriteLine("         *********************************************************************************************************      ");
            Console.WriteLine("         *********************************************************************************************************      ");
            Console.WriteLine("\nPlease enter your menu selection:\n");


            try
            {
                menuSel = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                e.Message.ToString();
                Console.Clear();
                Menu(gameBg);
            }

        }
    }
}
