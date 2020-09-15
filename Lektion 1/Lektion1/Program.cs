using System;

namespace Lektion1
{
    class Program
    {
        static void Main(string[] args)
        {
            //BASICS

            //opgave 2
            //GradRadian hej = new GradRadian();
            //Console.WriteLine("Hello World!" + hej.Radian(180));

            //Opgave 3 + 4
            //Stars s = new Stars();
            //s.PrintStars(10);
            //s.ReversePrintStars(9);

            //Opgave 5
            //Kvadratrod k = new Kvadratrod();
            //k.Rod();

            //Opgave 6
            //GroupMembers g = new GroupMembers();
            //g.Control();
            //g.SmartControl();

            //Opgave 7
            //Lottery l = new Lottery();
            //l.LoteryTicket();


            //KLASSER
            //Opgave 1 + 2 + 3

            Person p = new Person(21, "Morten", "Jørgensen",
                new Person(50, "Peter", "Jørgensen",
                    new Person(75, "Aage", "Jørgensen"), 
                    new Person(80, "Inger", "Jørgensen")
                    ), 
                new Person(53, "Helle", "Jørgensen",
                    new Person(76, "Jørgen", "Jensen"), 
                    new Person(76, "Helen", "Jensen")
                    )
                );
            PersonPrinter pp = new PersonPrinter();

            pp.PrintTree(p);

        }
    }
}
