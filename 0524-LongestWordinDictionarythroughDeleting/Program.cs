using System;
using System.Collections.Generic;
using System.Linq;
/* 
* Longest Word in Dictionary through Deleting
* 

Given a string and a string dictionary,
find the longest string in the dictionary that can be formed by deleting some characters of the given string.

If there are more than one possible results,
return the longest word with the smallest lexicographical order.
If there is no possible result, return the empty string.

Example 1:
Input:
s = "abpcplea", d = ["ale","apple","monkey","plea"]
Output: 
"apple"

Example 2:
Input:
s = "abpcplea", d = ["a","b","c"]
Output: 
"a"

Note:
All the strings in the input will only contain lower-case letters.
The size of the dictionary won't exceed 1,000.
The length of all the strings in the input won't exceed 1,000.
*/

/*
 * Runtime: 144 ms       Your runtime beats 45.83 % of csharp submissions.
 * Memory Usage: 36.7 MB Your memory usage beats 31.25 % of csharp submissions.
 */


namespace _0524_LongestWordinDictionarythroughDeleting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(FindLongestWord("abpcplea", new List<string> { "ale", "apple", "monkey", "plea", "back" }));
            Console.WriteLine(FindLongestWord("abpcplea", new List<string> { "a", "b", "c" }));

            Console.WriteLine(FindLongestWord("abc", new List<string> { "zoom", "zip" }));

            Console.WriteLine(FindLongestWord("abpcplea", new List<string>() ));
            Console.WriteLine(FindLongestWord("", new List<string> { "zoom", "zip" }));

            Console.WriteLine(FindLongestWord(null, new List<string> { "zoom", "zip" }));
            Console.WriteLine(FindLongestWord("", null));

            Console.ReadKey();
        }

        public static string FindLongestWord(string s, IList<string> d)
        {
            // guard against missing inputs
            if ((s == null) || (d == null) || (s.Length == 0) || (d.Count == 0)) return string.Empty;

            var sLength = s.Length;

            // order our dictionary by word length and then alphabetical
            // remove any candiadates that are too long
            var dictionary = d.OrderByDescending(x => x.Length)
                              .ThenBy(x => x).ToList()
                              .Where(x => x.Length <= s.Length);

            // check each word
            foreach (var word in dictionary)
            {
                // one pointer for each word
                int i = 0;
                int ii = 0;

                while ((i < s.Length) && (ii < word.Length))
                {
                    if (s[i] == word[ii])
                    {
                        // we have found a letter so move to the next letter
                        i++;
                        ii++;
                    }
                    else
                    {
                        i++;
                    }
                }

                // check for a match
                if (ii == word.Length) return word;

            }

            return string.Empty;
        }

    }
}
