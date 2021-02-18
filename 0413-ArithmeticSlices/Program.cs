using System;
/*
 A sequence of numbers is called arithmetic if it consists of:
   at least three elements
   and if the difference between any two consecutive elements is the same.

For example, these are arithmetic sequences:
    1, 3, 5, 7, 9
    7, 7, 7, 7
    3, -1, -5, -9

The following sequence is not arithmetic.
    1, 1, 2, 5, 7


A zero-indexed array A consisting of N numbers is given.
A slice of that array is any pair of integers (P, Q) such that 0 <= P < Q < N.

A slice (P, Q) of the array A is called arithmetic if the sequence:
A[P], A[P + 1], ..., A[Q - 1], A[Q] is arithmetic. In particular, this means that P + 1 < Q.

The function should return the number of arithmetic slices in the array A.
 

Example:
    A = [1, 2, 3, 4]
    return: 3, for 3 arithmetic slices in A: [1, 2, 3], [2, 3, 4] and [1, 2, 3, 4] itself.
 */
/*
 * Runtime: 92 ms        Your runtime beats 63.22 % of csharp submissions.
 * Memory Usage: 24.5 MB Your memory usage beats 52.87 % of csharp submissions.
 */

namespace _0413_ArithmeticSlices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 1, 3, 5, 7, 9 }));
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 7, 7, 7, 7 }));
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 3, -1, -5, -9 }));
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 1, 1, 2, 5, 7 }));
            Console.WriteLine(NumberOfArithmeticSlices(new int[] { 1, 2, 3, 4 }));


            Console.ReadKey();
        }

        public static int NumberOfArithmeticSlices(int[] A)
        {
            // guard clause for a short array
            if (A.Length < 3) return 0; // a slice is at least three elements

            int sliceCount = 0;

            // all this talk of slices has me thinking about pizza

            // possible slice starting positions
            // lenght - 2 => we can't start a slice in the last two elements
            for (int i = 0; i < A.Length - 2; i++)
            {
                // start a slice
                int start = A[i];
                int second = A[i + 1];
                int third = A[i + 2];

                int delta = start - second;

                if (delta != (second - third))
                {
                    continue;
                }
                else
                {
                    // we have a slice!!!
                    sliceCount++;

                    // lets see if it goes four plus characters
                    for (int ii = i + 3; ii < A.Length; ii++)
                    {
                        int fourPlus = A[ii];

                        if (delta == (third - fourPlus))
                        {
                            sliceCount++;
                            third = fourPlus;
                        }
                        else
                        {
                            break;
                        }

                    }

                }
            }

            return sliceCount;
        }
    }
}
