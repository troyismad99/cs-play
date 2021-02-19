using System;
/*
The height of a binary tree is the length of the longest path from the root to any node in the tree.
Given a binary tree represented in a one dimensional array, return the height of the tree.

If the array is empty you should return 0.

Note: empty elements in the input array are represented with the number -1. 
*/
namespace BinaryTreeHeight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(TreeHeight(new long[] { 3, 6, 2, 9, -1, 10 }));
            Console.WriteLine(TreeHeight(Array.Empty<long>()));

            Console.ReadKey();
        }

        public static long TreeHeight(long[] tree)
        {
            // Type your solution here
            if (tree.Length == 0) return 0;

            return TravelNode(tree, 0);

        }

/*
If we observe carefully we can see that if parent node is at index i in the array
then the left child of that node is at index (2*i + 1)
and right child is at index (2*i + 2) in the array.
*/


        public static long TravelNode(long[] arr, int i)
        {
            // guard against missing nodes
            if (i > arr.Length - 1) return 0;

            // guard against empty node
            if (arr[i] == -1) return 0;

            // check the height of each child node
            var leftSum = 1 + TravelNode(arr, (2 * i) + 1);
            var rightSum = 1 + TravelNode(arr, (2 * i) + 2);

            // return the largest
            return Math.Max(leftSum, rightSum);

        }

    }
}
