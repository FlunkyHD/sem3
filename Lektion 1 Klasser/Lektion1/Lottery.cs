using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion1
{
    class Lottery
    {

        public void LoteryTicket()
        {
            Random rnd = new Random();

            int[] Ticket = new int[7];

            for (int i = 0; i < 7; i++)
            {
                Ticket[i] = rnd.Next(1, 100);
            }

            foreach (int tal in Ticket)
            {
                Console.Write(tal.ToString() + " ");
            }
        }

    }
}
