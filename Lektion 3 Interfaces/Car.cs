using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_3
{
    class Car : IComparer<Car> //IComparable<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        //public int CompareTo(Car other)
        //{
        //    if (this.Price < other.Price)
        //    {
        //        return 1;
        //    }
        //    else if (this.Price > other.Price)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}

        public int Compare(Car a, Car b)
        {
            int comValue1 = a.Model.CompareTo(b.Model);


            if (comValue1 > 0)
            {
                return 1;
            }
            else if (comValue1 < 0)
            {
                return -1;
            }

            if (a.Price < b.Price)
            {
                return 1;
            }
            else if (a.Price > b.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }


        //public int Compare(Car a, Car b)
        //{
        //    int comValue1 = a.Make.CompareTo(b.Make);


        //    if (comValue1 > 0)
        //    {
        //        return 1;
        //    } 
        //    else if (comValue1 < 0)
        //    {
        //        return -1;
        //    }

        //    int comValue2 = a.Model.CompareTo(b.Model);

        //    if (comValue2 > 0)
        //    {
        //        return 1;
        //    }
        //    else if (comValue2 < 0)
        //    {
        //        return -1;
        //    }

        //    if (a.Price > b.Price)
        //    {
        //        return 1;
        //    }
        //    else if (a.Price < b.Price)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}

    }
}
