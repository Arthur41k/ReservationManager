using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservation
{
    public class ReservationManager
    {
           
            public List<Restaurant> restaurants;

            
            public void AddRestaurant(string Name, int Tables)
            {
                try
                {
                    Restaurant restaurant = new Restaurant();
                    restaurant.name = Name;
                    restaurant.tables = new RestaurantTable[Tables];
                    for (int i = 0; i < Tables; i++)
                    {
                        restaurant.tables[i] = new RestaurantTable();
                    }
                restaurants.Add(restaurant);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Невдалося додати ресторан");
                }
            }

           
            private void LoadRestaurants(string filePath)
            {
                try
                {
                    string[] LoadStrings = File.ReadAllLines(filePath);
                    foreach (string lString in LoadStrings)
                {
                        var parts = lString.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int tableCount))
                        {
                            AddRestaurant(parts[0], tableCount);
                        }
                        else
                        {
                            Console.WriteLine(lString);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Невдалося зчитати дані");
                }
            }

            
            public List<string> FindTables(DateTime dateTime)
            {
                try
                {
                    List<string> FreeTables = new List<string>();
                    foreach (var restaurant in restaurants)
                    {
                        for (int i = 0; i < restaurant.tables.Length; i++)
                        {
                            if (!restaurant.tables[i].IsBooked(dateTime))
                            {
                            FreeTables.Add($"{restaurant.name} - Table {i + 1}");
                            }
                        }
                    }
                    return FreeTables;
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Столики не знайдено");
                    return new List<string>();
                }
            }

            public bool ReservationTable(string restaurantName, DateTime date, int tableNumber)
            {
                foreach (var r in restaurants)
                {
                    if (r.name == restaurantName)
                    {
                        if (tableNumber < 0 || tableNumber >= r.tables.Length)
                        {
                            throw new Exception(null); 
                        }

                        return r.tables[tableNumber].Book(date);
                    }
                }

                throw new Exception(null); 
            }

            public void SortRestaurants(DateTime Date)
            {
                try
                {
                    bool swapped;
                    do
                    {
                        swapped = false;
                        for (int i = 0; i < restaurants.Count - 1; i++)
                        {
                            int AvailableTabCurrent = CountTables(restaurants[i], Date); 
                            int AvailableTabNext = CountTables(restaurants[i + 1], Date);

                            if (AvailableTabCurrent < AvailableTabNext)
                            {
                                
                                var temp = restaurants[i];
                                restaurants[i] = restaurants[i + 1];
                                restaurants[i + 1] = temp;
                                swapped = true;
                            }
                        }
                    } while (swapped);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Невдалося відсортувати ресторани");
                }
            }

            
            public int CountTables(Restaurant restaurant, DateTime date)
            {
                try
                {
                    int count = 0;
                    foreach (var Table in restaurant.tables)
                    {
                        if (!Table.IsBooked(date))
                        {
                            count++;
                        }
                    }
                    return count;
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Невдалося підрахувати кількість столів");
                    return 0;
                }
            }
    }
}

    
