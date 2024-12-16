using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservation
{
    public class RestaurantTableClass
    {
        private List<DateTime> bd; //booked dates


        public RestaurantTableClass()
        {
            bd = new List<DateTime>();
        }

        // book
        public bool Book(DateTime d)
        {
            try
            {
                if (bd.Contains(d))
                {
                    return false;
                }
                //add to bd
                bd.Add(d);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                return false;
            }
        }

        // is booked
        public bool IsBooked(DateTime d)
        {
            return bd.Contains(d);
        }
    }
}
