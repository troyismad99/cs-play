using System;
using System.Collections.Generic;
using System.Linq;
/*
* Reordered Power of 2
* 
* Starting with a positive integer N, we reorder the digits in any order (including the original order) 
* such that the leading digit is not zero.
* 
* Return true if and only if we can do this in a way such that the resulting number is a power of 2.
* 
* Example 1:
* Input: 1
* Output: true
* 
* Example 2:
* Input: 10
* Output: false
* 
* Example 3:
* Input: 16
* Output: true
* 
* Example 4:
* Input: 24
* Output: false
* 
* Example 5:
* Input: 46
* Output: true
* 
* Note:
* 1 <= N <= 10^9
* 
*/
/*
 * Runtime: 48 ms        Your runtime beats 50.00 % of csharp submissions.
 * Memory Usage: 20.3 MB
 */
namespace _0869_ReorderedPowerof2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(ReorderedPowerOf2(1));
            Console.WriteLine(ReorderedPowerOf2(10));
            Console.WriteLine(ReorderedPowerOf2(16));
            Console.WriteLine(ReorderedPowerOf2(24));
            Console.WriteLine(ReorderedPowerOf2(46));
        }

        public static bool ReorderedPowerOf2(int N)
        {
            var pows = new HashSet<string>();

            // only 31 of these, could maybe hard code them for more speed
            for (var i = 1; 0 < i && i < int.MaxValue; i *= 2)
            {
                pows.Add(Ordered(i));
            }

            return pows.Contains(Ordered(N));        
        }

        static string Ordered(int n)
        {
            return new(n.ToString().ToCharArray().OrderBy(c => c).ToArray());
        }

    }
}
