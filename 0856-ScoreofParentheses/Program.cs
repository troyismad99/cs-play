using System;
using System.Collections.Generic;
/*
* Score of Parentheses

Given a balanced parentheses string S, compute the score of the string based on the following rule:
() has score 1
AB has score A + B, where A and B are balanced parentheses strings.
(A) has score 2 * A, where A is a balanced parentheses string.

Example 1:
Input: "()"
Output: 1

Example 2:
Input: "(())"
Output: 2

Example 3:
Input: "()()"
Output: 2

Example 4:
Input: "(()(()))"
Output: 6

Note:
S is a balanced parentheses string, containing only ( and ).
2 <= S.length <= 50
*/

/*
 * Runtime: 72 ms        Your runtime beats 73.53 % of csharp submissions.
 * Memory Usage: 22.6 MB Your memory usage beats 58.82 % of csharp submissions.
 */
namespace _0856_ScoreofParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(ScoreOfParentheses("()"));
            Console.WriteLine(ScoreOfParentheses("(())"));
            Console.WriteLine(ScoreOfParentheses("()()"));
            Console.WriteLine(ScoreOfParentheses("(()(()))"));

            Console.WriteLine(ScoreOfParentheses(null));
            Console.WriteLine(ScoreOfParentheses(""));

            Console.WriteLine(ScoreOfParentheses("((()(())))"));
            Console.WriteLine(ScoreOfParentheses("(()(()))()"));

            Console.ReadKey();
        }

        public static int ScoreOfParentheses(string S)
        {
            // guard against missing input
            if (String.IsNullOrEmpty(S)) return 0;

            int score = 0;

            // seems like there a lot of these bracket problems
            // a stack seems like the most readable solution
            var stack = new Stack<int>();

            foreach (char c in S)
            {
                if (c == '(')
                {
                    // push the current score
                    stack.Push(score);

                    // start as new balanced set
                    score = 0;
                }
                else // a close
                {
                    // get the last score and double
                    var lastScore = stack.Pop();

                    if (score == 0)
                    {
                        // currently at 0 indicates a () which counts as 1
                        score = lastScore + 1;
                    }
                    else
                    {
                        // we are inside a balanced set so the score is doubled
                        score = lastScore + (score * 2);
                    }
                }
            }

            return score;
        }
    }
}
