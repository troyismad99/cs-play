using System;
using System.Text;
/*
* Swapping Nodes in a Linked List
* 
* You are given the head of a linked list, and an integer k.
* Return the head of the linked list after swapping the values of the 
* kth node from the beginning and the kth node from the end (the list is 1-indexed).
* 
* Example 1:
* Input: head = [1,2,3,4,5], k = 2
* Output: [1,4,3,2,5]
* 
* Example 2:
* Input: head = [7,9,6,6,7,8,3,0,9,5], k = 5
* Output: [7,9,6,6,8,7,3,0,9,5]
* 
* Example 3:
* Input: head = [1], k = 1
* Output: [1]
* 
* Example 4:
* Input: head = [1,2], k = 1
* Output: [2,1]
* 
* Example 5:
* Input: head = [1,2,3], k = 2
* Output: [1,2,3]
* 
* Constraints:
* The number of nodes in the list is n.
* 1 <= k <= n <= 10^5
* 0 <= Node.val <= 100
*/
/*
 * Runtime: 336 ms       Your runtime beats 96.83 % of csharp submissions.
 * Memory Usage: 53.5 MB Your memory usage beats 45.25 % of csharp submissions.
 */
namespace _1721_SwappingNodesinaLinkedList
{
    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ListNode e1 = new(1);
            e1.next = new(2);
            e1.next.next = new(3);
            e1.next.next.next = new(4);
            e1.next.next.next.next = new(5);

            Console.WriteLine(Nodes(e1));
            e1 = SwapNodes(e1, 2);
            Console.WriteLine(Nodes(e1));

            // [7,9,6,6,7,8,3,0,9,5]
            ListNode e2 = new(7);
            e2.next = new(9);
            e2.next.next = new(6);
            e2.next.next.next = new(6);
            e2.next.next.next.next = new(7);
            e2.next.next.next.next.next = new(8);
            e2.next.next.next.next.next.next = new(3);
            e2.next.next.next.next.next.next.next = new(0);
            e2.next.next.next.next.next.next.next.next = new(9);
            e2.next.next.next.next.next.next.next.next.next = new(5);

            Console.WriteLine(Nodes(e2));
            e2 = SwapNodes(e2, 5);
            Console.WriteLine(Nodes(e2));




        }

        static string Nodes (ListNode start)
        {
            StringBuilder sb = new();

            while (start != null)
            {
                sb.Append("->");
                sb.Append(start.val);
                start = start.next;

            }

            return sb.ToString();
        }

        static ListNode SwapNodes(ListNode head, int k)
        {

            ListNode left = head;
            ListNode last;
            ListNode right = head;

            // find node k (the first node to swap)
            // this is our left pointer
            for (int i = 1; i < k; i++)
            {
                left = left.next;
            }

            // start our last pointer at the swap node
            // right is still at the beginning of the list
            // exactly k behind last
            last = left;

            // find the last now right is k from the end
            while (last.next != null)
            {
                right = right.next;
                last = last.next;
            }

            // swap and return
            int temp = right.val;
            right.val = left.val;
            left.val = temp;

            return head;
        }

    }
}
