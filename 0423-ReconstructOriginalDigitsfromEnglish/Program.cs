using System;
using System.Linq;
using System.Text;
/*
 * Reconstruct Original Digits from English
 * 
 * Given a non-empty string containing an out-of-order English representation of digits 0-9, 
 * output the digits in ascending order.
 * 
 * Note:
 *  Input contains only lowercase English letters.
 *  Input is guaranteed to be valid and can be transformed to its original digits. 
 *      That means invalid inputs such as "abc" or "zerone" are not permitted.
 *  Input length is less than 50,000.
 *  
 *  Example 1:
 *  Input: "owoztneoer"
 *  Output: "012"
 *  
 *  Example 2:
 *  Input: "fviefuro"
 *  Output: "45"
 *  
 */
/*
 * Runtime: 116 ms       Your runtime beats 25.00 % of csharp submissions.
 * Memory Usage: 35.3 MB 
 */
namespace _0423_ReconstructOriginalDigitsfromEnglish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LetterDistribution();

            Console.WriteLine(OriginalDigits("owoztneoer"));
            Console.WriteLine(OriginalDigits("fviefuro"));

            Console.WriteLine(OriginalDigits("nniinnee"));

        }

        static string OriginalDigits(string s)
        {
            // the count of each number found
            int[] theCount = new int[10];

            // count the input letter distribution
            var d = s.ToCharArray().GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());

            // extract the single letter numbers
            theCount[0] = d.ContainsKey('z') ? d['z'] : 0; // the only z is in zero
            theCount[2] = d.ContainsKey('w') ? d['w'] : 0;
            theCount[4] = d.ContainsKey('u') ? d['u'] : 0;
            theCount[6] = d.ContainsKey('x') ? d['x'] : 0;
            theCount[8] = d.ContainsKey('g') ? d['g'] : 0;

            // we can caluclate the rest based on what is left
            // example: f only appears in four and five
            //          once we have counted the fours above
            //          any other f's are fives
            theCount[5] = (d.ContainsKey('f') ? d['f'] : 0) - theCount[4];

            // five allows us to calculate seven
            theCount[7] = (d.ContainsKey('v') ? d['v'] : 0) - theCount[5];

            // h is only in eight and three
            theCount[3] = (d.ContainsKey('h') ? d['h'] : 0) - theCount[8];

            // 1 is any o's not used in zero, two, or four
            theCount[1] = (d.ContainsKey('o') ? d['o'] : 0) - theCount[0] - theCount[2] - theCount[4];

            // nine is n's not used in one and seven. /2 for two n's in nine
            theCount[9] = ((d.ContainsKey('n') ? d['n'] : 0) - theCount[1] - theCount[7]) / 2;

            StringBuilder sb = new();

            for (int i = 0; i < 10; i++)
            {
                while(theCount[i]-- > 0)
                {
                    sb.Append(i);
                }
            }

            /*
             * zero     z
             * one
             * two      w
             * three
             * four     u
             * five
             * six      x
             * seven
             * eight    g
             * nine
             */

            return sb.ToString();
        }


        static void LetterDistribution()
        {
            var s = "zeroonetwothreefourfivesixseveneightnine";

            var d = s.ToCharArray().GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
           
            foreach (var item in d)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }

            /*
                z -> 1
                e -> 9
                r -> 3
                o -> 4
                n -> 4
                t -> 3
                w -> 1
                h -> 2
                f -> 2
                u -> 1
                i -> 4
                v -> 2
                s -> 2
                x -> 1
                g -> 1
            */
        }

    }
}
