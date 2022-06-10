//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class KingFigure : Figure
    {
        public KingFigure(int x, int y) : base(x, y)
        {
        }

        public KingFigure(string xy) : base(xy)
        {
        }

        public override bool isRightMove(int x2, int y2)
        {
            return (x == x2 && Math.Abs(y - y2) == 1)
                || (Math.Abs(x - x2) == 1 && y == y2)
                || (Math.Abs(x2 - x) == Math.Abs(y2 - y)
                    && Math.Abs(y2 - y) == 1);
        }
    }
}