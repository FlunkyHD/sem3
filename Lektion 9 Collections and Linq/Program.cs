using System;

namespace Lektion_9_Collections_and_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opgave 1
            //Sequence pog = new Sequence(1,100,2);
            //foreach (var item in pog)
            //{
            //    Console.WriteLine(item);
            //}


            //Opgave 2
            RandomNumbers rn =new RandomNumbers(2367, 5, 100, 20);
            foreach (var item in rn)
            {
                Console.WriteLine(item);
            }


        }
    }
}
