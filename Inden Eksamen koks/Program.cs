using System;

namespace Inden_Eksamen_koks
{
    class Program
    {
        static void Main(string[] args)
        {
            City Herning = new City("Herning", 65000, 7400);

            Console.WriteLine(Herning);

            Person Morten = new Person("Morten", 21, Herning);
            Morten.SayHello();
            Morten.SayGoodbye();

            Herning.OnBorn += Herning.BabyBornInCity();
        }
    }
}
