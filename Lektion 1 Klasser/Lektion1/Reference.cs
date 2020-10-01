using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion1
{
    class Reference
    {
        public string[] str1 = new string[2]{"Element 1", "Element 2"};
        public string[] str2 = new string[2]{"Element 1", "Element 2"};

        public void TestReference()
        {
            if (str1 == str2)
            {
                Console.WriteLine("DE ER DET SAMME!");
            }
            else
            {
                Console.WriteLine("DE ER IKKE DET SAMME!");
            }

        }

    }
}
