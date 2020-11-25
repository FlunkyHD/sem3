using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen.Core
{
    class NotActiveProductException : Exception
    {
        public NotActiveProductException() : base() { }
        public NotActiveProductException(string s) : base(s) { }
        public NotActiveProductException(string s, Exception ex) : base(s, ex) { }
    }
}
