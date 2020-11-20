using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lektion_9_Collections_and_Linq
{
    class RandomNumbers : IEnumerable<int>
    {
        private int[] _sequence;
        private int _minValue;
        private int _maxValue;
        private Random rnd;

        public RandomNumbers(int seed, int min, int max, int count)
        {
            _sequence = new int[count];
            rnd = new Random(seed);
            _minValue = min;
            _maxValue = max;

            CreateRandomSequence();
        }

        public void CreateRandomSequence()
        {
            for (int i = 0; i < _sequence.Length; i++)
            {
                _sequence[i] = rnd.Next(_minValue, _maxValue);
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
