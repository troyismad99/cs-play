using System;
/*
 * Reverse Integer
 * 
 * Given a signed 32-bit integer x, return x with its digits reversed. 
 * If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.
 * 
 * Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
 * 
 * Example 1:
 *      Input: x = 123
 *      Output: 321
 * 
 * Example 2:
 *      Input: x = -123
 *      Output: -321
 * 
 * Example 3:
 *      Input: x = 120
 *      Output: 21
 *    
 * Example 4:
 *      Input: x = 0
 *      Output: 0
 *
 * Constraints:
 *  -2^31 <= x <= 2^31 - 1
 *  
 */
/* 
 * Runtime: 40 ms, faster than 84.91% of C# online submissions for Reverse Integer.
 * Memory Usage: 15.5 MB, less than 32.81% of C# online submissions for Reverse Integer.
 */

namespace _0007_ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(Reverse(123));
            Console.WriteLine(Reverse(-321));
            Console.WriteLine(Reverse(120));
            Console.WriteLine(Reverse(0));

            Console.WriteLine(Reverse(-2147483648));

        }

        public static int Reverse(int x)
        {
            var result = 0;

            while (x != 0 )
            {
                // grab the ones digit
                int tail = x % 10;

                // shift result and add the one
                int stepResult = result * 10 + tail;

                // check for an overflow here by reversing the process               
                if ( (stepResult - tail) / 10 != result )
                {
                    return 0;
                }

                // toss the current ones digit
                result = stepResult;
                x /= 10;
            }

            return result;
        }
    }
}
