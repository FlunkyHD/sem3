using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lektion_7_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Class47 xd = new Class47();
            Class47.StringJoin SJ = xd.ConcatString;
            Console.WriteLine(SJ("Hello ", "delegates"));

            Console.WriteLine(xd.JoinThree("a", "b", "c", (l, r) => l + r));
            Console.WriteLine(xd.JoinThree("a", "b", "c", (l, r) => l + "." + r));
            Console.WriteLine(xd.JoinThree("a", "b", "c", (l, r) => l));

            Console.WriteLine(xd.JoinAllStrings(new List<string> { "a", "b", "c", "d" }, (l, r) => l + "." + r));
            Console.WriteLine(xd.JoinAllStrings(new List<string> { "a", "b", "c", "d" }, (l, r) => l + r));
            Console.WriteLine(xd.JoinAllStrings(new List<string> {"a", "b", "c", "d"}, (l, r) => r));

            Console.WriteLine(xd.JoinAll(new List<int> { 1, 2, 3, 4 }, (a, b) => a + b)); // 10
            Console.WriteLine(xd.JoinAll(new List<int> { 1, 2, 3, 4 }, (a, b) => a * b)); // 24
            Console.WriteLine(xd.JoinAll(new List<string> { "a", "b", "c", "d" }, (l, r) => l + "." + r)); // a.b.c.d

            Console.WriteLine(xd.Twice(x=>x * 2, 1));


        }
    }
}
