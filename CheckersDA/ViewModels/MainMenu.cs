using CheckersDA.Players;
using System;
using CheckersDA.Game;


namespace CheckersDA.ViewModels
{
    class MainMenu
    {
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
            var height = Console.LargestWindowHeight / 2;
            var width = Console.LargestWindowWidth / 2;
            Console.WindowHeight = height;
            Console.WindowWidth = width;
            Console.Title = "Checkers";
            string mainMenu = @"   









                                                                 
                           |▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬|
                           |(¯`·._.·(¯`·._.(¯`·._.Command Line Checkers._.·´¯)·._.·´¯)·._.´¯)|
                           | \/ /\/ /\_/ /\/ /\/|  1. One Player Game  | \/ /\/ /\_/ /\/ /\/ |
                           |___/\ \/\___/\ \/\__|  2. Two Player Game  |___/\ \/\___/\ \/\___|
                           |   \/\ \/   \/\ \/  |  3.Replay Last Game  |   \/\ \/   \/\ \/   |
                           |___/\ \/\___/\ \/\__|     4. Quit Game      |___/\ \/\___/\ \/\__|
                           |▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬|
                                     Enter Your Selection and Press Enter to Continue                    
                                                                    ";

            Console.WriteLine(mainMenu);

            try
            {
                menuSel = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.ReadKey();
            }

        }
    }
}
