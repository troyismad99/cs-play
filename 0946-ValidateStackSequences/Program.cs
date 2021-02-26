using System;
/*
 * Validate Stack Sequences
Given two sequences pushed and popped with distinct values,
return true if and only if this could have been the result of
a sequence of push and pop operations on an initially empty stack.

Example 1:
    Input: pushed = [1,2,3,4,5], popped = [4,5,3,2,1]
    Output: true
    Explanation: We might do the following sequence:
    push(1), push(2), push(3), push(4), pop() -> 4,
    push(5), pop() -> 5, pop() -> 3, pop() -> 2, pop() -> 1

Example 2:
    Input: pushed = [1,2,3,4,5], popped = [4,3,5,1,2]
    Output: false
    Explanation: 1 cannot be popped before 2.

Constraints:
    0 <= pushed.length == popped.length <= 1000
    0 <= pushed[i], popped[i] < 1000
    pushed is a permutation of popped.
    pushed and popped have distinct values.

 */

/*
 * Runtime: 92 ms         Your runtime beats 91.03 % of csharp submissions.
 * Memory Usage: 27.1 MB  Your memory usage beats 73.08 % of csharp submissions.
 */

namespace _0946_ValidateStackSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           
            Console.WriteLine(ValidateStackSequences(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5, 3, 2, 1 }));
            Console.WriteLine(ValidateStackSequences(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 3, 5, 1, 2 }));

            Console.WriteLine(ValidateStackSequences(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }));

            Console.WriteLine(ValidateStackSequences(new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 3 }));
            Console.WriteLine(ValidateStackSequences(null, null));


        }

        static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            // some guard clauses even though the constraints cover these cases
            if ((pushed == null) || (popped == null)) return false;
            if (pushed.Length != popped.Length) return false;

            // easy case 
            if (pushed.Length == 0) return true;

            /* Two approaches:
                 Two pointers - iterate both arrays at once, but will change pushed as we go to indicate a pop
                 Simulation - Create a new stack and simulate push and pop operators to match

            Time  -> O(N) Both approaches iterate all the elements
            Space -> Two pointers O(1) - no extra space needed.
                     Simulation: O(N) - an extra stack is created.               
            */

// Two pointers.
int i = 0;
            int ii = 0;

            while ((i >= 0) && (ii >= 0) && (i < pushed.Length) && (ii < popped.Length))
            {
                // check what is at each pointer
                if (pushed[i] != popped[ii])
                {
                    // not equal so move along our push
                    i++;
                }
                else
                {
                    // mark the pushed as popped (constraint: 0 <= pushed[i])
                    pushed[i] = -1;

                    // back up our pushed pointer to the last value not popped
                    while (i > 0 && pushed[i] == -1) i--;

                    // next popped
                    ii++;
                }
            }

            // make sure all values have been popped
            return (i == 0);
        }
    }
}
