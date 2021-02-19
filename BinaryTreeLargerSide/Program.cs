using System;
/*

Find the larger half of a binary tree
    3
   / \
  6   2
 /   /
9   10

Given a binary tree represented in a one dimensional array, return the height of the tree.
If the array is empty you should return 0.
Note: empty elements in the input array are represented with the number -1. 

*/
namespace BinaryTreeLargerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(BinaryTreeSize(new long[] { 3, 6, 2, 9, -1, 10 }));
            Console.WriteLine(BinaryTreeSize(Array.Empty<long>()));
            Console.WriteLine(BinaryTreeSize(new long[] { 3, 6, 2, 2, -1, 6 })); // equal tree
            Console.WriteLine(BinaryTreeSize(new long[] { 3, 6 }));
            Console.WriteLine(BinaryTreeSize(new long[] { 3, -1, 10 }));

            Console.ReadKey();

        }

        public static string BinaryTreeSize(long[] arr)
        {            
            if (arr.Length == 0) return string.Empty;

            // sum the two halves and compare
            long left = SumNode(arr, 1);
            long right = SumNode(arr, 2);


            if (left > right)
            {
                return "Left";
            }
            else if (right > left)
            {
                return "Right";
            }

            return string.Empty;
        }

        /*
         * If we observe carefully we can see that if parent node is at index i in the array 
         * then the left child of that node is at index (2*i + 1) 
         * and right child is at index (2*i + 2) in the array.
         */
        public static long SumNode(long[] arr, int i)
        {
            if (i > arr.Length - 1) return 0;

            if (arr[i] == -1) return 0;

            var leftSum = SumNode(arr, (2 * i) + 1);
            var rightSum = SumNode(arr, (2 * i) + 2);

            // sum is this node and the sum of it's children
            return arr[i] + leftSum + rightSum;

        }
    }
}
