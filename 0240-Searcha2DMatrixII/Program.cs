using System;

/* 
 * Search a 2D Matrix II

Write an efficient algorithm that searches for a target value in an m x n integer matrix. The matrix has the following properties:
    Integers in each row are sorted in ascending from left to right.
    Integers in each column are sorted in ascending from top to bottom.

Example 1:

[ 1,  4,  7, 11, 15]
[ 2,  5,  8, 12, 19]
[ 3,  6,  9, 16, 22]
[10, 13, 14, 17, 24]
[18, 21, 23, 26, 30]

Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 5
Output: true

Example 2:
Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]], target = 20
Output: false

Constraints:
    m == matrix.length
    n == matrix[i].length
    1 <= n, m <= 300
    -109 <= matix[i][j] <= 109
    All the integers in each row are sorted in ascending order.
    All the integers in each column are sorted in ascending order.
    -109 <= target <= 109

 */

/*
 * Runtime: 160 ms     Your runtime beats 63.10 % of csharp submissions.
 * Memory Usage: 31 MB Your memory usage beats 97.82 % of csharp submissions.
 */

namespace _0240_Searcha2DMatrixII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(SearchMatrix(new int[][]
                                            { new int[] { 1, 4, 7, 11, 15 },
                                              new int[] { 2, 5, 8, 12, 19 },
                                              new int[] { 3, 6, 9, 16, 22 },
                                              new int[] { 10, 13, 14, 17, 24 },
                                              new int[] { 18, 21, 23, 26, 30 }
               }, 5));

            Console.WriteLine(SearchMatrix(new int[][]
                                            { new int[] { 1, 4, 7, 11, 15 },
                                              new int[] { 2, 5, 8, 12, 19 },
                                              new int[] { 3, 6, 9, 16, 22 },
                                              new int[] { 10, 13, 14, 17, 24 },
                                              new int[] { 18, 21, 23, 26, 30 }
               }, 20));

            Console.WriteLine(SearchMatrix(new int[][]
                                            { new int[] { -5 }
                                             
               }, -10));




            Console.ReadKey();
        }

        public static bool SearchMatrix(int[][] matrix, int target)
        {
            // guard against missing inputs
            if ((matrix == null) || (matrix.Length < 1) || (matrix[0].Length < 1)) return false;

            // we are searching and our matrix is ordered, seems like a binary search would fit well.
            // however we can also start in either the top right or bottom left corner and rule out entire rows or columns

            // top right
            int row = 0;
            int col = matrix[0].Length - 1;

            while ((row <= matrix.Length - 1) && (col >= 0))
            {
                if (matrix[row][col] == target)
                {
                    // found it
                    return true;
                }

                if (matrix[row][col] > target)
                {
                    // since values are sorted, all values in this column will be also be larger
                    // eliminate this column
                    col--;
                } else if (matrix[row][col] < target)
                {
                    // again since the values are sorted move to the next row to try and find a bigger value
                    row++;
                }
            }
             
            return false;
        }

        public static bool SearchMatrixBruteForce(int[][] matrix, int target)
        {
            // easy solution
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int ii = 0; ii < matrix[i].Length; ii++)
                {
                    if (matrix[i][ii] == target)
                        return true;
                }
            }

            return false;
        }



    }

}
