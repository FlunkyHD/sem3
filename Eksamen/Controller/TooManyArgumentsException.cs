using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen.Controller
{
    public class TooManyArgumentsException : Exception
    {
        public TooManyArgumentsException() : base() { }
        public TooManyArgumentsException(string s) : base(s) { }
        public TooManyArgumentsException(string s, Exception ex) : base(s, ex) { }
    }
}
