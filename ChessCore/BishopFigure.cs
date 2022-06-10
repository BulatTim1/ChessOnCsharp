//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class BishopFigure : Figure
    {
        public BishopFigure(int x, int y) : base(x, y)
        {
        }

        public BishopFigure(string xy) : base(xy)
        {
        }

        public override bool isRightMove(int x2, int y2)
        {
            return Math.Abs(x2 - x) == Math.Abs(y2 - y);
        }
    }
}