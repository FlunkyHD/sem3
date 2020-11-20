using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lektion_9_Collections_and_Linq
{
    class Sequence : IEnumerable<int>
    {
        private int[] _sequence;
        private int _count;
        private int _skip;

        public Sequence(int start, int count, int skip)
        {
            _sequence = new int[count];
            _sequence[0] = start;
            _count = count;
            _skip = skip;

            CreateSequence();
        }

        public void CreateSequence()
        {
            for (int i = 1; i < _count; i++)
            {
                _sequence[i] = _sequence[i - 1] + _skip;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new MySequenceEnumerator(_sequence);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
