﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersDA.ViewModels
{
    class GameRules
    {
        public void DisplayRules()
        {
            Console.Clear();
            string rules = @"Game Basics

            Checkers is played by two players. Each player begins the game with 12 colored discs. (Typically, one set of pieces is black and the other red.) Each player places his or her pieces on the 12 dark squares closest to him or her. 
            Black moves first. Players then alternate moves.
            
            The board consists of 64 squares, alternating between 32 dark and 32 light squares.
            
            It is positioned so that each player has a light square on the right side corner closest to him or her.
            
            A player wins the game when the opponent cannot make a move. In most cases, this is because all of the opponent's pieces have been captured, but it could also be because all of his pieces are blocked in.
            
            Rules of the Game
            
            Moves are allowed only on the dark squares, so pieces always move diagonally. Single pieces are always limited to forward moves (toward the opponent).
            A piece making a non-capturing move (not involving a jump) may move only one square.
            A piece making a capturing move (a jump) leaps over one of the opponent's pieces, landing in a straight diagonal line on the other side. Only one piece may be captured in a single jump; however, multiple jumps are allowed                                       
            during a single turn.

            When a piece is captured, it is removed from the board.
            If a player is able to make a capture, there is no option; the jump must be made. If more than one capture is available, the player is free to choose whichever he or she prefers.
            When a piece reaches the furthest row from the player who controls that piece, it is crowned and becomes a king. 
            Kings are limited to moving diagonally but may move both forward and backward. (Remember that single pieces, i.e. non-kings, are always limited to forward moves.)
            Kings may combine jumps in several directions, forward and backward, on the same turn. Single pieces may shift direction diagonally during a multiple capture turn, but must always jump forward (toward the opponent).";
            Console.WriteLine(rules);
            Console.ReadKey();
        }
    }
}
