using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen
{
    public class InsufficientCreditsException : Exception
    {
        public InsufficientCreditsException() : base() { }
        public InsufficientCreditsException(string s) : base(s) { }
        public InsufficientCreditsException(string s, Exception ex) : base(s, ex) { }
    }
}
