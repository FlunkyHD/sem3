using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Lektion2
{
    abstract class ParkingMeter
    {
        private double _money = 0;
        public double Rate { get; set; }

        public virtual void InsertCoins(int time)
        {
            _money += time * Rate;
        }

        public void PrintsNumberOfCoins()
        {
            Console.WriteLine(_money);
        }




    }
}
