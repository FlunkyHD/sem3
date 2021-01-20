using System;
using System.Collections.Generic;
using System.Text;

namespace Inden_Eksamen_koks
{
    public class City : ICity
    {
        //Constructor
        public City(string name, int population, int postNumber)
        {
            Name = name;
            Population = population;
            PostNumber = postNumber;
            
        }

        //Backing field
        private string name;
        //Property
        public string Name
        {
            get { return name;}
            set { if (value != null) name = value;}
        }

        public List<Person> Citizens = new List<Person>();

        public event EventHandler diller;

        public int Population { get; set; }

        public int PostNumber { get; set; }


        public override string ToString()
        {
            return $"{Name} {PostNumber} ({Population}) Base: " + base.ToString();
        }

        public void DisplayCitizens()
        {
            foreach (Person citizen in Citizens)
            {
                Console.WriteLine(citizen);
            }
        }

        public virtual double PopulationInOneYear()
        {
            return Population * 1.05;
        }

        public virtual void BabyBornInCity(Person child)
        {
            Citizens.Add(child);
            Population++;
        }

        public virtual void PersonDiedInCity(Object? objec, DiedEventArgs e)
        {
            Console.WriteLine($"From: {objec}, died at {e.TimeOfDeath}");
            Population--;
        }

    }
}
