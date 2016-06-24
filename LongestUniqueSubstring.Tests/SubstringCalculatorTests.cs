using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace SubstringCalculatorTests
{
    [TestClass]
    public class SubstringCalculatorUnitTests
    {
        [TestMethod]
        public void TimerShouldBeAccurate()
        {
            Func<string, IEnumerable<string>> dummy = delegate (string s)
            {
                System.Threading.Thread.Sleep(300);
                return new List<String>();
            };

            var result = SubstringCalculator.SubstringCalculator.RunTest(dummy, "Tests are useful");

            Assert.AreEqual(result.ElapsedTime, 300, 5, "The Timer is malfunctioning!");
        }

        [TestMethod]
        public void AllSubstringCalculationsAreNotCaseSensitive()
        {
            var res1 = SubstringCalculator.SubstringCalculator.UsingDistinctUniqueSubstrings("iI");
            var res2 = SubstringCalculator.SubstringCalculator.BruteForceUniqueSubstrings("iI");
            var res3 = SubstringCalculator.SubstringCalculator.GetAllSubstrings("iI");

            Assert.AreEqual(res1.First(), "iI", "UsingDistinctUniqueSubstrings is case insensitive.");
            Assert.AreEqual(res2.First(), "iI", "BruteForceUniqueSubstrings is case insensitive.");
            Assert.AreEqual(res3.First(), "iI", "BruteForceUniqueSubstrings is case insensitive.");
        }
    }
}
