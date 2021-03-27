using System;
/*
 * Palindromic Substrings
 * 
 * Given a string, your task is to count how many palindromic substrings in this string.
 * 
 * The substrings with different start indexes or end indexes are counted as 
 * different substrings even they consist of same characters.
 * 
 * Example 1:
 * Input: "abc"
 * Output: 3
 * Explanation: Three palindromic strings: "a", "b", "c".
 * 
 * Example 2:
 * Input: "aaa"
 * Output: 6
 * Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
 * 
 * Note:
 *     The input string length won't exceed 1000.
 *     
 */
/*
 * Runtime: 76 ms        Your runtime beats 73.55 % of csharp submissions.
 * Memory Usage: 22.7 MB Your memory usage beats 74.84 % of csharp submissions.
 */
namespace _0647_PalindromicSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(CountSubstrings("abc"));
            Console.WriteLine(CountSubstrings("aaa"));

            Console.WriteLine(CountSubstrings(""));
            Console.WriteLine(CountSubstrings("a"));
            Console.WriteLine(CountSubstrings("1234567890"));
            Console.WriteLine(CountSubstrings("12343"));

        }

        static int CountSubstrings(string s)
        {
            // guard for short input
            if (s.Length <= 1) return s.Length;

            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // first count the odd character length strings (1, 3, 5...)
                result += CountPalidrome(i, i, s);

                // second is the even length strings (2, 4, 6 ...)
                result += CountPalidrome(i, i + 1, s);
            }

            return result;
        }

        private static int CountPalidrome(int left, int right, string s)
        {
            /*
             * A double pointer to grow our candidate by one in each direction.
             * The if and while could be combined into one statement, 
             * but I think it reads better to have them separated.
             */

            int theCount = 0;

            // check that the pointers are still in the bounds of the string
            while (( left >= 0 ) && (right < s.Length))
            {
                // must match to stay a palidrome
                if (s[left] == s[right])
                {
                    theCount++;
                    left--;
                    right++;
                }
                else
                {
                    break;
                }
            }

            return theCount;
        }
    }
}
