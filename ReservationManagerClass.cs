using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservation
{
    public class ReservationManagerClass
    {
            // res
            public List<Restaurant> res;

            public ReservationManagerClass()
            {
                res = new List<Restaurant>();
            }

            // Add Restaurant Method
            public void AddRestaurantMethod(string n, int t)
            {
                try
                {
                    Restaurant r = new Restaurant();
                    r.name = n;
                    r.tables = new RestaurantTable[t];
                    for (int i = 0; i < t; i++)
                    {
                        r.tables[i] = new RestaurantTable();
                    }
                    res.Add(r);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }
            }

            // Load Restaurants From
            // File
            private void LoadRestaurantsFromFileMethod(string fileP)
            {
                try
                {
                    string[] ls = File.ReadAllLines(fileP);
                    foreach (string l in ls)
                    {
                        var parts = l.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int tableCount))
                        {
                            AddRestaurantMethod(parts[0], tableCount);
                        }
                        else
                        {
                            Console.WriteLine(l);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }
            }

            //Find All Free Tables
            public List<string> FindAllFreeTables(DateTime dt)
            {
                try
                {
                    List<string> free = new List<string>();
                    foreach (var r in res)
                    {
                        for (int i = 0; i < r.tables.Length; i++)
                        {
                            if (!r.tables[i].IsBooked(dt))
                            {
                                free.Add($"{r.name} - Table {i + 1}");
                            }
                        }
                    }
                    return free;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    return new List<string>();
                }
            }

            public bool BookTable(string rName, DateTime d, int tNumber)
            {
                foreach (var r in res)
                {
                    if (r.name == rName)
                    {
                        if (tNumber < 0 || tNumber >= r.tables.Length)
                        {
                            throw new Exception(null); //Invalid table number
                        }

                        return r.tables[tNumber].Book(d);
                    }
                }

                throw new Exception(null); //Restaurant not found
            }

            public void SortRestaurantsByAvailabilityForUsersMethod(DateTime dt)
            {
                try
                {
                    bool swapped;
                    do
                    {
                        swapped = false;
                        for (int i = 0; i < res.Count - 1; i++)
                        {
                            int avTc = CountAvailableTablesForRestaurantClassAndDateTimeMethod(res[i], dt); // available tables current
                            int avTn = CountAvailableTablesForRestaurantClassAndDateTimeMethod(res[i + 1], dt); // available tables next

                            if (avTc < avTn)
                            {
                                // Swap restaurants
                                var temp = res[i];
                                res[i] = res[i + 1];
                                res[i + 1] = temp;
                                swapped = true;
                            }
                        }
                    } while (swapped);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }
            }

            // count available tables in a restaurant
            public int CountAvailableTablesForRestaurantClassAndDateTimeMethod(Restaurant r, DateTime dt)
            {
                try
                {
                    int count = 0;
                    foreach (var t in r.tables)
                    {
                        if (!t.IsBooked(dt))
                        {
                            count++;
                        }
                    }
                    return count;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    return 0;
                }
            }
    }
}

    
