using System;
using System.Collections.Generic;
/*
Given a string S, we can transform every letter individually to be lowercase or uppercase to create another string.

Return a list of all possible strings we could create. You can return the output in any order.

Example 1:
Input: S = "a1b2"
Output: ["a1b2","a1B2","A1b2","A1B2"]

Example 2:
Input: S = "3z4"
Output: ["3z4","3Z4"]

Example 3:
Input: S = "12345"
Output: ["12345"]

Example 4:
Input: S = "0"
Output: ["0"]

Constraints:
S will be a string with length between 1 and 12.
S will consist only of letters or digits.
*/

/*
 * Runtime: 252 ms       Your runtime beats 75.27 % of csharp submissions.
 * Memory Usage: 35.4 MB Your memory usage beats 26.88 % of csharp submissions.
 */




namespace _0784_LetterCasePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(String.Join(",", LetterCasePermutation("a1b2")));
            Console.WriteLine(String.Join(",", LetterCasePermutation("3z4")));
            Console.WriteLine(String.Join(",", LetterCasePermutation("12345")));
            Console.WriteLine(String.Join(",", LetterCasePermutation("0")));

            Console.ReadKey();
        }

        public static IList<string> LetterCasePermutation(string S)
        {
            var result = new List<string>();

            // the Char data type has lots of helpers we can take advantage of
            DFS(S.ToCharArray(), 0, result);
            return result;
        }

        public static void DFS (char[] chars, int currentChar, List<string> result)
        {
            // have we reach the end and created a new string?
            if (currentChar == chars.Length)
            {
                result.Add(new string(chars));
            }
            else
            {
                // it its a digit just move on
                if(Char.IsDigit(chars[currentChar]))
                {
                    DFS(chars, currentChar + 1, result);
                }
                else
                {
                    // not a digit so process both states
                    chars[currentChar] = Char.ToUpper(chars[currentChar]);
                    DFS(chars, currentChar + 1, result);

                    chars[currentChar] = Char.ToLower(chars[currentChar]);
                    DFS(chars, currentChar + 1, result);
                }
            }
        }
    }
}
