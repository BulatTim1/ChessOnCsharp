//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class BishopFigure : Figure
    {
        public override string Type
        {
            get
            {
                return "Bishop";
            }
        }

        public BishopFigure(int x, int y) : base(x, y)
        {
        }

        public BishopFigure(string xy) : base(xy)
        {
        }

        public override bool IsRightMove(int x2, int y2)
        {
            return Math.Abs(x2 - X) == Math.Abs(y2 - Y);
        }
    }
}