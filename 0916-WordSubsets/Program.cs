using System;
using System.Collections.Generic;
/*
* Word Subsets
* 
* We are given two arrays A and B of words.
* Each word is a string of lowercase letters.
* 
* Now, say that word b is a subset of word a if every letter in b occurs in a, 
* including multiplicity.
* For example, "wrr" is a subset of "warrior", but is not a subset of "world".
* 
* Now say a word a from A is universal if for every b in B, b is a subset of a. 
* 
* Return a list of all universal words in A.
* You can return the words in any order.
* 
* Example 1:
* Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["e","o"]
* Output: ["facebook","google","leetcode"]
* 
* Example 2:
* Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["l","e"]
* Output: ["apple","google","leetcode"]
* 
* Example 3:
* Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["e","oo"]
* Output: ["facebook","google"]
* 
* Example 4:
* Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["lo","eo"]
* Output: ["google","leetcode"]
* 
* Example 5:
* Input: A = ["amazon","apple","facebook","google","leetcode"], B = ["ec","oc","ceo"]
* Output: ["facebook","leetcode"]
* 
* Note:
*  1 <= A.length, B.length <= 10000
*  1 <= A[i].length, B[i].length <= 10
*  A[i] and B[i] consist only of lowercase letters.
*  All words in A[i] are unique: there isn't i != j with A[i] == A[j].
*   
*/
/*
 * Runtime: 364 ms       Your runtime beats 45.00 % of csharp submissions.
 * Memory Usage: 49.1 MB Your memory usage beats 50.00 % of csharp submissions.
 */
namespace _0916_WordSubsets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var wordlist = new[] { "amazon", "apple", "facebook", "google", "leetcode" };

            var r1 = WordSubsets(wordlist, new string[] { "e", "o" });
            var r2 = WordSubsets(wordlist, new string[] { "l", "e" });
            var r3 = WordSubsets(wordlist, new string[] { "e", "oo" });
            var r4 = WordSubsets(wordlist, new string[] { "lo", "eo" });
            var r5 = WordSubsets(wordlist, new string[] { "ec", "oc", "ceo" });

            Console.WriteLine(string.Join(',', r1));
            Console.WriteLine(string.Join(',', r2));
            Console.WriteLine(string.Join(',', r3));
            Console.WriteLine(string.Join(',', r4));
            Console.WriteLine(string.Join(',', r5));

            wordlist[4] = "zillow";
            var r6 = WordSubsets(wordlist, new string[] { "o", "z" });
            Console.WriteLine(string.Join(',', r6));

        }

        static IList<string> WordSubsets(string[] A, string[] B)
        {
            var result = new List<string>();

            // will hold the max frequency of each letter
            // across all the B words
            var bFrequency = new int[26];

            foreach (var word in B)
            {
                var wordFrequency = CharacterCounter(word);

                // check if these counts are greater than a previous B word
                for (int i = 0; i < 26; i++)
                {
                    bFrequency[i] = Math.Max(bFrequency[i], wordFrequency[i]);
                }

            }

            // check the letter frequency of each candidate word from A
            // against the required character counts from the B words
            foreach (var word in A)
            {
                var wordFrequency = CharacterCounter(word);

                for (int i = 0; i < 26; i++)
                {
                    if (wordFrequency[i] < bFrequency[i])
                    {
                        break;
                    }
                    else if (i == 25)
                    {
                        // we made it through all the letters
                        result.Add(word);
                    }
                }

            }
          
            return result;
        }

        // count the char occurences in a string
        static int[] CharacterCounter(string word)
        {
            var result = new int[26];

            foreach (var c in word)
            {
                result[c - 'a']++;
            }
            return result;
        }
    }
}
