using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Config.Tests
{
    class Dummy
    {
        static TestCaseData Case(int i)
            => new TestCaseData(TimeSpan.FromSeconds(2)).SetName($"Case {i}");

        public static IEnumerable<TestCaseData> Cases()
            => Enumerable.Range(1, 5).Select(Case);

        [TestCaseSource(nameof(Cases)), Parallelizable]
        public void ItShouldSleep(TimeSpan t)
            => Thread.Sleep(t);
    }
}
