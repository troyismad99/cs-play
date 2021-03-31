using System;
using System.Collections.Generic;
/*
 * Stamping The Sequence
 * 
 * You want to form a target string of lowercase letters.
 * 
 * At the beginning, your sequence is target.length '?' marks.
 * You also have a stamp of lowercase letters.
 * 
 * On each turn, you may place the stamp over the sequence, 
 * and replace every letter in the sequence with the corresponding letter 
 * from the stamp. You can make up to 10 * target.length turns.
 * 
 * For example, if the initial sequence is "?????", and your stamp is "abc", 
 * then you may make "abc??", "?abc?", "??abc" in the first turn.  
 * (Note that the stamp must be fully contained in the boundaries of the 
 * sequence in order to stamp.)
 * 
 * If the sequence is possible to stamp, then return an array of the index of 
 * the left-most letter being stamped at each turn. 
 * If the sequence is not possible to stamp, return an empty array.
 * 
 * For example, if the sequence is "ababc", and the stamp is "abc", 
 * then we could return the answer [0, 2], 
 * corresponding to the moves "?????" -> "abc??" -> "ababc".
 * 
 * Also, if the sequence is possible to stamp, it is guaranteed it is possible
 * to stamp within 10 * target.length moves. 
 * Any answers specifying more than this number of moves will not be accepted.
 * 
 * Example 1:
 * Input: stamp = "abc", target = "ababc"
 * Output: [0,2]
 * ([1,0,2] would also be accepted as an answer, as well as some other answers.)
 * 
 * Example 2:
 * Input: stamp = "abca", target = "aabcaca"
 * Output: [3,0,1]
 * 
 * Note:
 *   1 <= stamp.length <= target.length <= 1000
 *   stamp and target only contain lowercase letters.
 *
 */
/*
 * Runtime: 240 ms       Your runtime beats 77.78 % of csharp submissions.
 * Memory Usage: 33.8 MB Your memory usage beats 88.89 % of csharp submissions.
 */
namespace _0936_StampingTheSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(string.Join(',', MovesToStamp("abc", "abcbc")));
            Console.WriteLine(string.Join(',', MovesToStamp("abca", "aabcaca")));

        }

        const char STAMPINDICATOR = '*';

        static int[] MovesToStamp(string stamp, string target)
        {
            // guard against bad arguments
            if ((stamp == null) || (stamp.Length == 0) || (target == null) || (target.Length == 0))
                return Array.Empty<int>();

            /* 
             * This problem was difficult to understand at first but eventually
             * it clicked into place.
             * 
             * The nature of the stamp is that it overwrites everything that it 
             * "stamps". So anywhere the full stamp appears in the target has 
             * to the last stamp placed.
             * For example 1: stamp = "abc", target = "ababc"
             *      step -> target 
             *      last    "ab***" (stamp index 2 to set full stamp
             *      last-1  "*****" (stamp index 0 to get proper first chars)
             * 
             */

            char[] stampChars = stamp.ToCharArray();
            char[] targetChars = target.ToCharArray();
            bool[] visited = new bool[target.Length];

            List<int> result = new();

            int indicators = 0;

            // continue untilt he target is all indicators
            while (indicators < target.Length)
            {
                bool isReplaced = false;

                for (int i = 0; i <= target.Length - stamp.Length; i++)
                {
                    if (!visited[i] && CanStamp(i, stampChars, targetChars))
                    {
                        indicators = StampTarget(i, stamp.Length, targetChars, indicators);
                        isReplaced = true;
                        visited[i] = true;
                        result.Add(i);

                        // did this "stamp" finish our target?
                        if (indicators == target.Length)
                        {
                            break;
                        }
                    }
                }

                if (!isReplaced)
                {
                    // leave if we couldn't stamp
                    return Array.Empty<int>();
                }
            }

            result.Reverse();
            return result.ToArray();
        }

        static bool CanStamp(int index, char[] stamp, char[] target)
        {
            // check each character in the stamp
            for (int i = 0; i < stamp.Length; i++)
            {
                // it's ok to stamp over an * character if they don't match
                if ((stamp[i] != target[index + i]) && (target[index + i] != STAMPINDICATOR))
                {
                    return false;
                }
            }

            return true;
        }

        static int StampTarget(int start, int stampLength, char[] target, int indicatorCount)
        {
            // apply the stamp
            for (int i = 0; i < stampLength; i++)
            {
                // the "stamp" just replaces the target chars with indicator characters
                if (target[start + i] != STAMPINDICATOR)
                {
                    target[start + i] = STAMPINDICATOR;
                    indicatorCount++;
                }
            }

            return indicatorCount;
        }
    }
}
