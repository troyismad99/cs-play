using System;
using System.Text;

/*
The Reformatter
We are given a string XYZ representing a phone number which we would like to reformat. 
String XYZ consists of N characters: digits, spaces and/or dashes. 

It contains at least two digits. Spaces and dashes in string XYZ should be ignored.

We want to reformat the given phone number in such a way that the digits are
grouped in blocks of 3 characters, separated by single dashes.
If necessary, the final block or the last two blocks can be of 2 characters.

Write a function that, given a string XYZ representing a phone number, 
returns this phone number reformatted as described above.

Examples:
  Input	              -> Expected Output
  00-44 48 5555 8361  -> 004-448-555-583-61
  0 - 22 1985--324    -> 022-198-53-24
  555372654           -> 555-372-654

Assume that:
    N is an integer within the range [2..100]; 
    string XYZ consists only of digits (0−9), spaces and/or dashes (-); 
    string XYZ contains at least two digits.
*/

namespace ReformatPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(Reformatter("00-44 48 5555 8361"));
            Console.WriteLine(Reformatter("0 - 22 1985--324"));
            Console.WriteLine(Reformatter("555372654"));

        }

        public static string Reformatter(string XYZ)
        {
            XYZ = XYZ.Replace("-", "").Replace(" ", "");

            var i = 0;
            StringBuilder sbResult = new();

            while (i < XYZ.Length)
            {
                if (XYZ.Length - i == 2)
                {
                    sbResult.Append(XYZ[i++]);
                    sbResult.Append(XYZ[i++]);
                }
                else if (XYZ.Length - i == 4)
                {
                    sbResult.Append(XYZ[i++]);
                    sbResult.Append(XYZ[i++]);
                    sbResult.Append('-');
                    sbResult.Append(XYZ[i++]);
                    sbResult.Append(XYZ[i++]);

                }
                else if (XYZ.Length - i >= 3)
                {
                    sbResult.Append(XYZ[i++]);
                    sbResult.Append(XYZ[i++]);
                    sbResult.Append(XYZ[i++]);

                    if (i != XYZ.Length)
                    {
                        sbResult.Append('-');
                    }

                }

            }

            return sbResult.ToString();
        }

    }
}
