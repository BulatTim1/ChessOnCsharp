//Timurshin Bulat, 220 group, Chess Figures 4

namespace ChessCore
{
    public class RookFigure : Figure
    {

        public override string Type
        {
            get
            {
                return "Rook";
            }
        }
        public RookFigure(int x, int y) : base(x, y)
        {
        }

        public RookFigure(string xy) : base(xy)
        {
        }

        public override bool isRightMove(int x2, int y2)
        {
            return X == x2 || Y == y2;
        }
    }
}