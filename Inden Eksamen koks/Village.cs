using System;
using System.Collections.Generic;
using System.Text;

namespace Inden_Eksamen_koks
{
    public class Village : City
    {
        public Village(string name, int population, int postNumber) : base(name, population, postNumber)
        {
        }

        //Polymorfi, da den samme metode gør forskellige ting
        public override double PopulationInOneYear()
        {
            return base.PopulationInOneYear() / 2;
        }
    }
}
