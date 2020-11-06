using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_8_Test
{
    public class Circle
    {
        public Tuple<double,double> Center { get; set; }
        public double Radius { get; set; }

        public Circle(Tuple<double, double> center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool IsInsideCircle(Tuple<double, double> point)
        {
            double distance = Math.Sqrt(Math.Pow(point.Item1 - Center.Item1, 2) + Math.Pow(point.Item2 - Center.Item2, 2));

            if (distance < Radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CircleOverlapping(Tuple<double, double> otherCircleCenter, double otherCircleRadius)
        {
            double distance = Math.Sqrt(Math.Pow(otherCircleCenter.Item1 - Center.Item1, 2) + Math.Pow(otherCircleCenter.Item2 - Center.Item2, 2));
            double combinedRadius = otherCircleRadius + Radius;
            if (distance < combinedRadius)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
