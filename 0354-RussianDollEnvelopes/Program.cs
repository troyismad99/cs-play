using System;
using System.Linq;
/*
 * Russian Doll Envelopes
 * 
 * You are given a 2D array of integers envelopes where 
 * envelopes[i] = [wi, hi] represents the width and the height of an envelope.
 * 
 * One envelope can fit into another if and only if both the width and height 
 * of one envelope is greater than the width and height of the other envelope.
 * 
 * Return the maximum number of envelopes can you Russian doll 
 * (i.e., put one inside the other).
 * 
 * Note: You cannot rotate an envelope.
 * 
 * Example 1:
 * Input: envelopes = [[5,4],[6,4],[6,7],[2,3]]
 * Output: 3
 * Explanation: The maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]).
 * 
 * Example 2:
 * Input: envelopes = [[1,1],[1,1],[1,1]]
 * Output: 1
 * 
 * Constraints:
 *     1 <= envelopes.length <= 5000
 *     envelopes[i].length == 2
 *     1 <= wi, hi <= 10^4
 *     
 */
/*
 * Runtime: 132 ms       Your runtime beats 88.51 % of csharp submissions.
 * Memory Usage: 30.7 MB Your memory usage beats 28.74 % of csharp submissions.
 */
namespace _0354_RussianDollEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(MaxEnvelopes(null));
            Console.WriteLine(MaxEnvelopes(Array.Empty<int[]>()));
            Console.WriteLine(MaxEnvelopes(new int[][] { null }));
            Console.WriteLine(MaxEnvelopes(new int[][] { new int[] { 1 } }));

            Console.WriteLine(MaxEnvelopes(new int[][]
                                            { new int[] { 5, 4 },
                                              new int[] { 6, 4 },
                                              new int[] { 6, 7 },
                                              new int[] { 2, 3 } }));


            Console.WriteLine(MaxEnvelopes(new int[][]
                                            { new int[] { 1, 1 },
                                              new int[] { 1, 1 },
                                              new int[] { 1, 1 } }));


            Console.WriteLine(MaxEnvelopes(new int[][]
                                            { new int[] { 1, 1 },
                                              new int[] { 2, 2 },
                                              new int[] { 3, 3 },
                                              new int[] { 4, 4 } }));


            Console.WriteLine(MaxEnvelopes(new int[][]
                                            { new int[] { 1, 1 },
                                              new int[] { 2, 9 },
                                              new int[] { 3, 3 },
                                              new int[] { 4, 4 } }));

        }

        static int MaxEnvelopes(int[][] envelopes)
        {
            /*
             * Longest increasing subsequence (lis) problem 
             * but in two dimensions.
             * 
             * Sorting the envelopes by width will solve the first dimension
             * then we can find the lis on the second (height) dimension.
             * 
             * The height dimension is sorted descending when width is tied.
             * When we lis the height it will make sure we do not try and place 
             * an envelope inside another of the same width.
             * From the first example above:
             *     If [6,4] and [6,7] are sorted, the lis will try properly try 
             *     and put the 4 height inside the 7. When they are sorted desc, 
             *     the 7 will never be put into the 4.
             */

            // guard against incorrect envelopes
            if ((envelopes == null) || (envelopes.Length == 0) || (envelopes[0] == null) || (envelopes[0].Length != 2))
                return 0;

            if (envelopes.Length == 1) return 1;

            // sort by width(0) then by height(1) descending
            var sorted = envelopes.OrderBy(e => e[0]).ThenByDescending(e => e[1]).Select(e => e[1]).ToArray();

            int[] lis = new int[sorted.Length];

            int result = 0;

            for (int i = 0; i < sorted.Length; i++)
            {
                var index = Array.BinarySearch(lis, 0, result, sorted[i]);

                // not found is a negative number ...
                if (index < 0)
                {
                    // ... that is the bitwise complement of the index of the next element that is larger
                    index = ~index;
                }

                lis[index] = sorted[i];

                if (index == result) result++;
            }

            return result;
        }
    }
}
