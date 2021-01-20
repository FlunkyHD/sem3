using System;
using System.Collections.Generic;
using System.Text;

namespace Inden_Eksamen_koks
{
    interface ICity
    {
        public string Name { get; set; }

        event EventHandler diller;

        public void DisplayCitizens();




    }
}
