using System;
using System.Collections.Generic;
using System.Text;

namespace Inden_Eksamen_koks
{
    public class City
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

        public int Population { get; set; }

        public int PostNumber { get; set; }


        public override string ToString()
        {
            return $"{Name} {PostNumber} ({Population}) Base: " + base.ToString();
        }

        public virtual double PopulationInOneYear()
        {
            return Population * 1.05;
        }

        public virtual void BabyBornInCity()
        {
            Population++;
        }

        public event BabyBorn OnBorn;

    }
}
