﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.ViewModels
{
    class Win
    {
        #region draws win screen
        public void Winner()
        {
            //stores the winners screen
            string winnerScreen = @"




                                                                $$\      $$\ $$\                                         
                                                                $$ | $\  $$ |\__|                                        
                                                                $$ |$$$\ $$ |$$\ $$$$$$$\  $$$$$$$\   $$$$$$\   $$$$$$\  
                                                                $$ $$ $$\$$ |$$ |$$  __$$\ $$  __$$\ $$  __$$\ $$  __$$\ 
                                                                $$$$  _$$$$ |$$ |$$ |  $$ |$$ |  $$ |$$$$$$$$ |$$ |  \__|
                                                                $$$  / \$$$ |$$ |$$ |  $$ |$$ |  $$ |$$   ____|$$ |      
                                                                $$  /   \$$ |$$ |$$ |  $$ |$$ |  $$ |\$$$$$$$\ $$ |      
                                                                \__/     \__|\__|\__|  \__|\__|  \__| \_______|\__|      
                                                                                                                         
                                                                                                                         
                                                                                                                         
                                                                
                                                                                                 ,.   '\'\    ,---.
                                                                Quiet, Pinky; I'm pondering.    | \\  l\\l_ //    |   Err ... right,
                                                                       _              _         |  \\/ `/  `.|    |   Brain!  Narf!
                                                                     /~\\   \        //~\       | Y |   |   ||  Y |
                                                                     |  \\   \      //  |       |  \|   |   |\ /  |   /
                                                                     [   ||        ||   ]       \   |  o|o  | >  /   /
                                                                    ] Y  ||        ||  Y [       \___\_--_ /_/__/
                                                                    |  \_|l,------.l|_/  |       /.-\(____) /--.\
                                                                    |   >'          `<   |       `--(______)----'
                                                                    \  (/~`--____--'~\)  /           U// U / \
                                                                     `-_>-__________-<_-'            / \  / /|
                                                                         /(_#(__)#_)\               ( .) / / ]
                                                                         \___/__\___/                `.`' /   [
                                                                          /__`--'__\                  |`-'    |
                                                                       /\(__,>-~~ __)                 |       |__
                                                                    /\//\\(  `--~~ )                 _l       |--:.
                                                                    '\/  <^\      /^>               |  `   (  <   \\
                                                                         _\ >-__-< /_             ,-\  ,-~~->. \   `:.___,/
                                                                        (___\    /___)           (____/    (____)    `---'
                                                                
        ";
            Console.WriteLine(winnerScreen);
            Console.ReadKey();
        }
        #endregion
    }
}
