using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
* 1249
* Minimum Remove to Make Valid Parentheses
*
*
Given a string s of '(' , ')' and lowercase English characters. 

Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions )
so that the resulting parentheses string is valid and return any valid string.

Formally, a parentheses string is valid if and only if:
It is the empty string, contains only lowercase characters, or
It can be written as AB (A concatenated with B), where A and B are valid strings, or
It can be written as (A), where A is a valid string.

Example 1:
Input: s = "lee(t(c)o)de)"
Output: "lee(t(c)o)de"
Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.

Example 2:
Input: s = "a)b(c)d"
Output: "ab(c)d"

Example 3:
Input: s = "))(("
Output: ""
Explanation: An empty string is also valid.

Example 4:
Input: s = "(a(b(c)d)"
Output: "a(b(c)d)"

Constraints:
1 <= s.length <= 10^5
s[i] is one of  '(' , ')' and lowercase English letters.
*/

/*
 * Runtime: 100 ms       Your runtime beats 74.88 % of csharp submissions.
 * Memory Usage: 35.2 MB Your memory usage beats 30.73 % of csharp submissions.
 */


namespace _1249_MinimumRemovetoMakeValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(MinRemoveToMakeValid("lee(t(c)o)de)"));
            Console.WriteLine(MinRemoveToMakeValid("a)b(c)d"));
            Console.WriteLine(MinRemoveToMakeValid("))(("));
            Console.WriteLine(MinRemoveToMakeValid("(a(b(c)d)"));

            Console.WriteLine(MinRemoveToMakeValid("abc"));
            Console.WriteLine(MinRemoveToMakeValid("a(b)c"));
            Console.WriteLine(MinRemoveToMakeValid("()"));
            Console.WriteLine(MinRemoveToMakeValid(")"));
            Console.WriteLine(MinRemoveToMakeValid("("));

            Console.ReadKey();
        }

        public static string MinRemoveToMakeValid(string s)
        {
            var result = new StringBuilder();

            // a stack with the position of the opens
            var openLocation = new Stack<int>();
            int i = 0;

            foreach (char c in s)
            {
                if (c == '(')
                {
                    openLocation.Push(i++);
                    result.Append(c);
                }
                else if (c == ')')
                {
                    // make sure we have an open for this close
                    if (openLocation.Count != 0)
                    {
                        openLocation.Pop();
                        result.Append(c);
                        i++;
                    }
                }
                else
                {
                    result.Append(c);
                    i++;
                }
            }

            // clean up any extra opens
            while (openLocation.Any())
            {
                var openPosition = openLocation.Pop();
                result.Remove(openPosition, 1);
            }

            return result.ToString();
        }
    }
}
