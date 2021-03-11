using System;
/*
 * Coin Change
 * 
 * You are given coins of different denominations and a total amount of money amount.
 * Write a function to compute the fewest number of coins that you need to make up that amount. 
 * If that amount of money cannot be made up by any combination of the coins, return -1.
 * 
 * You may assume that you have an infinite number of each kind of coin.

Example 1:
    Input: coins = [1,2,5], amount = 11
    Output: 3
    Explanation: 11 = 5 + 5 + 1

Example 2:
    Input: coins = [2], amount = 3
    Output: -1

Example 3:
    Input: coins = [1], amount = 0
    Output: 0

Example 4:
    Input: coins = [1], amount = 1
    Output: 1

Example 5:
    Input: coins = [1], amount = 2
    Output: 2

Constraints:
    1 <= coins.length <= 12
    1 <= coins[i] <= 2^31 - 1
    0 <= amount <= 10^4
 */

/*
 * Runtime: 112 ms     Your runtime beats 76.97 % of csharp submissions.
 * Memory Usage: 28 MB Your memory usage beats 42.98 % of csharp submissions.
 */
namespace _0322_CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(CoinChange(new int[] { 1, 2, 5 }, 11));
            Console.WriteLine(CoinChange(new int[] { 2 }, 3));
            Console.WriteLine(CoinChange(new int[] { 1 }, 0));
            Console.WriteLine(CoinChange(new int[] { 1 }, 1));
            Console.WriteLine(CoinChange(new int[] { 1 }, 2));
            Console.WriteLine();

            // 3,3 is better than 4,1,1
            Console.WriteLine(CoinChange(new int[] { 1, 3, 4 }, 6));

            Console.WriteLine(CoinChange(new int[] { 5, 10, 25 }, 50));

            Console.WriteLine(CoinChange(new int[] { 1, 5, 10, 25, 100, 200 }, 75));
            Console.WriteLine(CoinChange(new int[] { 1, 5, 10, 25, 100, 200 }, 76));
            Console.WriteLine(CoinChange(new int[] { 1, 5, 10, 25, 100, 200 }, 16));
            Console.WriteLine(CoinChange(new int[] { 1, 5, 10, 25, 100, 200 }, 99));

        }

        public static int CoinChange(int[] coins, int amount)
        {
            // guard against no coins
            if ((coins == null) || (coins.Length == 0))
                return 0;

            // make sure these are in the proper order
            Array.Sort(coins, (x, y) => (x.CompareTo(y)));

            /* 
             * We can't use a greedy implementation where we start
             * with the biggest coins and work backwards.
             * 
             * For these coins: 1,3,4 with amount = 6
             *      Greedy would give 3 coins: 4,1,1
             *      However the better solution is 3,3
             */

            // we will find the coin count for the combinations leading up to amount
            int[] resultCoins = new int[amount + 1];

            // start with a no solution indicator
            Array.Fill(resultCoins, int.MaxValue);

            // zero is zero
            resultCoins[0] = 0;

            // i interates through the coin denominations
            for (int i = 0; i < coins.Length; i++)
            {
                // ii iterates through the amounts
                for (int ii = 1; ii <= amount; ii++)
                {
                    // can we fit any of these coins into this amount?
                    if (ii - coins[i] >= 0)
                    {
                        // Make sure when this coin was available "denomination" ago it could be used
                        // Example:
                        // if we are on 11 cents: resultCoins[11]
                        // with a dime: coins[i]
                        // there needs to be a value in resultCoins[1]
                        if (resultCoins[ii - coins[i]] != int.MaxValue)
                        {
                            // check if adding one coin is smaller than the current coin count
                            resultCoins[ii] = Math.Min(resultCoins[ii - coins[i]] + 1, resultCoins[ii]);
                        }
                    }
                }
            }

            // check for a solution for our amount
            if (resultCoins[amount] == int.MaxValue)
            {
                return -1;
            }

            return resultCoins[amount];
        }

    }
}
