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

            var result = SubstringCalculator.SubstringCalculator.RunTest(dummy, "Tests are useful", 1);

            Assert.AreEqual(result.ElapsedTime, 300, 5, "The Timer is malfunctioning!");
        }

        [TestMethod]
        public void AllSubstringCalculationsAreNotCaseSensitive()
        {
            var testString = "iI";

            var res1 = SubstringCalculator.SubstringCalculator.UsingDistinctUniqueSubstrings(testString);
            var res2 = SubstringCalculator.SubstringCalculator.BruteForceUniqueSubstrings(testString);
            var res3 = SubstringCalculator.SubstringCalculator.GetAllSubstrings(testString);
            var res4 = SubstringCalculator.SubstringCalculator.charArrayUniqueSubstrings(testString);

            Assert.AreEqual(res1.First(), testString, "UsingDistinctUniqueSubstrings is case insensitive.");
            Assert.AreEqual(res2.First(), testString, "BruteForceUniqueSubstrings is case insensitive.");
            Assert.AreEqual(res3.First(), testString, "BruteForceUniqueSubstrings is case insensitive.");
            Assert.AreEqual(res4.First(), testString, "charArrayUniqueSubstrings is case insensitive.");
        }

        [TestMethod]
        public void SubstringResultEqualsWorks()
        {
            var t1 = new SubstringCalculator.SubstringResult();
            var t2 = new SubstringCalculator.SubstringResult();

            var testList = new List<String>() { "Hi", "There", "Sam" };
            var testList2 = new List<String>() { "Hi", "There", "Sam" };

            t1.LongestSubstrings = testList;
            t2.LongestSubstrings = testList2;

            Assert.IsTrue(t1.Equals(t2), "The .equals method on substring result is not working!");
            Assert.AreEqual(t1, t2, "The regular overridden equals override doesn't work!");

        }

        [TestMethod]
        public void AllTestsGiveSameResults()
        {
            var testString = "Hereisabigolteststring";

            var res1 = SubstringCalculator.SubstringCalculator.RunTest(SubstringCalculator.SubstringCalculator.UsingDistinctUniqueSubstrings, testString, 1);
            var res2 = SubstringCalculator.SubstringCalculator.RunTest(SubstringCalculator.SubstringCalculator.BruteForceUniqueSubstrings, testString, 1);
            var res3 = SubstringCalculator.SubstringCalculator.RunTest(SubstringCalculator.SubstringCalculator.charArrayUniqueSubstrings, testString, 1);

            Assert.AreEqual(res1, res2, res1.MethodName + " and " + res2.MethodName + " are not equal");
            Assert.AreEqual(res2, res3, res2.MethodName + " and " + res3.MethodName + " are not equal");
        }

        [TestMethod]
        public void MethodsCanDetectMultipleLongestSubstrings() {
            var testString = "abba";

            var res1 = SubstringCalculator.SubstringCalculator.RunTest(SubstringCalculator.SubstringCalculator.UsingDistinctUniqueSubstrings, testString, 1);
            var res2 = SubstringCalculator.SubstringCalculator.RunTest(SubstringCalculator.SubstringCalculator.BruteForceUniqueSubstrings, testString, 1);
            var res3 = SubstringCalculator.SubstringCalculator.RunTest(SubstringCalculator.SubstringCalculator.charArrayUniqueSubstrings, testString, 1);

            Assert.IsTrue(res1.LongestSubstrings.Count() == 2, res1.MethodName + " returned an incorrect number of results: " + string.Join(", ", res1.LongestSubstrings));
            Assert.IsTrue(res2.LongestSubstrings.Count() == 2, res2.MethodName + " returned an incorrect number of results: " + string.Join(", ", res2.LongestSubstrings));
            Assert.IsTrue(res3.LongestSubstrings.Count() == 2, res3.MethodName + " returned an incorrect number of results.: " + string.Join(", ", res3.LongestSubstrings));

            Assert.AreEqual(res1, res2, res1.MethodName + " and " + res2.MethodName + " are not equal");
            Assert.AreEqual(res2, res3, res2.MethodName + " and " + res3.MethodName + " are not equal");
        }

    }

}
