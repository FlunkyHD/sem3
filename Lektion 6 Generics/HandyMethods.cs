using System;
using System.Collections.Generic;

namespace Lektion_6_Generics
{
    class HandyMethods
    {
        public static T Max<T>(List<T> epic) where T : IComparable<T>
        {
            T Max = epic[0];
            for (int i = 1; i < epic.Count; i++)
            {
                Max = epic[i].CompareTo(Max) > 0 ? epic[i] : Max;
            }

            return Max;
        }

        public static T Min<T>(List<T> epic) where T : IComparable<T>
        {
            T Min = epic[0];
            for (int i = 1; i < epic.Count; i++)
            {
                Min = epic[i].CompareTo(Min) < 0 ? epic[i] : Min;
            }

            return Min;
        }

        public static void Copy<T>(T[] array1, T[] array2)
        {
            try
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    array2[i] = array1[i];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        public static void Shuffle<T>(T[] array)
        {
            int max = array.Length;
            Random rnd = new Random();
            T temp = default;

            for (int i = 0; i < array.Length; i++)
            {
                int j = rnd.Next(max);
                int k = rnd.Next(max);

                temp = array[j];
                array[j] = array[k];
                array[k] = temp;

            }

        }

    }
}
