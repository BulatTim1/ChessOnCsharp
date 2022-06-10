//Timurshin Bulat, 220 group, Chess Figures 4
using System;
using ChessCore;

namespace ChessConsole
{
    class Program
    {
        static void Main()
        {
            char figureChar = Console.ReadLine()[0];
            string figureXY = Console.ReadLine();
            string moveXY = Console.ReadLine();

            Figure figure;

            switch (figureChar)
            {
                case 'P':
                    figure = new PawnFigure(figureXY);
                    break;
                case 'N':
                    figure = new KnightFigure(figureXY);
                    break;
                case 'B':
                    figure = new BishopFigure(figureXY);
                    break;
                case 'R':
                    figure = new RookFigure(figureXY);
                    break;
                case 'Q':
                    figure = new QueenFigure(figureXY);
                    break;
                case 'K':
                    figure = new KingFigure(figureXY);
                    break;
                default:
                    throw new Exception("Invalid string.");
            }

            bool isCan = figure.isRightMove(moveXY);

            string coords1 = figure.GetCoordsHumanized();
            figure.Move(moveXY);
            string coords2 = figure.GetCoordsHumanized();

            Console.WriteLine(isCan ? "YES" : "NO");
            Console.WriteLine($"{figure} on {coords1}");
            Console.WriteLine($"{figure} moved to {coords2}");
        }
    }
}
