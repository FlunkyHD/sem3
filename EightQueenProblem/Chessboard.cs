using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace EightQueenProblem
{
    class Chessboard
    {
        public bool[,] chessBoard = new bool[8, 8];
        public bool[,] QueenBoard = new bool[8, 8];
        public int queensPlaced = 0;


        public void ClearBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chessBoard[i, j] = true;

                }
            }
        }

        public void ClearQueenBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    QueenBoard[i, j] = true;

                }
            }
        }

        public int PlaceQueen()
        {
            int random = RandomCollum();
            Console.WriteLine(random);
            for (int i = queensPlaced; i < 8; i++)
            {
                for (int j = 0; j < 100; j++)
                {

                    if (chessBoard[i, random])
                    {
                        chessBoard[i, random] = false;
                        QueenBoard[i, random] = false;
                        queensPlaced++;
                        FillRow(i);
                        FillCollum(random);
                        FillLeftDiagonal(i, random);
                        FillRightDiagonal(i, random);
                        return 1;
                    }
                    random = RandomCollum();

                }

            }

            return 0;

        }

        private void FillRow(int row)
        {
            for (int i = 0; i < 8; i++)
            {
                chessBoard[row, i] = false;
            }

        }

        private void FillCollum(int collum)
        {
            for (int i = 0; i < 8; i++)
            {
                chessBoard[i, collum] = false;
            }

        }

        private void FillLeftDiagonal(int row, int collum)
        {
            int _collum = collum;
            for (int i = row; i < 8; i++)
            {
                if (_collum < 8)
                {
                    chessBoard[i, _collum++] = false;
                }
            }

            _collum = collum;
            for (int i = row; i >= 0; i--)
            {
                if (_collum >= 0)
                {
                    chessBoard[i, _collum--] = false;
                }
            }

        }

        private void FillRightDiagonal(int row, int collum)
        {
            int _collum = collum;

            for (int i = row; i >= 0; i--)
            {
                if (_collum < 8)
                {
                    chessBoard[i, _collum++] = false;
                }
            }

            _collum = collum;
            for (int i = row; i < 8; i++)
            {
                if (_collum >= 0)
                {
                    chessBoard[i, _collum--] = false;
                }

            }

        }

        public void ClearRow()
        {

        }

        private int RandomCollum()
        {
            Random rd = new Random();
            return rd.Next(8);
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(chessBoard[i, j]);
                }

                Console.WriteLine("");
            }


        }

        public void PrintQueens()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(QueenBoard[i, j]);
                }

                Console.WriteLine("");
            }
        }
    }
}
