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
            Figure figure = figureChar switch
            {
                'P' => new PawnFigure(figureXY),
                'N' => new KnightFigure(figureXY),
                'B' => new BishopFigure(figureXY),
                'R' => new RookFigure(figureXY),
                'Q' => new QueenFigure(figureXY),
                'K' => new KingFigure(figureXY),
                _ => throw new Exception("Invalid string."),
            };
            bool isCan = figure.IsRightMove(moveXY);
            Console.WriteLine(isCan ? "YES" : "NO");

            if (isCan)
            {
                string coords1 = figure.GetCoordsHumanized();
                Console.WriteLine($"{figure} on {coords1}");
                
                figure.Move(moveXY);
                string coords2 = figure.GetCoordsHumanized();
                Console.WriteLine($"{figure} moved to {coords2}");
            }
                
        }
    }
}
