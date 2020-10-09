using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_4
{
    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base() {}
        public InsufficientFundsException(string s) : base(s) {}
        public InsufficientFundsException(string s, Exception ex) : base (s, ex) {}

    }
}
