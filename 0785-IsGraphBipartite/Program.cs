using System;
/*
Given an undirected graph, return true if and only if it is bipartite.

Recall that a graph is bipartite if we can split its set of nodes into two independent subsets A and B,
   such that every edge in the graph has one node in A and another node in B.

The graph is given in the following form:
- graph[i] is a list of indexes j for which the edge between nodes i and j exists.
- Each node is an integer between 0 and graph.length - 1.
- There are no self edges or parallel edges: graph[i] does not contain i, and it doesn't contain any element twice.

 

Example 1:
0-1
| |
3-2

Input: graph = [[1,3],[0,2],[1,3],[0,2]]
Output: true
Explanation: We can divide the vertices into two groups: {0, 2} and {1, 3}.

Example 2:
0-1
|\|
3-2

Input: graph = [[1,2,3],[0,2],[0,1,3],[0,2]]
Output: false
Explanation: We cannot find a way to divide the set of nodes into two independent subsets.

Constraints:
    1 <= graph.length <= 100
    0 <= graph[i].length < 100
    0 <= graph[i][j] <= graph.length - 1
    graph[i][j] != i
    All the values of graph[i] are unique.
    The graph is guaranteed to be undirected. 
 */

/*
 * Runtime: 120 ms       Your runtime beats 69.55 % of csharp submissions.
 * Memory Usage: 29.2 MB Your memory usage beats 79.58 % of csharp submissions.
 */

namespace _0785_IsGraphBipartite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(IsBipartite(new int[][]
                                            { new int[] { 1, 3 },
                                              new int[] { 0, 2 },
                                              new int[] { 1, 3 },
                                              new int[] { 0, 2 }
           }));

            Console.WriteLine(IsBipartite(new int[][]
                                            { new int[] { 1, 2, 3 },
                                              new int[] { 0, 2 },
                                              new int[] { 0, 1, 3 },
                                              new int[] { 0, 2 }
           }));

            Console.ReadKey();
        }

        public static bool IsBipartite(int[][] graph)
        {
            /*
             * I had a hard time figuring out the question so I stole this 
             * algorithm from: 
             * https://leetcode.com/problems/is-graph-bipartite/discuss/358300/C-code-using-DFS
             * 
             * I then worked backwards.
             */

            int nodeCounts = graph.Length;


            /*
             * Think of the solution using colours. 
             * Try and colour the nodes using two colours such that no conected 
             * nodes have the same colour.
             */

            // instead of two colours we use a bool, which has two states
            bool?[] codes = new bool?[nodeCounts];
            
            for (int i = 0; i < nodeCounts; i++)
            {
                if (codes[i] == null && !dfs(i, graph, false, codes))
                {
                    return false;
                }
            }

            return true;
        }


        private static bool dfs(int node, int[][] graph, bool currentCode, bool?[] codes)
        {
            // have we alread processed this node?
            if (codes[node] == null)
            {
                // set the value
                codes[node] = currentCode;

                for (int i = 0; i < graph[node].Length; i++)
                {
                    // process the connected nodes with the opposite 'currentCode'
                    if (!dfs(graph[node][i], graph, !currentCode, codes))
                    {
                        return false;
                    }
                }

                return true;
            }

            // if we have processed this node ...
            // ... check that it matches what we are trying to set
            return codes[node] == currentCode;
        }

    }
}
