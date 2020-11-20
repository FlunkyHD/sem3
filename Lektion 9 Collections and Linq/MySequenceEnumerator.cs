using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lektion_9_Collections_and_Linq
{
    class MySequenceEnumerator : IEnumerator<int>
    {
        private int[] _sequence;
        private int _position = -1;

        public MySequenceEnumerator(int[] array)
        {
            _sequence = array;
        }

        object IEnumerator.Current => Current;
        public int Current
        {
            get
            {
                try
                {
                    return _sequence[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            return (++_position < _sequence.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
            _sequence = null;
        }
    }
}
