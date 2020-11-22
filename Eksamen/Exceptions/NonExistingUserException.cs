using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen
{
    class NonExistingUserException : Exception
    {
        public NonExistingUserException() : base() { }
        public NonExistingUserException(string s) : base(s) { }
        public NonExistingUserException(string s, Exception ex) : base(s, ex) { }
    }
}
