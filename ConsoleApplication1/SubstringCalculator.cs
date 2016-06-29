using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SubstringCalculator
{
    /// <summary>
    /// A results object when using the substring calculator test.
    /// </summary>
    public class SubstringResult
    {
        public IEnumerable<String> LongestSubstrings { get; set; }
        public long ElapsedTime { get; set; }
        public string MethodName { get; set; }

        public override bool Equals(object obj)
        {
            var compareObj = obj as SubstringResult;
            if (obj != null)
            {
                return LongestSubstrings.SequenceEqual(compareObj.LongestSubstrings);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return LongestSubstrings.GetHashCode();
        }
    }

    public class SubstringCalculator
    {
        public static SubstringResult RunTest(Func<string, IEnumerable<string>> method, string rootString, int iterations)
        {
            var result = new SubstringResult();
            Stopwatch timer = new Stopwatch();

            timer.Start();
            for (int i = 0; i < iterations; i++)
            {
                result.LongestSubstrings = method(rootString);
            }
            timer.Stop();

            result.MethodName = method.Method.Name;
            result.ElapsedTime = timer.ElapsedMilliseconds;

            return result;
        }

        public static IEnumerable<string> BruteForceUniqueSubstrings(string rootString)
        {
            var subStringList = new List<string>();
            int length = rootString.Length;
            int index = 0;
            int i = length;
            string tempString;

            //Get a complete list of substrings
            while (index < length)
            {
                while (i > 0)
                {
                    bool toAdd = true;
                    tempString = rootString.Substring(index, i);
                    //Check each character in tempstring for a repeat value in the string before adding.
                    for (int j = 0; j < tempString.Length; j++)
                    {
                        for (int k = j + 1; k < tempString.Length; k++)
                        {
                            if (tempString[j] == tempString[k])
                            {
                                toAdd = false;
                                break;
                            }
                        }
                    }

                    if (toAdd)
                        subStringList.Add(tempString);
                    i--;
                }
                index++;
                i = length - index;
            }

            var maxLength = subStringList.Max(n => n.Length);
            return subStringList.Where(n => n.Length == maxLength);
        }

        public static IEnumerable<string> UsingDistinctUniqueSubstrings(string rootString)
        {
            var subStringList = new List<string>();
            int length = rootString.Length;
            int index = 0;
            int i = length;
            int maxSubstringLength = 0;
            string subString;

            while (index < length)
            {
                while (i >= maxSubstringLength)
                {
                    subString = rootString.Substring(index, i);
                    if (subString.Distinct().Count() == subString.Length)
                    {
                        if (subString.Length >= maxSubstringLength)
                        {
                            if (subString.Length > maxSubstringLength)
                            {
                                subStringList.Clear();
                            }
                            maxSubstringLength = subString.Length;
                            subStringList.Add(subString);
                        }
                    }

                    i--;
                }
                index++;
                i = length - index;
            }

            return subStringList;
        }

        public static IEnumerable<string> charArrayUniqueSubstrings(string rootString)
        {
            HashSet<Char> set = new HashSet<char>();
            var longestSubstrings = new List<string>();

            int start = 0;
            int end = 0;
            int maxLength = 0;
            int length;

            while (end < rootString.Length)
            {
                if (!set.Contains(rootString[end]))
                {
                    set.Add(rootString[end]);
                }
                else
                {
                    while (rootString[start] != rootString[end])
                    {
                        set.Remove(rootString[start]);
                        start++;
                    }
                    start++;
                }

                length = end - start + 1;

                if (length > maxLength)
                {
                    longestSubstrings.Clear();
                }
                if (length >= maxLength)
                {
                    longestSubstrings.Add(rootString.Substring(start, length));
                    maxLength = length;
                }

                end++;
            }

            return longestSubstrings;
        }

        public static IEnumerable<string> GetAllSubstrings(string rootString)
        {
            var subStringList = new List<string>();
            int length = rootString.Length;
            int index = 0;
            int i = length;
            int count = 0;
            string tempString;

            while (index < length)
            {
                while (i > index)
                {
                    tempString = rootString.Substring(index, i);
                    if (tempString.Distinct().Count() == tempString.Length)
                    {
                        subStringList.Add(tempString);
                        count++;
                    }
                    i--;
                }
                index++;
                i = length - index;
            }
            return subStringList;
        }
    }
}
