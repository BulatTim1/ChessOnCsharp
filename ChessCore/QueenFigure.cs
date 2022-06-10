//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class QueenFigure : Figure
    {
        public QueenFigure(int x, int y) : base(x, y)
        {
        }

        public QueenFigure(string xy) : base(xy)
        {
        }

        public override bool isRightMove(int x2, int y2)
        {
            return (x == x2 && y != y2)
                || (x != x2 && y == y2)
                || (Math.Abs(x2 - x) == Math.Abs(y2 - y));
        }
    }
}