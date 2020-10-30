using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;

namespace Lektion_7_Delegates
{
    public class Class47
    {
        public delegate string StringJoin(string param1, string param2);
        public delegate T Join<T>(T param1, T param2);

        public string ConcatString(string l, string r) { return l + r; }

        public string JoinThree(string s1, string s2, string s3, StringJoin joiner)
        {
            return joiner(joiner(s1, s2), s3);
        }

        public string JoinAllStrings(List<string> stringList, StringJoin joiner)
        {
            for (int i = 1; i < stringList.Count; i++)
            {
                stringList[0] = joiner(stringList[0], stringList[i]);
            }

            return stringList[0];
        }

        public T JoinAll<T>(List<T> listT, Join<T> funkyTown)
        {
            for (int i = 1; i < listT.Count; i++)
            {
                listT[0] = funkyTown(listT[0], listT[i]);
            }

            return listT[0];
        }

        public bool Exists<T>(Predicate<T> f, T[] a)
        {
            foreach (T ting in a)
            {
                if (f(ting))
                {
                    return true;
                }
            }

            return false;
        }

        public T Twice<T>(Func<T, T> f, T v)
        {
            return f(v);
        }


    }
}
