using System;
using System.Collections.Generic;
/*
* 3Sum With Multiplicity
* 
* Given an integer array arr, and an integer target, 
* return the number of tuples i, j, k such that 
* i < j < k and arr[i] + arr[j] + arr[k] == target.
* 
* As the answer can be very large, return it modulo 10^9 + 7.
* 
* Example 1:
* Input: arr = [1,1,2,2,3,3,4,4,5,5], target = 8
* Output: 20
* Explanation: 
* Enumerating by the values (arr[i], arr[j], arr[k]):
* (1, 2, 5) occurs 8 times;
* (1, 3, 4) occurs 8 times;
* (2, 2, 4) occurs 2 times;
* (2, 3, 3) occurs 2 times.
* 
* Example 2:
* Input: arr = [1,1,2,2,2,2], target = 5
* Output: 12
* Explanation: 
* arr[i] = 1, arr[j] = arr[k] = 2 occurs 12 times:
* We choose one 1 from [1,1] in 2 ways,
* and two 2s from [2,2,2,2] in 6 ways.
* 
* Constraints:
*     3 <= arr.length <= 3000
*     0 <= arr[i] <= 100
*     0 <= target <= 300
*/
/*
 * Runtime: 1224 ms     Your runtime beats 37.50 % of csharp submissions.
 * Memory Usage: 26 MB  Your memory usage beats 25.00 % of csharp submissions.
 */
namespace _0923_3SumWithMultiplicity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(ThreeSumMulti(new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 }, 8));
            Console.WriteLine(ThreeSumMulti(new int[] { 1, 1, 2, 2, 2, 2 }, 5));

            Console.WriteLine(ThreeSumMulti(new int[] { 3, 3, 3 }, 9));
            Console.WriteLine(ThreeSumMulti(new int[] { 3, 3, 3, 3 }, 9));

            /*
             * { 3, 3, 3, 3 }
             * 1 +  +  +
             * 2 +  +     +
             * 3 +     +  +
             * 4    +  +  +
             */
        }

        // modulo 10^9 + 7
        // When you're this big, they call you mister! https://www.youtube.com/watch?v=T0GiULfGnoc
        private const int MrBigPrime = 1_000_000_007;

        static int ThreeSumMulti(int[] arr, int target)
        {
            // guard against a short input
            if ((arr == null) || (arr.Length < 3)) return 0;

            int result = 0;

            // keep track of the the count of the array members
            var theCount = new Dictionary<int, int>();

            for (int i = 1; i < arr.Length - 1; i++)
            {
                int prev = arr[i - 1];

                if (!theCount.ContainsKey(prev))
                {
                    theCount[prev] = 0;
                }

                theCount[prev]++;

                for (int ii = i + 1; ii < arr.Length; ii++)
                {
                    // the candidate is the value needed to complete the triple
                    // with the values found at i and ii
                    int candidate = target - (arr[i] + arr[ii]);

                    if (theCount.ContainsKey(candidate))
                    {
                        // add in the candidate count this solves the 'occurs x times'
                        result += theCount[candidate];
                        result %= MrBigPrime;
                    }
                }
            }

            return result;
        }
    }
}
