using System;
using System.Collections.Generic;
/*
Given a string s, find the length of the longest substring without repeating characters.

Example 1:
    Input: s = "abcabcbb"
    Output: 3
    Explanation: The answer is "abc", with the length of 3.

Example 2:
    Input: s = "bbbbb"
    Output: 1
    Explanation: The answer is "b", with the length of 1.

Example 3:
    Input: s = "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3.
    Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Example 4:
    Input: s = "" 
    Output: 0
 
Constraints:
    0 <= s.length <= 5 * 104
    s consists of English letters, digits, symbols and spaces.
 */
namespace _0003_LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine(LengthOfLongestSubstring("bbbbb"));
            Console.WriteLine(LengthOfLongestSubstring("pwwkew"));
            Console.WriteLine(LengthOfLongestSubstring(""));

            Console.WriteLine(LengthOfLongestSubstring("aaaaab"));
            Console.WriteLine(LengthOfLongestSubstring("aaaaabcc"));
            Console.WriteLine(LengthOfLongestSubstring(""));

            Console.ReadKey();

        }

        public static int LengthOfLongestSubstring(string s)
        {
            
            Dictionary<char, int> letters = new Dictionary<char, int>();

            int length = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // Do we already have this value?
                if (letters.TryGetValue(s[i], out int ii))
                {
                    // check our length, reset our iterator, and start a new string
                    length = Math.Max(length, letters.Count);
                    i = ii;
                    letters.Clear();
                }
                else
                {
                    // save the location of each letter
                    letters.Add(s[i], i);
                }
            }

            // check our previous longest vs the last string
            return Math.Max(length, letters.Count);
        }


    }
}
