using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion2
{
    class PersonFilter
    {
        public virtual List<Person> Filter(List<Person> plist)
        {
            List<Person> result = new List<Person>();
            foreach (Person person in plist)
            {
                if (FilterPredicate(person))
                    result.Add(person);
            }
            return result;
        }
        public abstract bool FilterPredicate(Person person);
    }
}
