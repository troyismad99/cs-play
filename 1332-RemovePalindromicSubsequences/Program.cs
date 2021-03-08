﻿using System;
using System.Linq;
/* Remove Palindromic Subsequences

Given a string s consisting only of letters 'a' and 'b'. In a single step you can remove one palindromic subsequence from s.
Return the minimum number of steps to make the given string empty.
A string is a subsequence of a given string, if it is generated by deleting some characters of a given string without changing its order.
A string is called palindrome if is one that reads the same backward as well as forward.

Example 1:
Input: s = "ababa"
Output: 1
Explanation: String is already palindrome

Example 2:
Input: s = "abb"
Output: 2
Explanation: "abb" -> "bb" -> "". 
Remove palindromic subsequence "a" then "bb".

Example 3:
Input: s = "baabb"
Output: 2
Explanation: "baabb" -> "b" -> "". 
Remove palindromic subsequence "baab" then "b".

Example 4:
Input: s = ""
Output: 0

Constraints:
0 <= s.length <= 1000
s only consists of letters 'a' and 'b'
*/

/*
 * Runtime: 76 ms        Your runtime beats 39.53 % of csharp submissions.
 * Memory Usage: 22.3 MB Your memory usage beats 83.72 % of csharp submissions
 */

namespace _1332_RemovePalindromicSubsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(RemovePalindromeSub("ababa"));
            Console.WriteLine(RemovePalindromeSub("abb"));
            Console.WriteLine(RemovePalindromeSub("baabb"));
            Console.WriteLine(RemovePalindromeSub(""));

            Console.WriteLine(RemovePalindromeSub("aaaabbbb"));

        }

        public static int RemovePalindromeSub(string s)
        {
            if (s.Length == 0)
                return 0;

            // we do not have to remove the palindrome in order from the string
            // subsequence not a substring
            // so worst case we will need to remove two palidrons:
            // one with all the letter a's
            // a second with all the letter b's

            // if the string is already a palindrome return 1

            int i = 0;
            int ii = s.Length - 1;

            while (i < ii)
            {
                if (s[i] == s[ii])
                {
                    i++;
                    ii--;
                }
                else
                {
                    // not a palidrone
                    return 2;
                }
            }

            // we are a palidrone
            return 1;

        }
    }
}
