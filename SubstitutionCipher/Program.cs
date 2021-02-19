using System;
using System.Linq;
using System.Text;
/*
A substitution cipher is a simple way to obfuscate a string by replacing the letters given a mapping. For example:

cipher:   'mpgzkeyrsxfwlvjbcnuidhoqat'
alphabet: 'abcdefghijklmnopqrstuvwxyz'
Each letter in the cipher replaces the corresponding letter in the alphabet
(m replaces occurrences of a, p replaces occurrences of b, etc.).
So a word like abs becomes mpu.

Example Input:
plain_text: 'helloworld'
cipher_alphabet: 'mpgzkeyrsxfwlvjbcnuidhoqat'
Example Output:
rkwwjojnwz
Explanation:
In the cipher_alphabet 'helloworld' is encoded to 'rkwwjojnwz`
*/
namespace SubstitutionCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(Encrypt("helloworld", "mpgzkeyrsxfwlvjbcnuidhoqat"));
            Console.WriteLine(Encrypt("abs", "mpgzkeyrsxfwlvjbcnuidhoqat"));

            Console.WriteLine(Encrypt("hello world", "bjosxcqukmrhgeynazldwfpvti"));
            Console.WriteLine(Encrypt("HW", "bjosxcqukmrhgeynazldwfpvti"));
            Console.WriteLine(Encrypt("hello", "mpgzkenuidhoqat"));
            Console.WriteLine(Encrypt("hello", "bjosxcqukmrhgbjosxcqukmrhgeynazldwfpvtieynazldwfpvti"));

            Console.WriteLine(Encrypt("hello", "mpgzkeyrsxfwlvjbcnuidhoqat"));
            Console.WriteLine(Encrypt("hello", "Mpgzkeyrsxfwlvjbcnuidhoqat"));
            Console.WriteLine(Encrypt("hello", "mmgzkeyrsxfwlvjbcnuidhoqat"));
            Console.ReadKey();

        }


        public static string Encrypt(string word, string cipher)
        {
            if (!CheckCipher(cipher)) return String.Empty;


            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                // only lower case
                if (char.IsLower(word[i]))
                {
                    sb.Append(cipher[word[i] - 97]);
                }
                else
                {
                    // any other character and we exit
                    return String.Empty;
                }
            }

            return sb.ToString();

        }

        static bool CheckCipher(string cipher)
        {
            // cipher must have 26 characters, none of which should repeat
            if (cipher.Length != 26) return false;

            if (cipher.Distinct().Count() != 26) return false;

            // We know we have 26 distinct chars, but are they lower case letters?
            return cipher.All(char.IsLower);
        }

    }
}
