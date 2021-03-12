using System;
using System.Collections.Generic;
/*
*  Check If a String Contains All Binary Codes of Size K
*  
*  Given a binary string s and an integer k.
*  Return True if every binary code of length k is a substring of s. Otherwise, return False.
*  
*  Example 1:
*      Input: s = "00110110", k = 2
*      Output: true
*      Explanation: The binary codes of length 2 are "00", "01", "10" and "11". 
*      They can be all found as substrings at indicies 0, 1, 3 and 2 respectively.
*      
*  Example 2:
*      Input: s = "00110", k = 2
*      Output: true
*      
*  Example 3:
*      Input: s = "0110", k = 1
*      Output: true
*      Explanation: The binary codes of length 1 are "0" and "1", it is clear that both exist as a substring. 
*      
*  Example 4:
*      Input: s = "0110", k = 2
*      Output: false
*      Explanation: The binary code "00" is of length 2 and doesn't exist in the array.
*      
*  Example 5:
*      Input: s = "0000000001011100", k = 4
*      Output: false
*      
*  Constraints:
*      1 <= s.length <= 5 * 10^5
*      s consists of 0's and 1's only.
*      1 <= k <= 20
*/

/*
 * Runtime: 368 ms       Your runtime beats 76.19 % of csharp submissions.
 * Memory Usage: 46.9 MB Your memory usage beats 47.62 % of csharp submissions.
 */

namespace _1461_CheckIfaStringContainsAllBinaryCodesofSizeK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(HasAllCodes("00110110", 2));
            Console.WriteLine(HasAllCodes("00110", 2));
            Console.WriteLine(HasAllCodes("0110", 1));
            Console.WriteLine(HasAllCodes("0110", 2));
            Console.WriteLine(HasAllCodes("0000000001011100", 4));

            Console.WriteLine(HasAllCodes("0000000001011100", 2));
            Console.WriteLine(HasAllCodes("1100001001101011101111", 4));
           
        }

        static bool HasAllCodes(string s, int k)
        {
            // guard against a short string
            if (s.Length < k) return false;

            /*
             * We will grab every string of length k from s and track the 
             * unique ones found. We can exit once have found the required count 
             */

            // how many strings do we need?
            int binaryCodeCount = 1 << k;

            // keep track of our string results
            var foundHash = new HashSet<string>();

            for (int i = 0; i <= s.Length - k; i++)
            {
                // extract the next string
                var candidate = s.Substring(i, k);

                // do we have this one?
                if (!foundHash.Contains(candidate))
                {
                    // add the new found string
                    foundHash.Add(candidate);
                    binaryCodeCount--;

                    // are we there yet?
                    if (binaryCodeCount == 0)
                    {
                        return true;
                    }
                }
            }

            //foreach (var item in foundHash)
            //{
            //    Console.WriteLine(item);
            //}

            return false;
        }
    }
}
