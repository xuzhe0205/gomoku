using System;

namespace Gomoku
{
    public class GomokuGame
    {
        public int[,] chess;
        int winNum;
        int h;
        int w;
        public int Turns { get; private set; }                     //Just like int turns

        public int Winner { get; private set; }

        public bool CanMove()
        {
            return Turns < w * h || Winner != 0;
        }

        public int GetCurrentPlayerPiece()
        {
            return Turns % 2 + 1;
        }

        public void Init(int playingchess, int r, int c)
        {
            winNum = playingchess;
            chess = new int[r, c];
            h = chess.GetLength(0);                     //row
            w = chess.GetLength(1);                     //col
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    chess[i, j] = 0;
                }
            }
        }
        
        public void Update(int row, int col)
        {
            int piece = GetCurrentPlayerPiece();
            if (chess[row, col] != 0)
            {
                return;
            }
            Turns++;
            chess[row, col] = piece;
        }
        public int FindCount(int row, int col, int stepRow, int stepCol, int stopCounter)
        {
            var counter = 0;
            var piece = chess[row, col];

            while (counter <= stopCounter)
            {
                row += stepRow;
                col += stepCol;

                if (row < 0 || row >= h)
                    break;
                if (col < 0 || col >= w)
                    break;

                if (chess[row, col] != piece)
                    break;

                ++counter;
            }
            return counter;
        }

        public int CheckWin()
        {
            for (var r = 0; r < h; r++)
            {
                for (var c = 0; c < w; c++)
                {
                    if (CheckWin(r, c))
                    {
                        return chess[r, c];
                    }
                }
            }
            return 0;
        }

        private bool _CheckWin(int row, int col)
        {
            //Vertical
            var udCounter = FindCount(row, col, -1, 0, winNum - 1) + FindCount(row, col, 1, 0, winNum - 1) + 1;
            if (udCounter >= winNum)
            {
                return true;
            }
            //Horizontal
            var lrCounter = FindCount(row, col, 0, -1, winNum - 1) + FindCount(row, col, 0, 1, winNum - 1) + 1;
            if (lrCounter >= winNum)
            {
                return true;
            }
            //From upper left to lower right
            var ullrCounter = FindCount(row, col, -1, -1, winNum - 1) + FindCount(row, col, 1, 1, winNum - 1) + 1;
            if (ullrCounter >= winNum)
            {
                return true;
            }
            //From upper right to lower left
            var urllCounter = FindCount(row, col, 1, -1, winNum - 1) + FindCount(row, col, -1, 1, winNum - 1) + 1;
            if (urllCounter >= winNum)
            {
                return true;
            }
            return false;
        }

        public bool CheckWin(int row, int col)
        {
            if (_CheckWin(row, col))
            {
                Winner = chess[row, col];
            }
            return _CheckWin(row, col);
        }
    }
}