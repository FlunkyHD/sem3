using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion1
{
    class Vektor
    {
        private double x;
        private double y;
        private double z;

        public Vektor(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public Vektor Addition(Vektor vek2)
        {
            return new Vektor(this.x + vek2.x, this.y + vek2.y, this.z + vek2.z);
        }

        public Vektor Subtraktion(Vektor vek1, Vektor vek2)
        {
            return new Vektor(vek1.x - vek2.x, vek1.y - vek2.y, vek1.z - vek2.z);
        }

        public double Skalar(Vektor vek1, Vektor vek2)
        {
            return vek1.x * vek2.x + vek1.y * vek2.y + vek1.z * vek2.z;
        }

        public Vektor Krydsprodukt(Vektor vek1, Vektor vek2)
        {
            return new Vektor(vek1.y * vek2.z - vek1.z * vek2.y, (vek1.x * vek2.z - vek1.z * vek2.x) * (-1), vek1.x * vek2.y - vek1.y * vek2.x);
        }

        public void PrintValues()
        {
            Console.WriteLine("X, Y og Z er: " + x + y + z);
        }


    }
}
