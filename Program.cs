
using System;
using System.Collections.Generic;


namespace TableReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReservationManager manager = new ReservationManager();
            manager.AddRestaurant("A", 10);
            manager.AddRestaurant("B", 5);

           Console.WriteLine(manager.ReservationTable("A", new DateTime(2023, 12, 25), 3)); // True
           Console.WriteLine(manager.ReservationTable("A", new DateTime(2023, 12, 25), 3)); // False
        }
    }
}
