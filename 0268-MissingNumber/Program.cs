using System;
/*
 * Missing Number

Given an array nums containing n distinct numbers in the range [0, n],
return the only number in the range that is missing from the array.

Follow up: Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity?

Example 1:
Input: nums = [3,0,1]
Output: 2
Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.

Example 2:
Input: nums = [0,1]
Output: 2
Explanation: n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.

Example 3:
Input: nums = [9,6,4,2,3,5,7,0,1]
Output: 8
Explanation: n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.

Example 4:
Input: nums = [0]
Output: 1
Explanation: n = 1 since there is 1 number, so all numbers are in the range [0,1]. 1 is the missing number in the range since it does not appear in nums.

Constraints:
    n == nums.length
    1 <= n <= 104
    0 <= nums[i] <= n
    All the numbers of nums are unique.
 */

/*
 * Runtime: 116 ms       Your runtime beats 49.56 % of csharp submissions.
 * Memory Usage: 30.4 MB Your memory usage beats 35.02 % of csharp submissions.
 */

namespace _0268_MissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(MissingNumber(new int[] { 3, 0, 1 }));
            Console.WriteLine(MissingNumber(new int[] { 0, 1 }));
            Console.WriteLine(MissingNumber(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }));
            Console.WriteLine(MissingNumber(new int[] { 0 }));

        }

        static int MissingNumber(int[] nums)
        {
            /* Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity?
             * 
             * O(1) Space means that our memory does not change regardless of the input
             *      - In other waords: we only allocate constant space
             *      - This means our footprint is the same for every length of nums
             *      - so we won't be creating a second array to hold the results
             * 
             * O(n) Time complexity means our algorithm runtime will change based on the inputs
             *      - Our performance will grow linearally based on the length of nums
             *      - if we double the number of elements, the worst case is we double the time
             *      - this would imply that we loop through the array once
             */

            // Carl Gauss Formula
            // https://nrich.maths.org/2478

            // O(1) space > Only two ints are allocated
            var gaussSum = nums.Length * (nums.Length + 1) / 2;
            var sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            return gaussSum - sum;
        }
    }
}
