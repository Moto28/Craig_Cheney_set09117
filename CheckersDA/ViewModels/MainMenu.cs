using System;


namespace CheckersDA.ViewModels
{
    class MainMenu
    {
        #region creates private varibles
        private int menuSel;
        private int switchMenuSel;
        #endregion

        #region constructor
        public MainMenu()
        {
            menuSel = MenuSel;
            switchMenuSel = SwitchMenuSel;
        }
        #endregion

        #region getters and setters
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
        #endregion

        #region draws the menu
        public void Menu(string[,] gameBg)
        {
            Console.Title = "Checkers";
            //changes text colour
            Console.ForegroundColor = ConsoleColor.White;
            //gets the largest height and width /2 and sets as window size
            var height = Console.LargestWindowHeight / 2;
            var width = Console.LargestWindowWidth / 2;
            Console.WindowHeight = height;
            Console.WindowWidth = width;
            //sets window name
            Console.Title = "Checkers";

            string mainMenu = @"   









                                                                 
                           |▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬|
                           |(¯`·._.·(¯`·._.(¯`·._.Command Line Checkers._.·´¯)·._.·´¯)·._.´¯)|
                           | \/ /\/ /\_/ /\/ /\/|  1. One Player Game  | \/ /\/ /\_/ /\/ /\/ |
                           |___/\ \/\___/\ \/\__|  2. Two Player Game  |___/\ \/\___/\ \/\___|
                           |   \/\ \/   \/\ \/  |  3. Replay Last Game |   \/\ \/   \/\ \/   |
                           |___/\ \/\___/\ \/\__|  4. Leaderboard      |___/\ \/\___/\ \/\___|
                           |___/\ \/\___/\ \/\__|  5. Quit Game        |___/\ \/\___/\ \/\___|
                           |▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬|
                                     Enter Your Selection and Press Enter to Continue                    
                                                                    ";

            Console.WriteLine(mainMenu);

            try
            {
                //gets menu input
                menuSel = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
    #endregion
}
