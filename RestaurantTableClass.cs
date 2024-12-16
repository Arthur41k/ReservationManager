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
        private List<DateTime> bookDates; 

        
        public bool Book(DateTime date)
        {
            try
            {
                //перевірка на наявність бронювання
                if (bookDates.Contains(date))
                {
                    return false;
                }
                else
                {
                    //бронювання
                    bookDates.Add(date);
                    return true;
                }
            }
            catch (Exception IncorrectDateFormat)
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
            catch (Exception IncorrectDateFormat)
            {
                Console.WriteLine("Неправильний формат дати");
                return false;
            }
        }
    }
}
