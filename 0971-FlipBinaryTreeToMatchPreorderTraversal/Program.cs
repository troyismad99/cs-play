using System;
using System.Collections.Generic;
/*
* Flip Binary Tree To Match Preorder Traversal
* 
* You are given the root of a binary tree with n nodes, where each node is 
* uniquely assigned a value from 1 to n. 
* You are also given a sequence of n values voyage, 
* which is the desired pre-order traversal of the binary tree.
* 
* Any node in the binary tree can be flipped by swapping its left 
* and right subtrees. 
* For example, flipping node 1 will have the following effect:
* 
*      1            1
*     / \          / \
*    2   3        3   2
*       / \      / \ 
*      4   5    4   5
* 
* Flip the smallest number of nodes so that the 
* pre-order traversal of the tree matches voyage.
* 
* Return a list of the values of all flipped nodes. 
* You may return the answer in any order. 
* If it is impossible to flip the nodes in the tree to make the 
* pre-order traversal match voyage, return the list [-1].
* 
* Example 1:
* 
*    1
*   /
*  2
* 
* Input: root = [1,2], voyage = [2,1]
* Output: [-1]
* Explanation: It is impossible to flip the nodes such that the 
* pre-order traversal matches voyage.
* 
* Example 2:
* 
*    1
*   / \
*  2   3
* 
* Input: root = [1,2,3], voyage = [1,3,2]
* Output: [1]
* Explanation: Flipping node 1 swaps nodes 2 and 3, 
* so the pre-order traversal matches voyage.
* 
* Example 3:
* 
*    1
*   / \
*  2   3
*  
* Input: root = [1,2,3], voyage = [1,2,3]
* Output: []
* Explanation: The tree's pre-order traversal already matches voyage, 
* so no nodes need to be flipped.
* 
* Constraints:
*     The number of nodes in the tree is n.
*     n == voyage.length
*     1 <= n <= 100
*     1 <= Node.val, voyage[i] <= n
*     All the values in the tree are unique.
*     All the values in voyage are unique.
*     
*/
/*
 * Runtime: 228 ms       Your runtime beats 100.00 % of csharp submissions.
 * Memory Usage: 31.4 MB
 */
namespace _0971_FlipBinaryTreeToMatchPreorderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var e1 = new TreeNode(1)
            {
                left = new TreeNode(2)
            };

            var a1 = FlipMatchVoyage(e1, new int[] { 2, 1 });

            e1.right = new TreeNode(3);

            var a2 = FlipMatchVoyage(e1, new int[] { 1, 3, 2 });
            var a3 = FlipMatchVoyage(e1, new int[] { 1, 2 ,3 });

            Console.WriteLine(string.Join(',', a1));
            Console.WriteLine(string.Join(',', a2));
            Console.WriteLine(string.Join(',', a3));
        }

        static IList<int> result = new List<int>();
        static int vIndex = 0;

        static IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {
            // we have a problem constraint to prevent this...
            // but it's a good practice to validate
            if (root == null)
            {
                return new List<int>();
            }

            result = new List<int>();
            vIndex = 0;

            if (DFS(root, voyage))
            {
                return result;
            }
            else
            {
                return new List<int>() { -1 };
            }
        }

        // Depth First Search
        static bool DFS(TreeNode node, int[] v)
        {
            // nothing to see here
            if (node == null) return true;

            // no match
            if (node.val != v[vIndex++])
            {
                return false;
            }

            // flip a left that exists and doesn't match
            if (node.left != null && node.left.val != v[vIndex])
            {
                result.Add(node.val);
                return DFS(node.right, v) && DFS(node.left, v);
            }
            
            // continue
            return DFS(node.left, v) && DFS(node.right, v);
        }

    }

    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
 
}
