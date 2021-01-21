using System;
using System.Collections.Generic;
using System.Text;

namespace Inden_Eksamen_koks
{
    class Town : Village
    {
        public Town(string name, int population, int postNumber) : base(name, population, postNumber)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
