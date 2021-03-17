using System;
/*
 * Generate Random Point in a Circle
 * 
 * Given the radius and x-y positions of the center of a circle, write a function randPoint which generates a uniform random point in the circle.
 * 
 * Note:
 * input and output values are in floating-point.
 * radius and x-y position of the center of the circle is passed into the class constructor.
 * a point on the circumference of the circle is considered to be in the circle.
 * randPoint returns a size 2 array containing x-position and y-position of the random point, in that order.
 * 
 * Example 1:
 * Input: ["Solution","randPoint","randPoint","randPoint"]
 *        [[1,0,0],[],[],[]]
 * Output: [null,[-0.72939,-0.65505],[-0.78502,-0.28626],[-0.83119,-0.19803]]
 * 
 * Example 2:
 * Input: ["Solution","randPoint","randPoint","randPoint"]
 * [[10,5,-7.5],[],[],[]]
 * Output: [null,[11.52438,-8.33273],[2.46992,-16.21705],[11.13430,-12.42337]]
 * 
 * Explanation of Input Syntax:
 * The input is two lists: the subroutines called and their arguments. 
 * Solution's constructor has three arguments, the radius, x-position of the center, and y-position of the center of the circle. 
 * 
 * randPoint has no arguments. Arguments are always wrapped with a list, even if there aren't any.
 * 
 */
/*
 * Runtime: 452 ms       Your runtime beats 100.00 % of csharp submissions.
 * Memory Usage: 50.4 MB Your memory usage beats 50.00 % of csharp submissions.
 */
namespace _0478_GenerateRandomPointinaCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Solution obj = new(1, 0, 0);

            for (int i = 0; i < 3; i++)
            {
                double[] param_1 = obj.RandPoint();

                foreach (var item in param_1)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }

    public class Solution
    {
        readonly double radius = 0;
        readonly double x_center = 0;
        readonly double y_center = 0;
        readonly Random random;

        public Solution(double radius, double x_center, double y_center)
        {
            this.radius = radius;
            this.x_center = x_center;
            this.y_center = y_center;
            random = new Random();
        }

        public double[] RandPoint()
        {
            /*
             * I've read this a few times and I'm still not entirly sure I fully 
             * grasp the square root part:
             * leetcode.com/problems/generate-random-point-in-a-circle/discuss/155650/Explanation-with-Graphs-why-using-Math.sqrt()
             */

            double len = Math.Sqrt(random.NextDouble()) * radius;
            double deg = random.NextDouble() * 2 * Math.PI;
            double x = x_center + len * Math.Cos(deg);
            double y = y_center + len * Math.Sin(deg);
            return new double[] { x, y };
        }
    }

    /*
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(radius, x_center, y_center);
     * double[] param_1 = obj.RandPoint();
     */

}
