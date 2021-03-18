using System;
/*
 * Wiggle Subsequence
 * 
 * Given an integer array nums, return the length of the longest wiggle sequence.
 * 
 * A wiggle sequence is a sequence where the differences between successive numbers 
 * strictly alternate between positive and negative. 
 * 
 * The first difference (if one exists) may be either positive or negative. 
 * A sequence with fewer than two elements is trivially a wiggle sequence.
 * 
 * For example, [1, 7, 4, 9, 2, 5] is a wiggle sequence because the 
 * differences (6, -3, 5, -7, 3) are alternately positive and negative.
 * 
 * In contrast, [1, 4, 7, 2, 5] and [1, 7, 4, 5, 5] are not wiggle sequences, 
 * the first because its first two differences are positive and 
 * the second because its last difference is zero.
 * 
 * A subsequence is obtained by deleting some elements (eventually, also zero) from the original sequence, 
 * leaving the remaining elements in their original order.
 * 
 * Example 1:
 * Input: nums = [1,7,4,9,2,5]
 * Output: 6
 * Explanation: The entire sequence is a wiggle sequence.
 * 
 * Example 2:
 * Input: nums = [1,17,5,10,13,15,10,5,16,8]
 * Output: 7
 * Explanation: There are several subsequences that achieve this length. One is [1,17,10,13,10,16,8].
 * 
 * Example 3:
 * Input: nums = [1,2,3,4,5,6,7,8,9]
 * Output: 2
 * 
 * Constraints:
 *     1 <= nums.length <= 1000
 *     0 <= nums[i] <= 1000
 */
/*
 * Runtime: 92 ms        Your runtime beats 60.38 % of csharp submissions.
 * Memory Usage: 24.2 MB Your memory usage beats 98.11 % of csharp submissions.
 */
namespace _0376_WiggleSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(WiggleMaxLength(new int[] { 1, 7, 4, 9, 2, 5 }));
            Console.WriteLine(WiggleMaxLength(new int[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 }));
            Console.WriteLine(WiggleMaxLength(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));

            Console.WriteLine(WiggleMaxLength(new int[] { 1, 2 }));
            Console.WriteLine(WiggleMaxLength(new int[] { 1, 1 }));
        }

        static int WiggleMaxLength(int[] nums)
        {
            // guard against short array
            if (nums.Length <= 1) return nums.Length;

            int positive = 1;
            int negative = 1;

            /*
             * We need to compare the differences to have a pattern
             * that is +, -, +, -, +
             * The pattern can start with either + or -
             */


            // check each value against the prior value
            for (int i = 1; i < nums.Length; i++)
            {
                /* 
                 * A positive result when comparing will add to the length 
                 * of the last negative count. This will filter out two or more
                 * positives in a row.
                 * The same logic applies to a negative difference
                 */

                if (nums[i] > nums[i - 1])
                {
                    positive = negative + 1;
                }

                else if (nums[i] < nums[i - 1])
                {
                    negative = positive + 1;
                }

                // equal values are just skipped
            }

            return Math.Max(positive, negative);           
        }
    }
}
