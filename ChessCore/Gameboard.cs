using System;
using System.Collections.Generic;
using System.Text;

namespace ChessCore
{
    public class Gameboard
    {
        private Figure[,] board;

        public Gameboard()
        {
            board = new Figure[8, 8];
        }

        public bool AddFigure(int x, int y, Figure figure)
        {
            if (board[x, y] == null)
            {
                board[x, y] = figure;
                return true;
            }
            return false;
        }

        public bool DelFigure(int x, int y)
        {
            if (board[x, y] != null)
            {
                board[x, y] = null;
                return true;
            }
            return false;
        }

        public bool Move(int x1, int y1, int x2, int y2)
        {
            if (board[x1, y1] != null && board[x2,y2] == null)
            {
                //crutch?
                board[x2, y2] = board[x1, y1];
                board[x2, y2].Move(x2, y2);
                board[x1, y1] = null;
                return true;
            }
            return false;
        }

        public List<int[]> GetPossibleMoves(int x, int y)
        {
            var results = new List<int[]>();
            
            if (board[x, y] == null) return results;
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[x, y].IsRightMove(i, j) && board[i, j] == null)
                    {
                        results.Add(new int[] { i, j });
                    }
                }
            }
            return results;
        }

        public bool HasFigure(int x, int y)
        {
            return board[x, y] != null;
        }

        public Figure GetFigure(int x, int y)
        {
            return HasFigure(x, y) ? board[x, y] : null;
        }
    }
}
