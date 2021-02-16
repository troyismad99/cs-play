using System;
using System.Text;

/*
Given two strings s and t , write a function to determine if t is an anagram of s.

Example 1:
Input: s = "anagram", t = "nagaram"
Output: true

Example 2:
Input: s = "rat", t = "car"
Output: false

Note:
You may assume the string contains only lowercase alphabets.

Follow up:
What if the inputs contain unicode characters? How would you adapt your solution to such case?
*/

/*
    Runtime: 60 ms, faster than 99.90% of C# online submissions for Valid Anagram.
    Memory Usage: 24.6 MB, less than 36.51% of C# online submissions for Valid Anagram.
*/
namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(IsAnagram("anagram", "nagaram").ToString());
            Console.WriteLine(IsAnagram("rat", "car").ToString());
            Console.WriteLine(IsAnagram("a", "b").ToString());
            Console.WriteLine(IsAnagram("a", "bc").ToString());

            Console.ReadKey();
        }

        private static bool IsAnagram(string s, string t)
        {
            // both strings must be the same length
            if (s.Length != t.Length) return false;

            // array of the lower case characters
            var letters = new int[26];

            // convert the strings to arrays
            byte[] sb = Encoding.ASCII.GetBytes(s);
            byte[] tb = Encoding.ASCII.GetBytes(t);

            // loop through the strings, note that the lengths are the same
            // note the lowercase a is ascii 97
            for (int i = 0; i < sb.Length; i++)
            {
                // add one for every letter in s
                letters[sb[i] - 97]++;

                // subtract one for every letter in t
                letters[tb[i] - 97]--;
            }

            // check that each letter count is now zero
            foreach (var i in letters)
            {
                if (i != 0)
                    return false;
            }

            // fin
            return true;
        }
    }
}
