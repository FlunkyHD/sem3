using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion1
{
    class PersonPrinter
    {
        public void PrintPerson(Person p)
        {
            Console.WriteLine($"{p.Fornavn} {p.Efternavn} {p.Alder}");
        }

        public void PrintTree(Person p)
        {
            if (p == null)
            {
                return;
            }
            PrintPerson(p);
            PrintTree(p.Mor);
            PrintTree(p.Far);

        }
    }
}
