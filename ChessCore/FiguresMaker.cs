using System.Collections.Generic;

namespace ChessCore
{
    public class FiguresData
    {
        public string Name;
        public Dictionary<string, int> Data;

        public override string ToString()
        {
            return Name;
        }
    }

    static public class FigureFab
    {
        public static Figure Make(FiguresData figData)
        {
            Figure fig = null;

            switch (figData.Name)
            {
                case "Bishop":
                    fig = new BishopFigure(figData.Data["X"], figData.Data["Y"]);
                    break;
                case "King":
                    fig = new KingFigure(figData.Data["X"], figData.Data["Y"]);
                    break;
                case "Knight":
                    fig = new KnightFigure(figData.Data["X"], figData.Data["Y"]);
                    break;
                case "Pawn":
                    fig = new PawnFigure(figData.Data["X"], figData.Data["Y"]);
                    break;
                case "Queen":
                    fig = new QueenFigure(figData.Data["X"], figData.Data["Y"]);
                    break;
                case "Rook":
                    fig = new RookFigure(figData.Data["X"], figData.Data["Y"]);
                    break;
            }

            return fig;
        }

        public static List<FiguresData> InitFiguresData()
        {
            var figuresData = new List<FiguresData>();

            figuresData.Add(new FiguresData
            {
                Name = "Rook",
                Data = new Dictionary<string, int>
                {
                    { "X", 1 },
                    { "Y", 1 },
                    { "Radius", 100 }
                }
            });

            figuresData.Add(new FiguresData
            {
                Name = "Line",
                Data = new Dictionary<string, int>
                {
                    { "X1", 0 },
                    { "Y1", 0 }
                }
            });

            figuresData.Add(new FiguresData
            {
                Name = "Rectangle",
                Data = new Dictionary<string, int>
                {
                    { "X", 0 },
                    { "Y", 0 }
                }
            });

            return figuresData;
        }
    }
}
