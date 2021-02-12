using System;
/*
Given a non-negative integer num, return the number of steps to reduce it to zero.

If the current number is even, you have to divide it by 2,
otherwise, you have to subtract 1 from it.

Example 1:
Input: num = 14
Output: 6
Explanation: 
Step 1) 14 is even; divide by 2 and obtain 7. 
Step 2) 7 is odd; subtract 1 and obtain 6.
Step 3) 6 is even; divide by 2 and obtain 3. 
Step 4) 3 is odd; subtract 1 and obtain 2. 
Step 5) 2 is even; divide by 2 and obtain 1. 
Step 6) 1 is odd; subtract 1 and obtain 0.

Example 2:
Input: num = 8
Output: 4
Explanation: 
Step 1) 8 is even; divide by 2 and obtain 4. 
Step 2) 4 is even; divide by 2 and obtain 2. 
Step 3) 2 is even; divide by 2 and obtain 1. 
Step 4) 1 is odd; subtract 1 and obtain 0.

Example 3:
Input: num = 123
Output: 12

Constraints:
0 <= num <= 10^6
*/

/*
Runtime: 40 ms        Your runtime beats 70.21 % of csharp submissions.
Memory Usage: 15.2 MB Your memory usage beats 69.03 % of csharp submissions.
*/

namespace _1342_NumberOfStepsToReduceNumberToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(NumberOfSteps(14));
            Console.WriteLine(NumberOfSteps(8));
            Console.WriteLine(NumberOfSteps(123));
            Console.WriteLine(NumberOfSteps(99));

            Console.ReadKey();
        }

        public static int NumberOfSteps(int num)
        {
            int steps = 0;

            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                    steps++;
                }
                else
                {
                    num--;
                    steps++;
                }
            }

            return steps;
        }
    }
}
