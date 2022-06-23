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

        public PawnFigure(int x, int y) : base(x, y)
        {
            if (y == 1 || y == 6) firstMove = true;
        }

        public PawnFigure(string xy) : base(xy)
        {
            if (Y == 1 || Y == 6) firstMove = true;
        }

        public override bool isRightMove(int x2, int y2)
        {
            return ((X == x2 && firstMove
                    && (Math.Abs(y2 - Y) == 1 || Math.Abs(y2 - Y) == 2))
                || (X == x2 && Math.Abs(y2 - Y) == 1));
            //TODO: collision with another figures
        }

        public override bool Move(string xy)
        {
            bool res = base.Move(xy);
            if (res)
            {
                firstMove = false;
            }
            return res;
        }
    }
}