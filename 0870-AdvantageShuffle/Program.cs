using System;
using System.Collections.Generic;
/*
 * Advantage Shuffle
 * 
 * Given two arrays A and B of equal size, 
 * the advantage of A with respect to B 
 * is the number of indices i for which A[i] > B[i].
 * 
 * Return any permutation of A that maximizes its advantage with respect to B.
 * 
 * Example 1:
 * Input: A = [2,7,11,15], B = [1,10,4,11]
 * Output: [2,11,7,15]
 * 
 * Example 2:
 * Input: A = [12,24,8,32], B = [13,25,32,11]
 * Output: [24,32,8,12]
 * 
 * Note:
 *     1 <= A.length = B.length <= 10000
 *     0 <= A[i] <= 10^9
 *     0 <= B[i] <= 10^9
 *     
 */
/*
 * Runtime: 352 ms       Your runtime beats 80.00 % of csharp submissions.
 * Memory Usage: 44.5 MB Your memory usage beats 93.33 % of csharp submissions.
 */
namespace _0870_AdvantageShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var e1 = AdvantageCount(new int[] { 2, 7, 11, 15 }, new int[] { 1, 10, 4, 11 });
            Console.WriteLine(String.Join(", ", e1));

            var e2 = AdvantageCount(new int[] { 12, 24, 8, 32 }, new int[] { 13, 25, 32, 11 });
            Console.WriteLine(String.Join(", ", e2));

            var e3 = AdvantageCount(new int[] { 5, 4, 3, 2 }, new int[] { 1, 2, 3, 4 });
            Console.WriteLine(String.Join(", ", e3));

            var e4 = AdvantageCount(new int[] { 30, 28, 19 }, new int[] { 27, 21, 20 });
            Console.WriteLine(String.Join(", ", e4));

        }

        static int[] AdvantageCount(int[] A, int[] B)
        {
            // guard against short array
            if (A.Length <= 1)
                return A;

            int[] result = new int[A.Length];

            // copy and sort A
            List<int> sortedA = new(A);
            sortedA.Sort();
            
            for (int i = 0; i < B.Length; i++)
            {
                // try and find a value in A that is one higher
                var index = sortedA.BinarySearch(B[i] + 1);

                // not found is a negative number ...
                if (index < 0)
                {
                    // ... that is the bitwise complement of the index of the next element that is larger
                    index = ~index;
                }

                // a return of 'count' means that there was no larger element found
                if(index == sortedA.Count)
                {
                    // use the smallest remaining number
                    index = 0;
                }

                // save our new value
                result[i] = sortedA[index];
                sortedA.RemoveAt(index);

            }

            return result;
        }

    }
}
