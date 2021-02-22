using System;

/* Broken Calculator
 
On a broken calculator that has a number showing on its display, we can perform two operations:
    Double: Multiply the number on the display by 2, or;
    Decrement: Subtract 1 from the number on the display.

Initially, the calculator is displaying the number X.

Return the minimum number of operations needed to display the number Y.

Example 1:
    Input: X = 2, Y = 3
    Output: 2
    Explanation: Use double operation and then decrement operation {2 -> 4 -> 3}.

Example 2:
    Input: X = 5, Y = 8
    Output: 2
    Explanation: Use decrement and then double {5 -> 4 -> 8}.

Example 3:
    Input: X = 3, Y = 10
    Output: 3
    Explanation:  Use double, decrement and double {3 -> 6 -> 5 -> 10}.

Example 4:
    Input: X = 1024, Y = 1
    Output: 1023
    Explanation: Use decrement operations 1023 times.

Note:
    1 <= X <= 10^9
    1 <= Y <= 10^9

 */

/*
 * Runtime: 36 ms.     Your runtime beats 96.43 % of csharp submissions.
 * Memory Usage: 15 MB Your memory usage beats 85.71 % of csharp submissions.
 * */

namespace _0991_BrokenCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(BrokenCalc(2, 3));
            Console.WriteLine(BrokenCalc(5, 8));
            Console.WriteLine(BrokenCalc(3, 10));
            Console.WriteLine(BrokenCalc(1024, 1));

            Console.ReadKey();
        }

        public static int BrokenCalc(int X, int Y)
        {
            // if X is larger the only option is to decrement
            if (X >= Y)
            {
                // because we can only decrement by 1 each time ...
                // ... we need to decrement 'difference' times
                return X - Y;
            }

            // From leetcode problem page:
            /* Work Backwards

            Instead of multiplying by 2 or subtracting 1 from X, we could divide by 2 (when Y is even) or add 1 to Y.

            The motivation for this is that it turns out we always greedily divide by 2:

            If say Y is even, then if we perform 2 additions and one division,
            we could instead perform one division and one addition for less operations [(Y+2) / 2 vs Y/2 + 1].

            If say Y is odd, then if we perform 3 additions and one division,
            we could instead perform 1 addition, 1 division, and 1 addition for less operations [(Y+3) / 2 vs (Y+1) / 2 + 1].
            */

            if (Y % 2 == 1)
            {
                return BrokenCalc(X, Y + 1) + 1;
            }
            else
            {
                return BrokenCalc(X, Y / 2) + 1;
            }
        }


    }
}
