using System;
/*
 * Shortest Unsorted Continuous Subarray

Given an integer array nums, you need to find one continuous subarray that if you only sort this subarray in ascending order,
then the whole array will be sorted in ascending order.

Return the shortest such subarray and output its length.

Example 1:
    Input: nums = [2,6,4,8,10,9,15]
    Output: 5
    Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.

Example 2:
    Input: nums = [1,2,3,4]
    Output: 0

Example 3:
    Input: nums = [1]
    Output: 0

Constraints:
    1 <= nums.length <= 104
    -105 <= nums[i] <= 105
 */

/*
 * Runtime: 144 ms       Your runtime beats 37.81 % of csharp submissions.
 * Memory Usage: 33.1 MB Your memory usage beats 10.08 % of csharp submissions.
 */

namespace _0581_ShortestUnsortedContinuousSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(FindUnsortedSubarray(new int[] { 2, 6, 4, 8, 10, 9, 15 }));
            Console.WriteLine(FindUnsortedSubarray(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine(FindUnsortedSubarray(new int[] { 1 }));

            //Console.WriteLine(FindUnsortedSubarray(null));

        }
        static int FindUnsortedSubarray(int[] nums)
        {
            var sorted = new int[nums.Length];
            Array.Copy(nums, sorted, nums.Length);
            Array.Sort(sorted);
            if (nums == sorted)
            {
                return 0;
            }

            int low = 0;
            bool lowSet = false;
            int high = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != sorted[i])
                {
                    if (!lowSet)
                    {
                        low = i;
                        lowSet = true;
                    }
                    else
                    {
                        high = i + 1;
                    }
                }
            }
            return high - low;






            return 0;
        }
    }
}
