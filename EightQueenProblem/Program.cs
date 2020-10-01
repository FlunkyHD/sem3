using System;

namespace EightQueenProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard gamer = new Chessboard();
            int atempts = 1;

            gamer.ClearBoard();
            for (int i = 0; i < 9; i++)
            {
                if (gamer.PlaceQueen() == 0)
                {
                    Console.WriteLine("CLEARING BOARD!!!");
                    i = 0;
                    gamer.ClearBoard();
                    gamer.ClearQueenBoard();
                    gamer.queensPlaced = 0;
                    atempts++;
                }
                else if (gamer.queensPlaced == 8)
                {
                    Console.WriteLine("DU ER DONE, det tog: " + atempts + " forsøg");
                    gamer.PrintQueens();
                    break;
                }
                else
                {
                    Console.WriteLine(gamer.queensPlaced);
                    gamer.PrintBoard();
                }
            }

        }
    }
}
