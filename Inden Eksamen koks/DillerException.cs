using System;
using System.Collections.Generic;
using System.Text;

namespace Inden_Eksamen_koks
{
    class DillerException : Exception
    {
        public DillerException() : base() {}
        public DillerException(string s) : base(s) {}
        public DillerException(string s, Exception ex) : base(s, ex) {}

    }
}
