using System;
using System.Collections.Generic;
using System.Linq;
/*

Given a m * n matrix mat of ones (representing soldiers) and zeros (representing civilians),
return the indexes of the k weakest rows in the matrix ordered from the weakest to the strongest.

A row i is weaker than row j:
if the number of soldiers in row i is less than the number of soldiers in row j,
or they have the same number of soldiers but i is less than j.

Soldiers are always stand in the frontier of a row, that is, always ones may appear first and then zeros.

Example 1:
    Input: mat = 
    [[1,1,0,0,0],
     [1,1,1,1,0],
     [1,0,0,0,0],
     [1,1,0,0,0],
     [1,1,1,1,1]], 
    k = 3
    Output: [2,0,3]
    Explanation: 
    The number of soldiers for each row is: 
    row 0 -> 2 
    row 1 -> 4 
    row 2 -> 1 
    row 3 -> 2 
    row 4 -> 5 
    Rows ordered from the weakest to the strongest are [2,0,3,1,4]

Example 2:
    Input: mat = 
    [[1,0,0,0],
     [1,1,1,1],
     [1,0,0,0],
     [1,0,0,0]], 
    k = 2
    Output: [0,2]
    Explanation: 
    The number of soldiers for each row is: 
    row 0 -> 1 
    row 1 -> 4 
    row 2 -> 1 
    row 3 -> 1 
    Rows ordered from the weakest to the strongest are [0,2,3,1]

Constraints:
    m == mat.length
    n == mat[i].length
    2 <= n, m <= 100
    1 <= k <= m
    matrix[i][j] is either 0 or 1.
 */

/*
 * Runtime: 268 ms        Your runtime beats 22.73 % of csharp submissions.
 * Memory Usage: 33.5 MB  Your memory usage beats 60.61 % of csharp submissions.
 */

namespace _1337_TheKWeakestRowsinaMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(String.Join(",", KWeakestRows(new int[][]
                                           { new int[] { 1,1,0,0,0 },
                                             new int[] { 1,1,1,1,0 },
                                             new int[] { 1,0,0,0,0 },
                                             new int[] { 1,1,0,0,0 },
                                             new int[] { 1,1,1,1,1 }
                                           }, 3)));

            Console.WriteLine(String.Join(",", KWeakestRows(new int[][]
                                           { new int[] { 1,0,0,0 },
                                             new int[] { 1,1,1,1 },
                                             new int[] { 1,0,0,0 },
                                             new int[] { 1,0,0,0 }
                                           }, 2)));
            Console.ReadKey();
        }

        public static int[] KWeakestRows(int[][] mat, int k)
        {
            // lets count the soldiers in each row
            Dictionary<int,int> theCount = new Dictionary<int, int>();

            for (int i = 0; i < mat.Length; i++)
            {
                theCount.Add(i, mat[i].Count(n => n == 1));               
            }
            
            int[] result = theCount.OrderBy(x => x.Value) // sort them by soldier count
                                   .ThenBy(x => x.Key)    // then row order
                                   .Take(k)               // return this many
                                   .Select(x => x.Key)    // just the row index
                                   .ToArray();

            return result;

        }

    }
}
