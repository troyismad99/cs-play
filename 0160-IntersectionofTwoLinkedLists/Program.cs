using System;

/* 
 * Intersection of Two Linked Lists
 *
 
Given the heads of two singly linked-lists headA and headB, return the node at which the two lists intersect.
If the two linked lists have no intersection at all, return null.

For example, the following two linked lists begin to intersect at node c1:

      a1 -> a2 \
                 c1 -> c2 -> c3
b1 -> b2 -> b3 /

It is guaranteed that there are no cycles anywhere in the entire linked structure.

Note that the linked lists must retain their original structure after the function returns.
 

Example 1:

    4 - 1 \
           8 - 4 -5
5 - 6 - 1 / 

Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3
Output: Intersected at '8'
Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect).
From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,6,1,8,4,5]. There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.

Example 2:

1 - 9 - 1 \
            2 - 4
        3 /

Input: intersectVal = 2, listA = [1,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
Output: Intersected at '2'
Explanation: The intersected node's value is 2 (note that this must not be 0 if the two lists intersect).
From the head of A, it reads as [1,9,1,2,4]. From the head of B, it reads as [3,2,4]. There are 3 nodes before the intersected node in A; There are 1 node before the intersected node in B.

Example 3:

2 - 6 - 4

    1 - 5

Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
Output: No intersection
Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5]. Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
Explanation: The two lists do not intersect, so return null.
 

Constraints:
    The number of nodes of listA is in the m.
    The number of nodes of listB is in the n.
    1 <= m, n <= 3 * 104
    1 <= Node.val <= 105
    1 <= skipA <= m
    1 <= skipB <= n
    intersectVal is 0 if listA and listB do not intersect.
    intersectVal == listA[skipA + 1] == listB[skipB + 1] if listA and listB intersect.
 */

/*
 * Runtime: 216 ms     Your runtime beats 13.80 % of csharp submissions.
 * Memory Usage: 36 MB Your memory usage beats 94.48 % of csharp submissions.
 */
namespace _0160_IntersectionofTwoLinkedLists
{
    
    // Definition for singly-linked list.
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // 1
            // common 8 - 4 - 5
            ListNode c1 = new ListNode(8) { next = new ListNode(4) { next = new ListNode(5) } };
            ListNode a1 = new ListNode(4) { next = new ListNode(1) };
            ListNode b1 = new ListNode(5) { next = new ListNode(6) { next = new ListNode(1) } };

            a1.next.next = c1;
            b1.next.next.next = c1;

            Console.WriteLine(GetIntersectionNode(a1, b1).val);

            // 2
            ListNode c2 = new ListNode(2) { next = new ListNode(4) };
            ListNode a2 = new ListNode(1) { next = new ListNode(9) { next = new ListNode(1) } };
            ListNode b2 = new ListNode(3);

            a2.next.next.next = c2;
            b2.next = c2;

            Console.WriteLine(GetIntersectionNode(a2, b2).val);

            // 3
            ListNode a3 = new ListNode(2) { next = new ListNode(6) { next = new ListNode(4) } };
            ListNode b3 = new ListNode(1) { next = new ListNode(5) };

            var result = GetIntersectionNode(a3, b3);

            Console.WriteLine(result == null ? "No intersection" : result.val.ToString());

        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            //nothing to see here, move along
            if (headA == null || headB == null) return null;

            // if they intersect the ends will match

            // find the count of each list
            var aCount = 1;
            var bCount = 1;

            // length of A
            var temp1 = headA;
            while (temp1 != null)
            {
                temp1 = temp1.next;
                aCount++;
            }

            // length of B
            var temp2 = headB;
            while (temp2 != null)
            {
                temp2 = temp2.next;
                bCount++;
            }

            // reset to start of each
            temp1 = headA;
            temp2 = headB;

            // move the pointer for the longer list to start at the same element of the shorter
            // in other owrds we can ignore the extra elements at the front of the longer list
            var diff = Math.Abs(aCount - bCount);

            if (aCount > bCount)
            {
                while (diff != 0)
                {
                    temp1 = temp1.next;
                    diff--;
                }
            }
            else if (aCount < bCount)
            {
                while (diff != 0)
                {
                    temp2 = temp2.next;
                    diff--;
                }
            }

            // both lists are now the same
            // compare each list element looking for an intercept
            while (temp1 != null && temp2 != null)
            {
                if (temp1 == temp2)
                {
                    return temp1;
                }
                // try the next element in each list
                temp1 = temp1.next;
                temp2 = temp2.next;
            }

            // no intersect
            return null;
        }
    }
}
