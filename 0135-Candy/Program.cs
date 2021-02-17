using System;
using System.Linq;
/*
There are N children standing in a line. Each child is assigned a rating value.

You are giving candies to these children subjected to the following requirements:

Each child must have at least one candy.
Children with a higher rating get more candies than their neighbors.
What is the minimum candies you must give?

Example 1:

Input: [1,0,2]
Output: 5
Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.
Example 2:

Input: [1,2,2]
Output: 4
Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
The third child gets 1 candy because it satisfies the above two conditions.
*/

/*
 * Runtime: 120 ms, faster than 35.05% of C# online submissions for Candy.
 * Memory Usage: 30.6 MB, less than 69.07% of C# online submissions for Candy.
 */


namespace _0135_Candy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(Candy(new int[] { 1, 0, 2 }));
            Console.WriteLine(Candy(new int[] { 1, 2, 2 }));
            Console.WriteLine(Candy(new int[] { 1, 2, 3, 4, 4, 4, 3, 2, 2 }));

            Console.ReadKey();
        }

        // "and you get a candy, and you get a candy" - Oprah
        public static int Candy(int[] ratings)
        {            
            int[] candyMan = new int[ratings.Length];

            // everyone gets one candy
            for (int i = 0; i < ratings.Length; i++)
            {
                candyMan[i] = 1;
            }

            /*
             * My first attempt was to try with one for loop.
             * ended up with a count up, then count down
             */


// first pass is forward and compares to the previous ratings
// note we start at second element
for (int i = 1; i < ratings.Length; i++)
            {
                // if we are greater set our candy count to one higher
                if (ratings[i] > ratings[i - 1])
                {
                    candyMan[i] = candyMan[i - 1] + 1;
                }

            }

            // second pass is count down
            for (int i = ratings.Length - 1; i > 0; i--)
            {
                // again compare against the previous
                if (ratings[i - 1] > ratings[i])
                {
                    candyMan[i - 1] = Math.Max(candyMan[i - 1], candyMan[i] + 1);
                }
            }

            return candyMan.Sum();
        }
    }
}

/*
Hello World!
1,0,2
2,1,2
5
1,2,2
1,2,1
4
1,2,3,4,4,4,3,2,2
1,2,3,4,3,3,2,1,1
20*/
