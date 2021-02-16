using System;
using System.Diagnostics;
/*
* https://www.educative.io/courses/grokking-dynamic-programming-patterns-for-coding-interviews/m2G1pAq0OO0
*/

/*

Dynamic Programming 

Dynamic Programming (DP) is an algorithmic technique for solving an optimization problem
  by breaking it down into simpler subproblems and utilizing the fact that
  the optimal solution to the overall problem depends upon the optimal solution to its subproblems.

Let’s take the example of the Fibonacci numbers.
As we all know, Fibonacci numbers are a series of numbers in which each number is the sum of the two preceding numbers.
The first few Fibonacci numbers are 0, 1, 1, 2, 3, 5, and 8, and they continue on from there.

If we are asked to calculate the nth Fibonacci number, we can do that with the following equation,

'''
Fib(n) = Fib(n-1) + Fib(n-2), for n > 1
'''

As we can clearly see here, to solve the overall problem (i.e. Fib(n)),
we broke it down into two smaller subproblems (which are Fib(n-1) and Fib(n-2)).
This shows that we can use DP to solve this problem.

Characteristics of Dynamic Programming

Before moving on to understand different methods of solving a DP problem,
let’s first take a look at what are the characteristics of a problem that tells us that we can apply DP to solve it.

1. Overlapping Subproblems

Subproblems are smaller versions of the original problem. Any problem has overlapping sub-problems
if finding its solution involves solving the same subproblem multiple times.

Take the example of the Fibonacci numbers; to find the fib(4), we need to break it down into the following sub-problems:

             fib(4)
            /     \
       fib(3)     fib(2)
       /   \      /    \
  fib(2) fib(1) fib(1) fib(0)
  /    \
fib(0) fib(1)


We can clearly see the overlapping subproblem pattern here:
- fib(2) has been evaluated twice
- fib(1) has been evaluated three times.


2. Optimal Substructure Property

Any problem has optimal substructure property if its overall optimal solution can be constructed
from the optimal solutions of its subproblems. For Fibonacci numbers, as we know,

Fib(n) = Fib(n-1) + Fib(n-2)

This clearly shows that a problem of size ‘n’ has been reduced
to subproblems of size ‘n-1’ and ‘n-2’.
Therefore, Fibonacci numbers have optimal substructure property.

Dynamic Programming Methods

DP offers two methods to solve a problem.
1. Top-down with Memoization

In this approach, we try to solve the bigger problem by recursively finding the solution to smaller sub-problems.
Whenever we solve a sub-problem, we cache its result so that we don’t end up solving it repeatedly if it’s called multiple times.
Instead, we can just return the saved result.

This technique of storing the results of already solved subproblems is called Memoization.

2. Bottom-up with Tabulation

Tabulation is the opposite of the top-down approach and avoids recursion.
In this approach, we solve the problem “bottom-up” (i.e. by solving all the related sub-problems first).
This is typically done by filling up an n-dimensional table.
Based on the results in the table, the solution to the top/original problem is then computed.

Tabulation is the opposite of Memoization, as in Memoization we solve the problem and maintain a map of already solved sub-problems.
In other words, in memoization, we do it top-down in the sense that we solve the top problem first
(which typically recurses down to solve the sub-problems).
*/

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Fibonacci f = new Fibonacci();

            Console.WriteLine("Regular:");
            TimeFibonacci(40, f.CalculateFibonacci);
            TimeFibonacci(45, f.CalculateFibonacci);
            TimeFibonacci(50, f.CalculateFibonacci);

            Console.WriteLine("\nMemoization:");
            TimeFibonacci(40, f.CalculateFibonacciMemoization);
            TimeFibonacci(45, f.CalculateFibonacciMemoization);
            TimeFibonacci(50, f.CalculateFibonacciMemoization);

            Console.WriteLine("\nTabulation:");
            TimeFibonacci(40, f.CalculateFibonacciTabulation);
            TimeFibonacci(45, f.CalculateFibonacciTabulation);
            TimeFibonacci(50, f.CalculateFibonacciTabulation);

            Console.ReadKey();
        }

        public static void TimeFibonacci(int n, Func<int, long> func)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result = func(n);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            Console.WriteLine($"Fibonacci of {n}: {result}");
            Console.WriteLine($"RunTime: {ts.Hours:00}:{ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");
        }
    }

    class Fibonacci
    {
        // regular non DP method
        public long CalculateFibonacci(int n)
        {
            if (n < 2) return n;
            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }

        // Make use of memoization  
        public long CalculateFibonacciMemoization(int n)
        {
            long[] memoize = new long[n + 1];

            // we could pre populate the 0 and 1 case and remove the n < 2 case in the recursive function

            return CalculateFibonacciMemoize(memoize, n);

        }

        private long CalculateFibonacciMemoize(long[] memoize, int n)
        {
            if (n < 2) return n;

            // have we already calculated this one?
            if (memoize[n] != 0) return memoize[n];

            memoize[n] = CalculateFibonacciMemoize(memoize, n - 1) + CalculateFibonacciMemoize(memoize, n - 2);
            return memoize[n];
        }

        // Tabulation
        public long CalculateFibonacciTabulation(int n)
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


    }


}
