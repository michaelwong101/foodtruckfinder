using System;
using System.Collections.Generic;
using System.Linq;

using SODA;

namespace foodtruckfinder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get set up data and get data.
            var client = new SodaClient("https://data.sfgov.org", "tOvbugsbjxkiUpNOfwfNmz4Sk");           
            string[] columns = { "dayoftheweekstr", 
                                 "starttime", 
                                 "endtime", 
                                 "location", 
                                 "locationdesc", 
                                 "applicant", 
                                 "longitude", 
                                 "latitude" 
            };
            var soql = new SoqlQuery().Select(columns);
            var dataset = client.GetResource<FoodTruck>("jjew-r69b");
            var results = dataset.GetRows(limit: 5000);

            List<FoodTruck> openTrucks = (from FoodTruck item in results
                                          where item.IsOpen(DateTime.Now)
                                          select item).ToList();
            openTrucks.Sort();

            // Queue is for paging results.
            Queue<FoodTruck> queueTrucks = new Queue<FoodTruck>(openTrucks);
            Console.WriteLine(openTrucks.Count + " trucks open at " + DateTime.Now.ToString());
            Console.WriteLine("NAME - LOCATION");
            while(queueTrucks.Count > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    if(queueTrucks.Count == 0){
                        break;
                    }
                    queueTrucks.Dequeue().Display();
                }
                Console.ReadKey();
            }

            Console.WriteLine("End of list.");
            Console.ReadKey();
        }
    }
}
