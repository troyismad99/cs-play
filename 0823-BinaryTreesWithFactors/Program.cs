using System;
using System.Linq;
/*
* Binary Trees With Factors
* 
* Given an array of unique integers, arr, where each integer arr[i] is strictly greater than 1.
* We make a binary tree using these integers, and each number may be used for any number of times. 
* Each non-leaf node's value should be equal to the product of the values of its children.
* 
* Return the number of binary trees we can make. 
* The answer may be too large so return the answer modulo 10^9 + 7.
* 
* Example 1:
*      Input: arr = [2,4]
*      Output: 3
*      Explanation: We can make these trees: [2], [4], [4, 2, 2]
*      
* Example 2:
*      Input: arr = [2,4,5,10]
*      Output: 7
*      Explanation: We can make these trees: [2], [4], [5], [10], [4, 2, 2], [10, 2, 5], [10, 5, 2].
*      
* Constraints:
*  1 <= arr.length <= 1000
*  2 <= arr[i] <= 10^9
*/
/*
 * Runtime: 128 ms        Your runtime beats 66.67 % of csharp submissions.
 * Memory Usage: 25.1 MB  
 */
namespace _0823_BinaryTreesWithFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumFactoredBinaryTrees(new int[] { 2, 4 }));
            Console.WriteLine(NumFactoredBinaryTrees(new int[] { 2, 4, 5, 10 }));

            Console.WriteLine("Hello World!");
        }

        // modulo 10^9 + 7
        private const int MrBigPrime = 1_000_000_007; // When you're this big they call you mister!


        static int NumFactoredBinaryTrees(int[] arr)
        {
            int result = 0;

            // Dynamic programming with memoization
            // ie: we will remember what we have already calculated
            var memo = Enumerable.Repeat(-1, arr.Length).ToArray();

            Array.Sort(arr);

            // count the trees available for each member of the array
            for (int i = 0; i < arr.Length; i++)
            {
                result = (result + Count(arr, memo, i)) % MrBigPrime;
            }

            return result;
        }

        static int Count(int[] arr, int[] memo, int index)
        {
            // do we already have this one?
            if (memo[index] != -1)
            {
                return memo[index];
            }

            // we will always have a tree with just one node
            memo[index] = 1;

            // we will double pointer our way through the array
            // looking for factors
            int start = 0;
            int end = arr.Length - 1;

            while (start <= end)
            {
                // get the candidate from each pointer
                long candidate = arr[start] * (long)arr[end];

                // does it match the value we are searching
                if (candidate == arr[index])
                {
                    // if we have a match (we have found two factors)
                    // check if the tree can grow by checking if there are factors
                    // for each factor  (start and end)
                    int sCount = Count(arr, memo, start);
                    int eCount = Count(arr, memo, end);
                    long totalCount = (sCount * (long)eCount) % MrBigPrime;

                    // if our pointers do not point to the the same value
                    // we can have more trees by swapping left and right
                    // ex: [10, 2, 5], [10, 5, 2]
                    if (start != end)
                    {
                        totalCount = (totalCount * 2) % MrBigPrime;
                    }

                    memo[index] = (int)(memo[index] + totalCount) % MrBigPrime;

                    start++;
                    end--;
                }
                else if (candidate < arr[index])
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }

            return memo[index];
        }


    }
}
