
using System;
using System.Collections.Generic;

// Main Application Class
namespace TableReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReservationManager m = new ReservationManager();
            m.AddRestaurant("A", 10);
            m.AddRestaurant("B", 5);

            Console.WriteLine(m.ReservationTable("A", new DateTime(2023, 12, 25), 3)); // True
            Console.WriteLine(m.ReservationTable("A", new DateTime(2023, 12, 25), 3)); // False
        }
    }
}
