using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lektion_4
{
    public class GearBox
    {
        private int _gear {get; set;}

        public GearBox()
        {
            _gear = 1;
        }

        public void ChangeGear(int gear)
        {
            if (!(gear >= -1 && gear <= 5))
                throw new ArgumentException();
            else if (gear == -1 && _gear != 1)
                throw new IllegalGearChangeException("Change to reverse from a gear that is not one.");
            else if (gear >= _gear+2 && gear > _gear)
                throw new IllegalGearChangeException("No more than one shift upwards.");

            _gear = gear;
        }
    }

    public class IllegalGearChangeException: Exception
    {
        public IllegalGearChangeException() : base() {}
        public IllegalGearChangeException(string err) : base(err) { }
    }
}
