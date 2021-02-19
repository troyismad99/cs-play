using System;
using System.Collections.Generic;
/*

Given a number n, print all the prime numbers that are in the first n Fibonacci numbers.

Example Input:
    n = 6
Example Output:
    [2, 3, 5]
Explanation:
    The first 6 Fibonacci numbers are 1 1 2 3 5 8 but only 2, 3 and 5 are primes.

*/
namespace PrimeFibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(String.Join(",", PrimeFibonacci(6)));
            Console.WriteLine(String.Join(",", PrimeFibonacci(15)));

            Console.ReadKey();

        }

        public static long[] PrimeFibonacci(long n)
        {            
            List<long> result = new List<long>();

            // retrieve each fibonacci and check if it is prime
            for (int i = 1; i <= n; i++)
            {
                var fib = CalculateFibonacciTabulation(i);

                if (IsPrime(fib))
                {
                    result.Add(fib);
                }

            }

            return result.ToArray();
        }

        public static long CalculateFibonacciTabulation(long n)
        {
            if (n == 0) return n;
            long[] dp = new long[n + 1];

            // base case
            dp[0] = 0;
            dp[1] = 1;

            // build the rest
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        public static bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

    }
}
