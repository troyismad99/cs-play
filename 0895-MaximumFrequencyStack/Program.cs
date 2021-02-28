using System;
using System.Collections.Generic;
/*
* Maximum Frequency Stack

Implement FreqStack, a class which simulates the operation of a stack-like data structure.
FreqStack has two functions:
    push(int x), which pushes an integer x onto the stack.
    pop(), which removes and returns the most frequent element in the stack.
        If there is a tie for most frequent element,
        the element closest to the top of the stack is removed and returned.



Example 1:
Input: 
["FreqStack","push","push","push","push","push","push","pop","pop","pop","pop"],
[[],[5],[7],[5],[7],[4],[5],[],[],[],[]]
Output: [null,null,null,null,null,null,null,5,7,5,4]
Explanation:
After making six .push operations, the stack is [5,7,5,7,4,5] from bottom to top.  Then:

pop() -> returns 5, as 5 is the most frequent.
The stack becomes [5,7,5,7,4].

pop() -> returns 7, as 5 and 7 is the most frequent, but 7 is closest to the top.
The stack becomes [5,7,5,4].

pop() -> returns 5.
The stack becomes [5,7,4].

pop() -> returns 4.
The stack becomes [5,7].

Note:
    Calls to FreqStack.push(int x) will be such that 0 <= x <= 10^9.
    It is guaranteed that FreqStack.pop() won't be called if the stack has zero elements.
    The total number of FreqStack.push calls will not exceed 10000 in a single test case.
    The total number of FreqStack.pop calls will not exceed 10000 in a single test case.
    The total number of FreqStack.push and FreqStack.pop calls will not exceed 150000 across all test cases.
*/

/*
 * Runtime: 344 ms       Your runtime beats 58.73 % of csharp submissions.
 * Memory Usage: 58.5 MB Your memory usage beats 61.90 % of csharp submissions.
 */

namespace _0895_MaximumFrequencyStack
{
    public class FreqStack
    {
        // keep track of the frequency of each stack entry
        // ex 5 occurs 3 times; 7 occurs twice; 4 occurs once
        private readonly Dictionary<int, int> freq;

        // keep track of the elements at each count
        // ex count = 1 has elements 5, 7, 4
        //    count = 2 has 5 and 7
        //    count = 3 has 5
        // NOTE: They are added in oushed order, important for the pop operation
        private readonly Dictionary<int, Stack<int>> groupMap;

        // the current max count (NOTE: not the value with that count)
        private int maxFreq;

        public FreqStack()
        {
            freq = new Dictionary<int, int>();
            groupMap = new Dictionary<int, Stack<int>>();
            maxFreq = 0;
        }

        public void Push(int x)
        {
            // add the value to our frequency counter
            if (freq.ContainsKey(x))
            {
                freq[x]++;
            }
            else
            {
                freq.Add(x, 1);
            }

            // check if it is the new max
            if (freq[x] > maxFreq)
            {
                maxFreq = freq[x];
            }

            // update our counter
            if (groupMap.ContainsKey(freq[x]))
            {
                groupMap[freq[x]].Push(x);
            }
            else
            {
                groupMap.Add(freq[x], new Stack<int>());
                groupMap[freq[x]].Push(x);
            }

        }

        public int Pop()
        {
            if (groupMap.ContainsKey(maxFreq))
            {
                // pop the last value added to our frequency counter
                // this is also the "closest to the top" for tied value
                int x = groupMap[maxFreq].Pop();

                // adjust our frequency counter
                freq[x]--;

                // check if its the last value with the current max
                if (groupMap[maxFreq].Count == 0)
                {
                    maxFreq--;
                }

                return x;
            }

            return -1;
        }
    }

    /**
     * Your FreqStack object will be instantiated and called as such:
     * FreqStack obj = new FreqStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     */


class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            FreqStack obj = new FreqStack();
            obj.Push(5);
            obj.Push(7);
            obj.Push(5);
            obj.Push(7);
            obj.Push(4);
            obj.Push(5);

            Console.WriteLine(obj.Pop());
            Console.WriteLine(obj.Pop());
            Console.WriteLine(obj.Pop());
            Console.WriteLine(obj.Pop());

        }
    }
}
