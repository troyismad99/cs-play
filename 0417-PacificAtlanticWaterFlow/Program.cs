using System;
using System.Collections.Generic;
/*
* Pacific Atlantic Water Flow
* 
* Given an m x n matrix of non-negative integers representing the height of each unit cell in a continent, 
* the "Pacific ocean" touches the left and top edges of the matrix and 
* the "Atlantic ocean" touches the right and bottom edges.
* 
* Water can only flow in four directions (up, down, left, or right) 
* from a cell to another one with height equal or lower.
* 
* Find the list of grid coordinates where water can flow to both the Pacific and Atlantic ocean.
* 
* Note:
* The order of returned grid coordinates does not matter.
* Both m and n are less than 150.
* 
* Example:
* Given the following 5x5 matrix:
*     Pacific ~   ~   ~   ~   ~ 
*          ~  1   2   2   3  (5) *
*          ~  3   2   3  (4) (4) *
*          ~  2   4  (5)  3   1  *
*          ~ (6) (7)  1   4   5  *
*          ~ (5)  1   1   2   4  *
*             *   *   *   *   * Atlantic
*             
* Return:
* [[0, 4], [1, 3], [1, 4], [2, 2], [3, 0], [3, 1], [4, 0]] 
* (positions with parentheses in above matrix).
* 
*/
/*
 * Runtime: 272 ms     Your runtime beats 93.59 % of csharp submissions.
 * Memory Usage: 35 MB Your memory usage beats 44.87 % of csharp submissions.
 */
namespace _0417_PacificAtlanticWaterFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var ex1 = new int[5][];
            ex1[0] = new int[] { 1, 2, 2, 3, 5 };
            ex1[1] = new int[] { 3, 2, 3, 4, 4 };
            ex1[2] = new int[] { 2, 4, 5, 3, 1 };
            ex1[3] = new int[] { 6, 7, 1, 4, 5 };
            ex1[4] = new int[] { 5, 1, 1, 2, 4 };

            var result = PacificAtlantic(ex1);

            foreach (var item in result)
            {
                Console.WriteLine( string.Join(',', item) );
            }

            var ex2 = new int[5][];
            ex2[0] = new int[] { 1, 2, 2, 3, 5, 6, 7 };
            ex2[1] = new int[] { 3, 2, 3, 4, 4, 3, 2 };
            ex2[2] = new int[] { 2, 4, 5, 3, 1, 4, 3 };
            ex2[3] = new int[] { 6, 7, 1, 4, 5, 5, 4 };
            ex2[4] = new int[] { 5, 1, 1, 2, 4, 1, 1 };

            result = PacificAtlantic(ex2);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(',', item));
            }

        }

        static IList<IList<int>> PacificAtlantic(int[][] matrix)
        {           
            var result = new List<IList<int>>();

            // guard against small matrix
            if ((matrix.Length == 0) || (matrix[0].Length == 0)) return result;

            // will track if a cell can flow to the pacific or atlatic
            bool[,] pacific = new bool[matrix.Length, matrix[0].Length];
            bool[,] atlantic = (bool[,])pacific.Clone();

            // we will start our checks with the ocean boudaries
            for (int i = 0; i < matrix.Length; i++)
            {
                DFS(i, 0, int.MinValue, matrix, pacific);
                DFS(i, matrix[0].Length - 1, int.MinValue, matrix, atlantic);
            }

            // the other boudaries
            // NOTE: we could start i at 1 and end with matrix[0].Length-1
            //       since those corners were checked above.
            //       But I think this more readable
            for (int i = 0; i < matrix[0].Length; i++)
            {
                DFS(0, i, int.MinValue, matrix, pacific);
                DFS(matrix.Length - 1, i, int.MinValue, matrix, atlantic);
            }

            // check for cells that can flow to both oceans
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int ii = 0; ii < matrix[0].Length; ii++)
                {
                    if (pacific[i,ii] && atlantic[i,ii])
                    {
                        result.Add(new List<int>() { i, ii });
                    }

                }

            }

            return result;
        }

        static void DFS(int row, int col, int pre, int[][] matrix,   bool[,] ocean)
        {
            // don't fall into the ocean
            if (row >= matrix.Length || row < 0 || col >= matrix[0].Length || col < 0) return;

            // have we been here before?
            if (ocean[row, col]) return;

            // we cannot move to a higher value
            if (pre > matrix[row][col]) return;

            ocean[row, col] = true;

            // check all four directions
            DFS(row - 1, col, matrix[row][col], matrix, ocean);
            DFS(row + 1, col, matrix[row][col], matrix, ocean);
            DFS(row, col - 1, matrix[row][col], matrix, ocean);
            DFS(row, col + 1, matrix[row][col], matrix, ocean);
        }



    }
}
