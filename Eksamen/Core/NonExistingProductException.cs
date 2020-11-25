using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen.Core
{
    public class NonExistingProductException : Exception
    {
        public NonExistingProductException() : base() { }
        public NonExistingProductException(string s) : base(s) { }
        public NonExistingProductException(string s, Exception ex) : base(s, ex) { }
    }
}
