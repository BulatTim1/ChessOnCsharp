//Timurshin Bulat, 220 group, Chess Figures 4
using System;
using System.IO;

namespace ChessCore
{
    abstract public class Figure
    {
        protected int x, y; //x - (1..8), y - a..h

        public Figure(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Figure(string xy)
        {
            try
            {
                int[] coords = StringToXY(xy);
                x = coords[0];
                y = coords[1];
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Invalid string!"); //its right?
                return;
            }
        }

        protected int[] StringToXY(string xy)   //{a..h},{1..8} -> {0..7},{0..7}
        {
            if (xy.Length != 2) throw new Exception($"Invalid string: {xy}.");

            xy = xy.ToLower();
            char xChar = xy[0];
            int x, y;

            y = (int)xy[1] - '0' - 1;
            if (y < 0 || y > 7) throw new Exception($"Invalid string: {xy}.");

            switch (xChar)
            {
                case 'a': x = 0; break;
                case 'b': x = 1; break;
                case 'c': x = 2; break;
                case 'd': x = 3; break;
                case 'e': x = 4; break;
                case 'f': x = 5; break;
                case 'g': x = 6; break;
                case 'h': x = 7; break;
                default: throw new Exception($"Invalid string: {xy}.");
            }

            return new int[] { x, y };
        }

        public abstract bool isRightMove(int x2, int y2);

        public virtual bool isRightMove(string xy)
        {
            int x2, y2;
            try
            {
                int[] coords = StringToXY(xy);
                x2 = coords[0];
                y2 = coords[1];
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Invalid string!"); //its right?
                return false;
            }
            return isRightMove(x2, y2);
        }

        public virtual bool Move(string xy) //{a..h}{1..8}
        {
            int x2, y2;
            try
            {
                int[] coords = StringToXY(xy);
                x2 = coords[0];
                y2 = coords[1];
            }
            catch (InvalidDataException)
            {
                Console.WriteLine("Invalid string!"); //its right?
                return false;
            }
            return Move(x2, y2);
        }

        public bool Move(int x2, int y2)    //0..7, 0..7
        {
            if (isRightMove(x2, y2))
            {
                x = x2;
                y = y2;
                return true;
            }
            return false;
        }

        public int[] GetCoords()
        {
            return new int[] { x, y };
        }

        public string GetCoordsHumanized()
        {
            string xy = "";
            switch (x)
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
            xy += (y + 1);
            return xy;
        }
    }
}