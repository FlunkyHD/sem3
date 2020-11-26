using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen.Core
{
    public class InsufficientCreditsException : Exception
    {
        public InsufficientCreditsException() : base() { }
        //public InsufficientCreditsException(User user, Product product) : base() { }
        public InsufficientCreditsException(string s) : base(s) { }
        public InsufficientCreditsException(string s, Exception ex) : base(s, ex) { }
    }
}
