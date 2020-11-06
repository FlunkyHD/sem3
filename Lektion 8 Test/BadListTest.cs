using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Lektion_8_Test
{
    [TestFixture]
    class BadListTest
    {
        [TestCase]
        public void CounterNumbersTest()
        {
            BadList bl = new BadList();

            double length = bl.CountNumbers(25);

            Assert.AreEqual(1, length);
        }

    }
}
