using System;
using System.Collections.Generic;
/*
* Keys and Rooms
* 
* There are N rooms and you start in room 0.
* Each room has a distinct number in 0, 1, 2, ..., N-1, and each room may have some keys to access the next room. 
* 
* Formally, each room i has a list of keys rooms[i], 
* and each key rooms[i][j] is an integer in [0, 1, ..., N-1] where N = rooms.length.
* A key rooms[i][j] = v opens the room with number v.
* 
* Initially, all the rooms start locked (except for room 0). 
* You can walk back and forth between rooms freely.
* 
* Return true if and only if you can enter every room.
*
* Example 1:
* Input: [[1],[2],[3],[]]
* Output: true
* Explanation:  
* We start in room 0, and pick up key 1.
* We then go to room 1, and pick up key 2.
* We then go to room 2, and pick up key 3.
* We then go to room 3.  Since we were able to go to every room, we return true.
* 
* Example 2:
* Input: [[1,3],[3,0,1],[2],[0]]
* Output: false
* Explanation: We can't enter the room with number 2.
* 
* Note:
*  1 <= rooms.length <= 1000
*  0 <= rooms[i].length <= 1000
*  The number of keys in all rooms combined is at most 3000.
*/
/*
 * Runtime: 108 ms     Your runtime beats 51.49 % of csharp submissions.
 * Memory Usage: 27 MB Your memory usage beats 55.22 % of csharp submissions.
 */
namespace _0841_KeysandRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IList<IList<int>> e1 = new List<IList<int>>
            {
                new List<int>() { 1 },
                new List<int>() { 2 },
                new List<int>() { 3 },
                new List<int>()
            };
            Console.WriteLine(CanVisitAllRooms(e1));

            IList<IList<int>> e2 = new List<IList<int>>
            {
                new List<int>() { 1, 3 },
                new List<int>() { 3, 0, 1 },
                new List<int>() { 2 },
                new List<int>() { 0 }
            };
            Console.WriteLine(CanVisitAllRooms(e2));


        }        

        static bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            // a list of keys to check
            Queue<int> keys = new();
            // Queue<int> keys = new Queue<int>(); // leetcode requires

            // which rooms have we visited
            HashSet<int> visited = new(); // = new HashSet<int>();

            // we start in the first room            
            visited.Add(0);
            keys.Enqueue(0);

            while (keys.Count > 0)
            {
                // get a room key
                var key = keys.Dequeue();

                // get the keys from that room
                IList<int> foundKeys = rooms[key];

                foreach (var k in foundKeys)
                {
                    // have we been to this room before?
                    if (!visited.Contains(k))
                    {
                        keys.Enqueue(k);
                        visited.Add(k);
                    }
                }

            }

            // check our room and visited counts
            return rooms.Count == visited.Count;

        }


    }
}
