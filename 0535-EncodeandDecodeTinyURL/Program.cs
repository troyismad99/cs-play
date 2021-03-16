using System;
using System.Collections;
using System.Text;
/*
* Encode and Decode TinyURL
* 
* TinyURL is a URL shortening service where you enter a URL 
* such as https://leetcode.com/problems/design-tinyurl 
* and it returns a short URL such as http://tinyurl.com/4e9iAk.
* 
* Design the encode and decode methods for the TinyURL service. 
* There is no restriction on how your encode/decode algorithm should work. 
* You just need to ensure that a URL can be encoded to a tiny URL and the tiny URL can be decoded to the original URL.
* 
*/
/*
 * Runtime: 96 ms      Your runtime beats 51.69 % of csharp submissions.
 * Memory Usage: 27 MB Your memory usage beats 38.98 % of csharp submissions.
 */
namespace _0535_EncodeandDecodeTinyURL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Codec codec = new();

            var url = "https://leetcode.com/problems/design-tinyurl";
            var e = codec.encode(url);
            var d = codec.decode(e);

            Console.WriteLine(url);
            Console.WriteLine(e);
            Console.WriteLine(d);

        }
    }

    public class Codec
    {
        private const string URLPrefix = "http://tinyurl.com/";

        // these are just in memory
        readonly Hashtable hash1 = new();
        readonly Hashtable hash2 = new();
        readonly string keySet = "abcdefthijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            // guard against missing URL
            if (string.IsNullOrEmpty(longUrl))
            {
                return string.Empty;
            }

            // guard against a repeat
            // do we already have this?
            if (hash1.ContainsKey(longUrl))
            {
                return (string)hash1[longUrl];
            }

            // build new URL with 6 random characters
            StringBuilder sb = new();

            for (int i = 0; i <= 5; i++)
            {
                sb.Append(keySet[new Random().Next(0, 61)]);
            }

            var shortURL = URLPrefix + sb.ToString();

            hash1.Add(longUrl, shortURL);
            hash2.Add(shortURL, longUrl);

            return shortURL;
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            return (string)hash2[shortUrl];
        }
    }

}
