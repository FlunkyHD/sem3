using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            Morten.ChildBBorn += Herning.test;
            Morten.HEJJ = Herning.test;
            Morten.PersonDied += Herning.PersonDiedInCity;

            Morten.PopChildOut("Apollo");

            Console.WriteLine(Herning.Citizens[0]);

            Console.WriteLine(Herning);

            Morten.PersonDies();

            Console.WriteLine(Herning);

            Generic<string> diller = new Generic<string>();

            Console.WriteLine(diller.ReturnLargest("Diller", "Coomer123"));

            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;
            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }

            int[] numbers = new[] {23, 123, 231, 231, 5314, 12, 23, 3, 5, 6, 3};
            IEnumerable<int> selectedNumbers = from number in numbers where number > 25 select number;

            foreach (int tal in selectedNumbers)
            {
                Console.WriteLine(tal);
            }

            foreach (int ting in numbers.Where(number => number > 25))
            {
                Console.WriteLine(ting);
            }

            //Husker ikke state
            IEnumerable<int> ienum = (IEnumerable<int>) numbers;
            foreach (int ting in ienum)
            {
                Console.WriteLine(ting);
            }

            List<int> haha = numbers.ToList();
            //Husker state, hvis man fx giver den videre til en anden metode, husker den hvor den er nået til
            IEnumerator<int> ienumerator = (IEnumerator<int>)haha.GetEnumerator();

            while (ienumerator.MoveNext())
            {
                Console.WriteLine(ienumerator.Current.ToString());
                if (ienumerator.Current == 5314)
                {
                    ContinueExample(ienumerator);
                }
            }

            Predicate<string> isUpper1 = IsUpperCase;
            Predicate<string> isUpper2 = s => s.Equals(s.ToUpper());

            bool result = isUpper1("hello world!!");

            Console.WriteLine(result);

            Town town = new Town("Dillerby", 55, 2902);
            Console.WriteLine(town.ToString());

        }

        public static void ContinueExample(IEnumerator<int> ienumator)
        {
            while (ienumator.MoveNext())
            {
                Console.WriteLine(ienumator.Current.ToString() + " ! ");
            }
        }

        static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

    }
}
