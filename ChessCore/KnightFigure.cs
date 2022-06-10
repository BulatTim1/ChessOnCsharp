//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class KnightFigure : Figure
    {
        public KnightFigure(int x, int y) : base(x, y)
        {
        }

        public KnightFigure(string xy) : base(xy)
        {
        }

        public override bool isRightMove(int x2, int y2)
        {
            return (Math.Abs(x - x2) == 1 && Math.Abs(y - y2) == 2)
                || (Math.Abs(x - x2) == 2 && Math.Abs(y - y2) == 1);
        }
    }
}