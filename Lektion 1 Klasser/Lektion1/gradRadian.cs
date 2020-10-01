using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion1
{
    class GradRadian
    {
        public double Grad (double radian)
        {
            if (radian > 0 && radian < 2 * Math.PI)
            {
                return radian * (180 / Math.PI);
            } else
            {
                throw new ArgumentException();
            }
            
        }

        public double Radian(double grad)
        {
            if (grad > 0 && grad < 360)
            {
                return grad * (Math.PI / 180);
            }
            else
            {
                throw new ArgumentException();
            }

        }
    }
}
