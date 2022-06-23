//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class PawnFigure : Figure
    {
        public override string Type
        {
            get
            {
                return "Pawn";
            }
        }
        
        private bool firstMove = false;
        private bool black = true;

        public PawnFigure(int x, int y) : base(x, y)
        {
            if (y == 1 || y == 6) firstMove = true;
        }

        public PawnFigure(string xy) : base(xy)
        {
            if (Y == 1 || Y == 6) firstMove = true;
        }

        public override bool IsRightMove(int x2, int y2)
        {
            return X == x2 && 
                (firstMove && 
                black && (y2 - Y == 1 || y2 - Y == 2) ||
                (!black && (y2 - Y == -1 || y2 - Y == -2)
                ) || 
                (black && y2 - Y == 1) ||
                (!black && y2 - Y == -1));
            //TODO: collision with another figures
        }

        public override bool Move(int x, int y)
        {
            bool res = base.Move(x, y);
            if (res)
            {
                firstMove = false;
            }
            return res;
        }
    }
}