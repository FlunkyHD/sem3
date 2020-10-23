using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Lektion_6_Generics
{
    class Dict<K, V>
    {
        
        List<Pair<K, V>> dictonary = new List<Pair<K, V>>();

        public Pair<K, V> Get(K Key)
        {

            foreach (Pair<K, V> pair in dictonary)
            {
                if (pair.element1.Equals(Key))
                {
                    return pair;
                }
            }

            throw new ArgumentNullException("No one with that key");
        }

        public void Put(K key, V value)
        {

            try
            {
                Pair<K, V> xd = Get(key);
                dictonary[dictonary.IndexOf(xd)] = new Pair<K, V>(key, value);

            }
            catch (Exception e)
            {
                dictonary.Add(new Pair<K, V>(key, value));
                Console.WriteLine(e);
                throw;
            }

        }


    }
}
