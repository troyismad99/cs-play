using System;
using System.Linq;
/*
 * Ones and Zeroes
 * 
 * You are given an array of binary strings strs and two integers m and n.
 * 
 * Return the size of the largest subset of strs such that there are 
 * at most m 0's and n 1's in the subset.
 * 
 * A set x is a subset of a set y if all elements of x are also elements of y.
 * 
 * Example 1:
 * Input: strs = ["10","0001","111001","1","0"], m = 5, n = 3
 * Output: 4
 * Explanation: The largest subset with at most 5 0's and 3 1's is {"10", "0001", "1", "0"}, so the answer is 4.
 * Other valid but smaller subsets include {"0001", "1"} and {"10", "1", "0"}.
 * {"111001"} is an invalid subset because it contains 4 1's, greater than the maximum of 3.
 * 
 * Example 2:
 * Input: strs = ["10","0","1"], m = 1, n = 1
 * Output: 2
 * Explanation: The largest subset is {"0", "1"}, so the answer is 2.
 * 
 * Constraints:
 *     1 <= strs.length <= 600
 *     1 <= strs[i].length <= 100
 *     strs[i] consists only of digits '0' and '1'.
 *     1 <= m, n <= 100
 */
/*
 * Runtime: 196 ms            Your runtime beats 63.16 % of csharp submissions.
 * Memory Usage: 24.8 MB Your memory usage beats 94.74 % of csharp submissions.
 */
namespace _0474_OnesandZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(FindMaxForm(new string[] { "10", "0001", "111001", "1", "0" }, 5, 3));
            Console.WriteLine(FindMaxForm(new string[] { "10", "0", "1" }, 1, 1));

        }

        static int FindMaxForm(string[] strs, int m, int n)
        {
            // count the zero and ones in each element of strs into an array of tuples
            var theCount = new (int zeroCount, int oneCount)[strs.Length];

            /* Everytime I declare a count variable I have a flashback to 
             * Seasame Street and the vampire Count von Count.
             * https://en.wikipedia.org/wiki/Count_von_Count
             * "Four, four apples. Ah! Ah! Ah!" 
             * 
             *  "strs.Length tuples! Ah! Ah! Ah!"
             */

            // back to counting ones and zeros
            for (int i = 0; i < strs.Length; i++)
            {
                theCount[i] = (strs[i].Count(m => m == '0')
                              ,strs[i].Count(n => n == '1')
                              );
            }

            var dp = new int[m + 1, n + 1];

            foreach (var (zeroCount, oneCount) in theCount)
            {
                // m is max zero count
                for (int zeros = m; zeros >= 0; zeros--)
                {
                    // n is max one count
                    for (int ones = n; ones >= 0; ones--)
                    {
                        // check if this one is a fit candidate
                        if (zeros - zeroCount >= 0 && ones - oneCount >= 0)
                        {
                            // take it or leave it
                            dp[zeros, ones] = Math.Max(dp[zeros, ones], dp[zeros - zeroCount, ones - oneCount] + 1);
                        }
                    }
                }
            }
            return dp[m, n];
        }
    }
}
