//Timurshin Bulat, 220 group, Chess Figures 4
using System;

namespace ChessCore
{
    public class KingFigure : Figure
    {
        public override string Type
        {
            get
            {
                return "King";
            }
        }
        public KingFigure(int x, int y) : base(x, y)
        {
        }

        public KingFigure(string xy) : base(xy)
        {
        }

        public override bool isRightMove(int x2, int y2)
        {
            return (X == x2 && Math.Abs(Y - y2) == 1)
                || (Math.Abs(X - x2) == 1 && Y == y2)
                || (Math.Abs(x2 - X) == Math.Abs(y2 - Y)
                    && Math.Abs(y2 - Y) == 1);
        }
    }
}