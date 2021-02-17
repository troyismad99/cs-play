using System;
/*
 Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai).
n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0).

Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.

Notice that you may not slant the container.

Example 1:

8   x         x 
7   x         x   x
6   x x       x   x
5   x x   x   x   x
4   x x   x x x   x
3   x x   x x x x x
2   x x x x x x x x
1 x x x x x x x x x
0 ------------------

8   x         x 
7   xooooooooooooox
6   xooooooooooooox
5   xooooooooooooox
4   xooooooooooooox
3   xooooooooooooox
2   xooooooooooooox
1 x xooooooooooooox
0 ------------------

    Input: height = [1,8,6,2,5,4,8,3,7]
    Output: 49
    Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7].
    In this case, the max area of water (blue section) the container can contain is 49.

Example 2:
    Input: height = [1,1]
    Output: 1

Example 3:
    Input: height = [4,3,2,1,4]
    Output: 16

Example 4:
    Input: height = [1,2,1]
    Output: 2

Constraints:
    n == height.length
    2 <= n <= 3 * 104
    0 <= height[i] <= 3 * 104
 */



/*
 * Runtime: 108 ms     Your runtime beats 87.73 % of csharp submissions.
 * Memory Usage: 31 MB
 */


namespace _0011_ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
            Console.WriteLine(MaxArea(new int[] { 1, 1 }));
            Console.WriteLine(MaxArea(new int[] { 4, 3, 2, 1, 4 }));
            Console.WriteLine(MaxArea(new int[] { 1, 2, 1 }));

            Console.ReadKey();
        }

        public static int MaxArea(int[] height)
        {
            /*
             * A two pointer solution. 
             * Start with the widest posible container.
             * The other possible containers are narrower, so they need to be higher.
             */
            var result = 0;

            var left = 0;
            var right = height.Length - 1;

            while (left < right)
            {
                // check the area
                var area = Math.Min(height[left], height[right]) * (right - left);
                result = Math.Max(result, area);

                // now adjust a pointer
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return result;
        }


    }
}
