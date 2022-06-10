//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class PawnFigure : Figure
    {
        private bool firstMove = false;

        public PawnFigure(int x, int y) : base(x, y)
        {
            if (y == 1 || y == 6) firstMove = true;
        }

        public PawnFigure(string xy) : base(xy)
        {
            if (y == 1 || y == 6) firstMove = true;
        }

        public override bool isRightMove(int x2, int y2)
        {
            return ((x == x2 && firstMove
                    && (Math.Abs(y2 - y) == 1 || Math.Abs(y2 - y) == 2))
                || (x == x2 && Math.Abs(y2 - y) == 1));
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