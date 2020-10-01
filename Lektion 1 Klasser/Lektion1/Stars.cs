using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion1
{
    class Stars
    {

        public void PrintStars(int starLines)
        {
            for (int i = 1; i <= starLines; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("\n");
            }
        }

        public void ReversePrintStars(int starLines)
        {
            for (int i = starLines; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("\n");
            }
        }


    }
}
