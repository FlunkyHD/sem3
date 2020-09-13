using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion1
{
    class Kvadratrod
    {

        public void Rod()
        {
            Console.WriteLine("Indtast det tal du gerne vil finde kvadratroden af: ");
            string input = Console.ReadLine();
            double tal = double.Parse(input);
            Console.WriteLine("Kvadratroden af: " + tal + " er: " + Math.Sqrt(tal));

        }

    }
}
