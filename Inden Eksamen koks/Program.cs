using System;

namespace Inden_Eksamen_koks
{
    class Program
    {
        static void Main(string[] args)
        {

            //Public og private = Access modifier

            City Herning = new City("Herning", 65000, 7400);

            Console.WriteLine(Herning);

            Person Morten = new Person("Morten", 21, Herning);
            Morten.SayHello();
            Morten.SayGoodbye();

            Morten.ChildBorn += Herning.BabyBornInCity;
            Morten.PersonDied += Herning.PersonDiedInCity;

            Morten.PopChildOut("Apollo");

            Console.WriteLine(Herning.Citizens[0]);

            Console.WriteLine(Herning);

            Morten.PersonDies();

            Console.WriteLine(Herning);

            Generic<string> diller = new Generic<string>();

            Console.WriteLine(diller.ReturnLargest("Diller", "Coomer123"));

        }
    }
}
