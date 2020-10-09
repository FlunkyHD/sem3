using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Lektion_4
{
    class DigitalDisplay
    {
        public int[] Digit = new int[4] {0,0,0,0};
        public DigitalDisplay()
        {
            
        }

        public int GetDigit(int i)
        {
            if (!(i >= 0 && i < 10))
                throw new IllegalDigitException("The number has to be in the range 0-9.");
            return Digit[i];
        }

        public void SetDigit(int i, int v)
        {
            if (!(i >= 0 && i < Digit.Length))
                throw new NoSuchDigitException("Out of bound.");

            Digit[i] = v;
        }
    }

    public class NoSuchDigitException: Exception
    {
        public NoSuchDigitException(string err) : base(err) { }
    }

    public class IllegalDigitException : Exception
    {
        public IllegalDigitException(string err) : base(err) { }
    }
}
