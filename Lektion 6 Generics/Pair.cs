using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_6_Generics
{
    public class Pair<T1, T2>
    {
        public T1 element1 { get;}
        public T2 element2 { get;}

        public Pair(T1 xd, T2 xdx)
        {
            element1 = xd;
            element2 = xdx;
        }

        public Pair<T2, T1> Swap()
        {
            return new Pair<T2, T1>(element2, element1);
        }

        public Pair<C, T2> setFst<C>(C Value)
        {
            return new Pair<C, T2>(Value, element2);
        }

        public Pair<T1, C> setSnd<C>(C Value)
        {
            return new Pair<T1, C>(element1, Value);
        }

    }
}
