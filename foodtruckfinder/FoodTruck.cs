using System;

namespace foodtruckfinder
{
    public class FoodTruck:IComparable<FoodTruck>
    {
        public bool IsOpen(DateTime t)
        {
            if(dayofweekstr == t.DayOfWeek.ToString())
            {
                if(t.CompareTo(starttime) >= 0 && t.CompareTo(endtime) < 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void Display()
        {
            Console.WriteLine(applicant + " - " + location);
        }

        public int CompareTo(FoodTruck other)
        {
            return applicant.CompareTo(other.applicant);
        }

        public string dayofweekstr {get;set;}
        public DateTime starttime {get;set;}
        public DateTime endtime {get;set;}
        public string location {get;set;}
        public string locationdesc {get;set;}
        public string applicant {get;set;}
        public double latitude {get;set;}
        public double longitude {get;set;}
    }
}
