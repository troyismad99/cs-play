using System;
using System.Collections.Generic;
using System.Linq;
/*
n an N by N square grid, each cell is either empty (0) or blocked (1).

A clear path from top-left to bottom-right has length k if and only if it is composed of cells C_1, C_2, ..., C_k such that:
Adjacent cells C_i and C_{i+1} are connected 8-directionally (ie., they are different and share an edge or corner)
C_1 is at location (0, 0) (ie. has value grid[0][0])
C_k is at location (N-1, N-1) (ie. has value grid[N-1][N-1])
If C_i is located at (r, c), then grid[r][c] is empty (ie. grid[r][c] == 0).

Return the length of the shortest such clear path from top-left to bottom-right.  If such a path does not exist, return -1.

Example 1:
Input: [[0,1],[1,0]]

0 1
1 0

Output: 2 (From 0 - 0 diagonally)
0 1
\
1 0



Example 2:
Input: [[0,0,0],[1,1,0],[1,1,0]]

0 0 0
1 1 0
1 1 0

Output: 4
0-0 0
\
1 1 0
|
1 1 0


Note:
1 <= grid.length == grid[0].length <= 100
grid[r][c] is 0 or 1
*/

/*
 * Runtime: 148 ms Your runtime beats 90.91 % of csharp submissions.
 * Memory Usage: 30.1 MB Your memory usage beats 83.33 % of csharp submissions.
 */

namespace _1091_ShortestPathinBinaryMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // jagged array
            int[][] one = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 0 }
            };

            Console.WriteLine(ShortestPathBinaryMatrix(one));

            Console.WriteLine(ShortestPathBinaryMatrix(new int[][]
                                                     { new int[] { 0, 0, 0 },
                                                       new int[] { 1, 1, 0 },
                                                       new int[] { 1, 1, 0 }

            }));

            Console.ReadKey();
        }

        public static int ShortestPathBinaryMatrix(int[][] grid)
        {
            // check our grid
            if ((grid == null) || (grid.Length == 0) || grid[0].Length == 0) return -1;

            // make sure start and end are 'open' ie == 0
            if ((grid[0][0] != 0) || grid[grid.Length - 1][grid[0].Length - 1] != 0) return -1;

            int gridRowCount = grid.Length;
            int gridColCount = grid[0].Length;

            var pathQueue = new Queue<(int, int)>();
            var pathLength = 0;

            // starting position
            pathQueue.Enqueue((0, 0));

            // get busy
            while (pathQueue.Any())
            {
                // take a step
                pathLength++;

                // how far are we
                var pathLevel = pathQueue.Count;

                for (var l = 0; l < pathLevel; l++)
                {
                    // process this node
                    var (row, col) = pathQueue.Dequeue();

                    // have we reached the finish?
                    if (row == gridRowCount - 1 && col == gridColCount - 1) return pathLength;

                    // check the neighbors
                    for (var i = -1; i <= 1; i++)
                        for (var ii = -1; ii <= 1; ii++)
                        {
                            // make sure we stay within the bounds of our grid
                            if ((row + i < 0)
                                || (col + ii < 0)
                                || (row + i >= gridRowCount)
                                || (col + ii >= gridColCount)
                               )
                            {
                                continue;
                            }

                            // we need an open cell
                            if (grid[row + i][col + ii] != 0)
                            {
                                continue;
                            }

                            // mark this one and add it to the queue
                            grid[row + i][col + ii] = -1;
                            pathQueue.Enqueue((row + i, col + ii));
                        }
                }
            }

            return -1;
        }

    }
}
