using System;
using System.Collections.Generic;

namespace Lektion_3
{
    class Program
    {
        static void Main(string[] args)
        {

            //Opgave 1
            //List<Car> cars = new List<Car>()
            //{
            //    new Car(){Make="Ferrari", Model = "Italia", Price = 1060000},
            //    new Car(){Make="VW", Model = "Passat", Price = 120000},
            //    new Car(){Make="Skoda", Model = "Fabia", Price = 50000},
            //    new Car(){Make="Skoda", Model = "Octavia", Price = 60000},
            //    new Car(){Make="VW", Model = "Golf", Price = 75000}
            //};

            //Console.WriteLine("BEFORE SORT:");

            //foreach (Car car in cars)
            //{
            //    Console.WriteLine($"Maker: {car.Make} Model: {car.Model} Price: {car.Price}");
            //}

            ////cars.Sort();
            //Car sortering = new Car();
            //cars.Sort(sortering.Compare);


            //Console.WriteLine("AFTER SORT:");


            //foreach (Car car in cars)
            //{
            //    Console.WriteLine($"Maker: {car.Make} Model: {car.Model} Price: {car.Price}");
            //}


            //Opgave 2

            //ITaxable hus = new House("Herning",true,7400,1000000);
            //ITaxable bus = new Bus(54, 12341, 100000);

            //List<ITaxable> TaxList = new List<ITaxable>();
            //TaxList.Add(hus);
            //TaxList.Add(bus);

            //foreach (ITaxable element in TaxList)
            //{
            //    Console.WriteLine(element.TaxValue());
            //}

            //Opgave 3
            Die d1 = new Die(),
                d2 = new Die(10),
                d3 = new Die(18);

            Card c1 = new Card(Card.CardSuite.spades, Card.CardValue.queen),
                c2 = new Card(Card.CardSuite.clubs, Card.CardValue.four),
                c3 = new Card(Card.CardSuite.diamonds, Card.CardValue.ace);

            IGameObject[] gameObjects = { d1, d2, d3, c1, c2, c3 };

            foreach (IGameObject gao in gameObjects)
            {
                Console.WriteLine("{0}: {1} {2}",
                    gao, gao.GameValue, gao.Medium);
            }


        }
    }
}
