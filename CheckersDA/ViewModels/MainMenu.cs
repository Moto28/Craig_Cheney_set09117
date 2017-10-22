using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.ViewModels
{
    class MainMenu
    {
        private string menuSel;
        private int switchMenuSel;

        public MainMenu()
        {
            menuSel = MenuSel;
            switchMenuSel = SwitchMenuSel;
        }
        public string MenuSel
        {
            get
            {
                Menu();
                menuSel = Console.ReadLine();
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
                switchMenuSel = Convert.ToInt32(menuSel);
                return switchMenuSel;
            }
            set
            {
                switchMenuSel = SwitchMenuSel;
            }
        }

        public void Menu()
        {
            Console.Title = "Checkers";
            Console.ForegroundColor = ConsoleColor.Blue;
            var height = Console.LargestWindowHeight - 10;
            var width = Console.LargestWindowWidth - 10;
            Console.WindowHeight = height;
            Console.WindowWidth = width;
            Console.WriteLine("\n\n\n\n\n\n\n         *******************************************COMMAND LINE CHECKERS*****************************************      ");
            Console.WriteLine("         *********************************************************************************************************      ");
            Console.WriteLine("         *************************************************MAIN MENU***********************************************      ");
            Console.WriteLine("         *************************************PRESS 1 FOR A 1 PLAYER GAME*****************************************      ");
            Console.WriteLine("         *************************************PRESS 2 FOR A 2 PLAYER GAME*****************************************      ");
            Console.WriteLine("         *************************************PRESS 3 TO LOAD A SAVED GAME****************************************      ");
            Console.WriteLine("         ********************************* PRESS 4 TO WATCH A REPLAY OF A GAME************************************      ");
            Console.WriteLine("         *********************************************PRESS 5 TO QUIT*********************************************      ");
            Console.WriteLine("         *********************************************************************************************************      ");
            Console.WriteLine("         *********************************************************************************************************      ");

        }
    }
}
