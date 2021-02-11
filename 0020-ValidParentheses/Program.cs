using System;
using System.Collections.Generic;
/*
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:
Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.

Example 1:
Input: s = "()"
Output: true

Example 2:
Input: s = "()[]{}"
Output: true

Example 3:
Input: s = "(]"
Output: false

Example 4:
Input: s = "([)]"
Output: false

Example 5:
Input: s = "{[]}"
Output: true

Constraints:
1 <= s.length <= 104
s consists of parentheses only '()[]{}'.

Hint 1:
An interesting property about a valid parenthesis expression is that a sub-expression of a valid expression should also be a valid expression. (Not every sub-expression) e.g.

{ { } [ ] [ [ [ ] ] ] } is VALID expression
[ [ [ ] ] ]    is VALID sub-expression
{ } [ ]                is VALID sub-expression

Can we exploit this recursive structure somehow?

Hint 2:
What if whenever we encounter a matching pair of parenthesis in the expression, we simply remove it from the expression? This would keep on shortening the expression. e.g.

{ { ( { } ) } }
|_|

{ { (      ) } }
|______|

{ {          } }
|__________|

{                }
|________________|

VALID EXPRESSION!

Hint 3:
The stack data structure can come in handy here in representing this recursive structure of the problem. We can't really process this from the inside out because we don't have an idea about the overall structure. But, the stack can help us process this recursively i.e. from outside to inwards.
*/

/*
 Runtime: 72 ms, faster than 81.88% of C# online submissions for Valid Parentheses.
 Memory Usage: 22.5 MB, less than 78.60% of C# online submissions for Valid Parentheses.
 */

namespace _0020_ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(IsValid("()"));
            Console.WriteLine(IsValid("()[]{}"));
            Console.WriteLine(IsValid("(]"));
            Console.WriteLine(IsValid("([)]"));
            Console.WriteLine(IsValid("{[]}"));

            Console.WriteLine(IsValid("("));
            Console.WriteLine(IsValid("([)"));
            Console.WriteLine(IsValid("]"));

            Console.WriteLine(IsValid("{{}[][[[]]]}"));
            Console.WriteLine(IsValid("{{({})}}"));

            Console.ReadKey();
        }

        public static bool IsValid(string s)
        {
            // string must be even length
            if (s.Length % 2 != 0) return false;

            // the valid sets
            var validSets = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' } };

            var stack = new Stack<char>();

            foreach (char bracket in s)
            {
                // any open brackets go onto the stack
                if (validSets.ContainsKey(bracket))
                {
                    stack.Push(bracket);
                }
                else
                {
                    // if we have a close and nothing is on the stack we are done
                    if (stack.Count == 0) return false;

                    // if it doesn't match we are done
                    var lastOpen = stack.Pop();
                    if (validSets[lastOpen] != bracket) return false;

                }
            }

            return stack.Count == 0;
        }


    }
}
