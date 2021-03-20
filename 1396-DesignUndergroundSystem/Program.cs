using System;
using System.Collections.Generic;
/*
* Design Underground System
* 
* Implement the UndergroundSystem class:
* 
* void checkIn(int id, string stationName, int t)
*      A customer with a card id equal to id, gets in the station stationName at time t.
*      A customer can only be checked into one place at a time.
*      
* void checkOut(int id, string stationName, int t)
*      A customer with a card id equal to id, gets out from the station stationName at time t.
*      
* double getAverageTime(string startStation, string endStation)
*      Returns the average time to travel between the startStation and the endStation.
*      The average time is computed from all the previous traveling from startStation to endStation that happened directly.
*      Call to getAverageTime is always valid.
*      
* You can assume all calls to checkIn and checkOut methods are consistent. 
* If a customer gets in at time t1 at some station, they get out at time t2 with t2 > t1. 
* All events happen in chronological order.
* 
* Example 1:
* Input
*   ["UndergroundSystem","checkIn","checkIn","checkIn","checkOut","checkOut","checkOut","getAverageTime","getAverageTime","checkIn","getAverageTime","checkOut","getAverageTime"]
*   [[],[45,"Leyton",3],[32,"Paradise",8],[27,"Leyton",10],[45,"Waterloo",15],[27,"Waterloo",20],[32,"Cambridge",22],["Paradise","Cambridge"],["Leyton","Waterloo"],[10,"Leyton",24],["Leyton","Waterloo"],[10,"Waterloo",38],["Leyton","Waterloo"]]
* Output
* [null,null,null,null,null,null,null,14.00000,11.00000,null,11.00000,null,12.00000]
* Explanation
* UndergroundSystem undergroundSystem = new UndergroundSystem();
* undergroundSystem.checkIn(45, "Leyton", 3);
* undergroundSystem.checkIn(32, "Paradise", 8);
* undergroundSystem.checkIn(27, "Leyton", 10);
* undergroundSystem.checkOut(45, "Waterloo", 15);
* undergroundSystem.checkOut(27, "Waterloo", 20);
* undergroundSystem.checkOut(32, "Cambridge", 22);
* undergroundSystem.getAverageTime("Paradise", "Cambridge");       // return 14.00000. There was only one travel from "Paradise" (at time 8) to "Cambridge" (at time 22)
* undergroundSystem.getAverageTime("Leyton", "Waterloo");          // return 11.00000. There were two travels from "Leyton" to "Waterloo", a customer with id=45 from time=3 to time=15 and a customer with id=27 from time=10 to time=20. So the average time is ( (15-3) + (20-10) ) / 2 = 11.00000
* undergroundSystem.checkIn(10, "Leyton", 24);
* undergroundSystem.getAverageTime("Leyton", "Waterloo");          // return 11.00000
* undergroundSystem.checkOut(10, "Waterloo", 38);
* undergroundSystem.getAverageTime("Leyton", "Waterloo");          // return 12.00000
* 
* Example 2:
* Input
* ["UndergroundSystem","checkIn","checkOut","getAverageTime","checkIn","checkOut","getAverageTime","checkIn","checkOut","getAverageTime"]
* [[],[10,"Leyton",3],[10,"Paradise",8],["Leyton","Paradise"],[5,"Leyton",10],[5,"Paradise",16],["Leyton","Paradise"],[2,"Leyton",21],[2,"Paradise",30],["Leyton","Paradise"]]
* Output
* [null,null,null,5.00000,null,null,5.50000,null,null,6.66667]
* Explanation
* UndergroundSystem undergroundSystem = new UndergroundSystem();
* undergroundSystem.checkIn(10, "Leyton", 3);
* undergroundSystem.checkOut(10, "Paradise", 8);
* undergroundSystem.getAverageTime("Leyton", "Paradise"); // return 5.00000
* undergroundSystem.checkIn(5, "Leyton", 10);
* undergroundSystem.checkOut(5, "Paradise", 16);
* undergroundSystem.getAverageTime("Leyton", "Paradise"); // return 5.50000
* undergroundSystem.checkIn(2, "Leyton", 21);
* undergroundSystem.checkOut(2, "Paradise", 30);
* undergroundSystem.getAverageTime("Leyton", "Paradise"); // return 6.66667
* 
* Constraints:
*     There will be at most 20000 operations.
*     1 <= id, t <= 10^6
*     All strings consist of uppercase and lowercase English letters, and digits.
*     1 <= stationName.length <= 10
*     Answers within 10^-5 of the actual value will be accepted as correct.
*     
*/
/*
 * Runtime: 388 ms       Your runtime beats 67.32 % of csharp submissions.
 * Memory Usage: 47.8 MB Your memory usage beats 98.69 % of csharp submissions.
 */
namespace _1396_DesignUndergroundSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            UndergroundSystem undergroundSystem = new();
            undergroundSystem.CheckIn(45, "Leyton", 3);
            undergroundSystem.CheckIn(32, "Paradise", 8);
            undergroundSystem.CheckIn(27, "Leyton", 10);
            undergroundSystem.CheckOut(45, "Waterloo", 15);
            undergroundSystem.CheckOut(27, "Waterloo", 20);
            undergroundSystem.CheckOut(32, "Cambridge", 22);

            // return 14.00000. There was only one travel from "Paradise" (at time 8) to "Cambridge" (at time 22)
            Console.WriteLine(undergroundSystem.GetAverageTime("Paradise", "Cambridge"));
                        
            // return 11.00000. There were two travels from "Leyton" to "Waterloo":
            // a customer with id=45 from time=3 to time=15 and
            // a customer with id=27 from time=10 to time=20.
            // So the average time is ( (15-3) + (20-10) ) / 2 = 11.00000
            Console.WriteLine(undergroundSystem.GetAverageTime("Leyton", "Waterloo"));

            undergroundSystem.CheckIn(10, "Leyton", 24);

            // return 11.00000
            Console.WriteLine(undergroundSystem.GetAverageTime("Leyton", "Waterloo"));

            undergroundSystem.CheckOut(10, "Waterloo", 38);

            // return 12.00000
            Console.WriteLine(undergroundSystem.GetAverageTime("Leyton", "Waterloo"));

            /*
             * example 2
             */
            undergroundSystem = new UndergroundSystem();
            undergroundSystem.CheckIn(10, "Leyton", 3);
            undergroundSystem.CheckOut(10, "Paradise", 8);

            // return 5.00000
            Console.WriteLine(undergroundSystem.GetAverageTime("Leyton", "Paradise"));

            undergroundSystem.CheckIn(5, "Leyton", 10);
            undergroundSystem.CheckOut(5, "Paradise", 16);

            // return 5.50000
            Console.WriteLine(undergroundSystem.GetAverageTime("Leyton", "Paradise"));

            undergroundSystem.CheckIn(2, "Leyton", 21);
            undergroundSystem.CheckOut(2, "Paradise", 30);

            // return 6.66667
            Console.WriteLine(undergroundSystem.GetAverageTime("Leyton", "Paradise"));

        }
    }

    public class UndergroundSystem
    {
        private readonly Dictionary<int, (string stationName, int startTime)> checkInMap = new();
        private readonly Dictionary<string, (int duration, int trips)> checkOutMap = new();

        public UndergroundSystem()
        {}

        public void CheckIn(int id, string stationName, int t)
        {
            // put them on the train, they have no impact until they exit
            checkInMap.Add(id, (stationName, t));
        }

        public void CheckOut(int id, string stationName, int t)
        {
            // retrieve the start and calculate
            var start = checkInMap[id];
            var route = string.Concat(start.stationName, "-", stationName);
            var duration = t - start.startTime;

            // create or retrieve an exit record and update
            var end = checkOutMap.GetValueOrDefault(route, (0, 0));
            checkOutMap[route] = (end.Item1 + duration, end.Item2 + 1);

            // we don't need this anymore
            checkInMap.Remove(id);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            var route = string.Concat(startStation, "-", endStation);

            // check if anyone has finished this route and calculate the average
            if (checkOutMap.ContainsKey(route))
            {
                return (double)checkOutMap[route].duration / checkOutMap[route].trips;
            }
            else
            {
                return 0;
            }
        }
    }

    /*
     * Your UndergroundSystem object will be instantiated and called as such:
     * UndergroundSystem obj = new UndergroundSystem();
     * obj.CheckIn(id,stationName,t);
     * obj.CheckOut(id,stationName,t);
     * double param_3 = obj.GetAverageTime(startStation,endStation);
     */
}
