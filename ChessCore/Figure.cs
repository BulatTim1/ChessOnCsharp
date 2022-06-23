//Timurshin Bulat, 220 group, Chess Figures 4
using System;
using System.IO;

namespace ChessCore
{
    //for future review
    struct Point
    {
        int X;
        int Y;
    }
    
    abstract public class Figure
    {
        protected int X, Y; //x - (1..8), y - a..h

        public virtual string Type
        {
            get 
            { 
                return "Figure";
            }
        }

        public Figure(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Figure(string xy)
        {
            int[] coords = StringToXY(xy);
            X = coords[0];
            Y = coords[1];
        }

        protected int[] StringToXY(string xy)   //{a..h},{1..8} -> {0..7},{0..7}
        {
            if (xy.Length != 2) throw new Exception($"Invalid string: {xy}.");

            xy = xy.ToLower();
            char xChar = xy[0];
            int y;

            y = (int)xy[1] - '0' - 1;
            if (y < 0 || y > 7) throw new Exception($"Invalid string: {xy}.");
            var x = xChar switch
            {
                'a' => 0,
                'b' => 1,
                'c' => 2,
                'd' => 3,
                'e' => 4,
                'f' => 5,
                'g' => 6,
                'h' => 7,
                _ => throw new Exception($"Invalid string: {xy}."),
            };
            return new int[] { x, y };
        }

        public abstract bool IsRightMove(int x2, int y2);

        public bool IsRightMove(string xy)
        {
            int[] coords = StringToXY(xy);
            return IsRightMove(coords[0], coords[1]);
        }

        public bool Move(string xy) //{a..h}{1..8}
        {
            int[] coords = StringToXY(xy);
            return Move(coords[0], coords[1]);
        }

        public virtual bool Move(int x2, int y2)    //0..7, 0..7
        {
            if (IsRightMove(x2, y2))
            {
                X = x2;
                Y = y2;
                return true;
            }
            return false;
        }

        public int[] GetCoords()
        {
            return new int[] { X, Y };
        }

        public string GetCoordsHumanized()
        {
            string xy = "";
            switch (X)
            {
                case 0: xy += 'a'; break;
                case 1: xy += 'b'; break;
                case 2: xy += 'c'; break;
                case 3: xy += 'd'; break;
                case 4: xy += 'e'; break;
                case 5: xy += 'f'; break;
                case 6: xy += 'g'; break;
                case 7: xy += 'h'; break;
            }
            xy += (Y + 1);
            return xy;
        }

        public override string ToString()
        {
            return Type;
        }
    }
}