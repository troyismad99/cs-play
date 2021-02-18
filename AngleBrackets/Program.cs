using System;
using System.Collections.Generic;
/*
* Given a string of angle brackets, angles, such as "<<><>><<<>", 
* write a function that adds angle brackets to the beginning and end 
* to make all angle brackets match and return it. 
* 
* The angle brackets "match" if:
* for every < there is a corresponding > appearing after it in the string, 
* and for every > there is a corresponding < appearing before it in the string.

Example Input:
angles: "><<><"
Output: "<><<><>>"
Explanation:
We added "<" to the beginning and ">>" to the end.
*/

namespace AngleBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(AngleBracketMatchOMatic("><<><"));
            Console.WriteLine(AngleBracketMatchOMatic("<<>>>>><<<>>")); //"<<<<<>>>>><<<>>>"
            Console.WriteLine(AngleBracketMatchOMatic("<>"));
            Console.WriteLine(AngleBracketMatchOMatic("><"));

            Console.ReadKey();
        }

        static string AngleBracketMatchOMatic( string angles)
        {
            var start = String.Empty;
            var end = String.Empty;

            var stack = new Stack<char>();

            foreach (char bracket in angles)
            {
                // any open brackets go onto the stack
                if (bracket == '<')
                {
                    stack.Push(bracket);
                }
                else
                {
                    // a close with no open waiting
                    if (stack.Count == 0)
                    {
                        // add an open
                        start = "<" + start;
                    }
                    else
                    {
                        // we have an open, so discard it
                        _ = stack.Pop();
                    }
                }
            }

            // add any missing closes
            while (stack.Count != 0)
            {
                stack.Pop();
                end += ">";
            }

            return start + angles + end;
        }
    }
}
