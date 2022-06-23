using System;
using System.Collections.Generic;
using System.Text;

namespace ChessCore
{
    internal class Gameboard
    {
        private Figure[,] board;
        
        public Gameboard ()
        {
            board = new Figure[8, 8];
        }
    }
}
