//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class QueenFigure : Figure
    {
        public override string Type
        {
            get
            {
                return "Queen";
            }
        }
        public QueenFigure(int x, int y) : base(x, y)
        {
        }

        public QueenFigure(string xy) : base(xy)
        {
        }

        public override bool isRightMove(int x2, int y2)
        {
            return (X == x2 && Y != y2)
                || (X != x2 && Y == y2)
                || (Math.Abs(x2 - X) == Math.Abs(y2 - Y));
        }
    }
}