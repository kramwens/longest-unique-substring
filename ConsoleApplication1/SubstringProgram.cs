using System;

namespace SubstringCalculator
{
    public class SubstringsProgram
    {
        static void Main(string[] args)
        {
            LaunchLongestUniqueSubstring();
        }

        static void LaunchLongestUniqueSubstring()
        {
            Console.Out.WriteLine("Enter a String to find out the longest, unique substring!");
            var rootString = Console.In.ReadLine();
            var numIterations = 1000;
            Console.WriteLine();

            var res1 = SubstringCalculator.RunTest(SubstringCalculator.UsingDistinctUniqueSubstrings, rootString, numIterations);
            var res2 = SubstringCalculator.RunTest(SubstringCalculator.BruteForceUniqueSubstrings, rootString, numIterations);
            var res3 = SubstringCalculator.RunTest(SubstringCalculator.charArrayUniqueSubstrings, rootString, numIterations);

            printResults(res1);
            printResults(res2);
            printResults(res3);

            Console.WriteLine("All Finished, Press Y to run again or any other key to Exit");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                LaunchLongestUniqueSubstring();
            }
        }

        private static void printResults(SubstringResult results)
        {
            Console.WriteLine("Running Method " +results.MethodName+ " took "+results.ElapsedTime+ " Miliseconds and produced the following results: ");
            foreach (var subString in results.LongestSubstrings)
            {
                Console.WriteLine(subString);
            }
        }

        

        

        

        
    }
}
