using System;
using System.Collections.Generic;
using System.Text;

namespace Inden_Eksamen_koks
{
    public class Generic<T>
    {
        public K ReturnLargest<K>(K T1, K T2) where K : IComparable<K>
        {
            if (T1.CompareTo(T2) > 0)
            {
                return T1;
            }
            else
            {
                return T2;
            }
        }

    }
}
