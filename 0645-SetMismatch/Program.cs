using System;
/* 
 * Set Mismatch
 * 
You have a set of integers s, which originally contains all the numbers from 1 to n.
Unfortunately, due to some error, one of the numbers in s got duplicated to another number in the set,
which results in repetition of one number and loss of another number.

You are given an integer array nums representing the data status of this set after the error.

Find the number that occurs twice and the number that is missing and return them in the form of an array.

Example 1:
Input: nums = [1,2,2,4]
Output: [2,3]

Example 2:
Input: nums = [1,1]
Output: [1,2]

Constraints:
    2 <= nums.length <= 104
    1 <= nums[i] <= 104

 */
/*
 * Runtime: 264 ms       Your runtime beats 85.00 % of csharp submissions.
 * Memory Usage: 38.6 MB Your memory usage beats 36.25 % of csharp submissions.
 */
namespace _0645_SetMismatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = FindErrorNums(new int[] { 1, 2, 2, 4 });
            var b = FindErrorNums(new int[] { 1, 1 });


            Console.WriteLine($"A: {a[0]} {a[1]}");
            Console.WriteLine($"B: {b[0]} {b[1]}");

        }

        static int[] FindErrorNums(int[] nums)
        {
            var result = new int[2] { 0, 0 };

            // Count the occurences in a new array
            var occurenceMap = new int[nums.Length + 1];

            foreach (var n in nums)
            {
                occurenceMap[n]++;
            }

            // traverse the array and find the missing and duplicate
            for (int i = 1; i < occurenceMap.Length; i++)
            {
                if (occurenceMap[i] == 2)
                {
                    result[0] = i;

                    // we could put a leave early test
                    if (result[1] != 0) break;
                }
                else if (occurenceMap[i] == 0)
                {
                    result[1] = i;
                    if (result[0] != 0) break;
                }
            }

            return result;
        }
    }
}
