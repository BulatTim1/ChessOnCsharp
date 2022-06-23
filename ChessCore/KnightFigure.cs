//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class KnightFigure : Figure
    {
        public override string Type
        {
            get
            {
                return "Knight";
            }
        }
        public KnightFigure(int x, int y) : base(x, y)
        {
        }

        public KnightFigure(string xy) : base(xy)
        {
        }

        public override bool IsRightMove(int x2, int y2)
        {
            return (Math.Abs(X - x2) == 1 && Math.Abs(Y - y2) == 2)
                || (Math.Abs(X - x2) == 2 && Math.Abs(Y - y2) == 1);
        }
    }
}