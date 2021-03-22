﻿using System;
using System.Collections.Generic;
using System.Linq;
/*
* Vowel Spellchecker
* 
* Given a wordlist, we want to implement a spellchecker that converts a query word into a correct word.
* 
* For a given query word, the spell checker handles two categories of spelling mistakes:
* Capitalization: If the query matches a word in the wordlist (case-insensitive), 
* then the query word is returned with the same case as the case in the wordlist.
*  Example: wordlist = ["yellow"], query = "YellOw": correct = "yellow"
*  Example: wordlist = ["Yellow"], query = "yellow": correct = "Yellow"
*  Example: wordlist = ["yellow"], query = "yellow": correct = "yellow"
* Vowel Errors: If after replacing the vowels ('a', 'e', 'i', 'o', 'u') of the query word with any vowel individually, 
* it matches a word in the wordlist (case-insensitive), then the query word is returned with the same case as the match in the wordlist.
*  Example: wordlist = ["YellOw"], query = "yollow": correct = "YellOw"
*  Example: wordlist = ["YellOw"], query = "yeellow": correct = "" (no match)
*  Example: wordlist = ["YellOw"], query = "yllw": correct = "" (no match)
*  
* In addition, the spell checker operates under the following precedence rules:
*  When the query exactly matches a word in the wordlist (case-sensitive), you should return the same word back.
*  When the query matches a word up to capitlization, you should return the first such match in the wordlist.
*  When the query matches a word up to vowel errors, you should return the first such match in the wordlist.
*  If the query has no matches in the wordlist, you should return the empty string.
*  Given some queries, return a list of words answer, where answer[i] is the correct word for query = queries[i].
*  
* Example 1:
* Input: wordlist = ["KiTe","kite","hare","Hare"], 
*        queries = ["kite","Kite","KiTe","Hare","HARE","Hear","hear","keti","keet","keto"]
* Output: ["kite","KiTe","KiTe","Hare","hare","","","KiTe","","KiTe"]
* 
* Note:
* 1 <= wordlist.length <= 5000
* 1 <= queries.length <= 5000
* 1 <= wordlist[i].length <= 7
* 1 <= queries[i].length <= 7
* All strings in wordlist and queries consist only of english letters.
* 
*/
/*
 * Runtime: 324 ms
 * Memory Usage: 46.3 MB
 */
namespace _0966_VowelSpellchecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var w = new string[] { "KiTe", "kite", "hare", "Hare" };
            var q = new string[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" };

            var r = Spellchecker(w, q);

            Console.WriteLine(string.Join(' ', r));
                        

        }

        static string[] Spellchecker(string[] wordlist, string[] queries)
        {
            // store the valid forms of the words
            List<string> words = new(wordlist);
            Dictionary<string, string> lowerCase = new();
            Dictionary<string, string> vowels = new();

            string vowelChars = "aeiou";

            foreach (var word in wordlist)
            {
                var lower = word.ToLower();
                var noVowel = new string(lower.Select(c => vowelChars.Contains(c) ? '*' : c).ToArray());

                lowerCase.TryAdd(lower, word);
                vowels.TryAdd(noVowel, word);
            }

            // check each query
            for (int i = 0; i < queries.Length; i++)
            {
                // When the query exactly matches a word in the wordlist (case-sensitive), you should return the same word back.
                if (words.Contains(queries[i]))
                {
                    continue;
                }

                var lower = queries[i].ToLower();                
                var noVowel = new string(lower.Select(c => vowelChars.Contains(c) ? '*' : c).ToArray());

                // When the query matches a word up to capitlization, you should return the first such match in the wordlist.
                if (lowerCase.ContainsKey(lower))
                {
                    queries[i] = lowerCase[lower];
                }

                // When the query matches a word up to vowel errors, you should return the first such match in the wordlist.
                else if (vowels.ContainsKey(noVowel))
                {
                    queries[i] = vowels[noVowel];
                }

                // If the query has no matches in the wordlist, you should return the empty string.
                else
                {
                    queries[i] = string.Empty;
                }

            }

            return queries;
        }
    }
}
