using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TableReservation
{
    public class RestaurantTable
    {
        private List<DateTime> bookDates = new List<DateTime> (); 

        
        public bool Book(DateTime date)
        {
           try
           {
                
                if (bookDates.Contains(date))
                {
                    return false;
                }
                else
                {
                    bookDates.Add(date);
                    return true;
                }
           }
           catch (Exception exception)
           {
               Console.WriteLine("Неправильний формат дати");
                return false;
           }
        }

       
        public bool IsBooked(DateTime dateTime)
        { 
            try
            {
                return bookDates.Contains(dateTime);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Неправильний формат дати");
                return false;
            }
        }
    }
}
