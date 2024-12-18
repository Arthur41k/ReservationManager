using TableReservation;

namespace TableReservationTest
{
    public class TableReservationTest
    {

        //Тести для методів класу RestaurantTable

        [Fact]
        public void BookTable_ReturnsTrue()
        {
           
            var table = new RestaurantTable();
            DateTime bookingDate = new DateTime(2023, 12, 25);

            
            bool result = table.Book(bookingDate);

            
            Assert.True(result);
        }

        [Fact]
        public void BookTable_ReturnsFalse()
        {
            
            var table = new RestaurantTable();
            DateTime bookingDate = new DateTime(2023, 12, 25);
            table.Book(bookingDate); 

           
            bool result = table.Book(bookingDate); 

            
            Assert.False(result);
        }

        [Fact]
        public void IsBooked_ReturnsTrue()
        {
            
            var table = new RestaurantTable();
            DateTime bookingDate = new DateTime(2023, 12, 25);
            table.Book(bookingDate);

            
            bool result = table.IsBooked(bookingDate);

            
            Assert.True(result);
        }
        
        [Fact]
        public void IsBooked_ReturnsFalse()
        {
            
            var table = new RestaurantTable();
            DateTime bookingDate = new DateTime(2023, 12, 25);

            
            bool result = table.IsBooked(bookingDate);

            
            Assert.False(result);
        }

        //Тести для методів класу ReservationManager


        [Fact]
        public void AddRestaurant_ShouldAdd()
        {
            
            string restaurantName = "KFC";
            int tableCount = 5;

           
            ReservationManager reservationManager = new ReservationManager();   
            reservationManager.AddRestaurant(restaurantName, tableCount);

            
            Assert.Single(reservationManager.restaurants);
            Assert.Equal(restaurantName, reservationManager.restaurants[0].name);
            Assert.Equal(tableCount, reservationManager.restaurants[0].tables.Length);
        }

        [Fact]
        public void LoadRestaurants_ShouldLoad()
        {
            
            ReservationManager reservationManager = new ReservationManager();
           
            string filePath = "test_restaurants.txt";
            System.IO.File.WriteAllLines(filePath, new string[] { "Restaurant1,2", "Restaurant2,3" });

            
            var loadMethod = reservationManager.GetType().GetMethod("LoadRestaurants", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            loadMethod.Invoke(reservationManager, new object[] { filePath });

            
            Assert.Equal(2, reservationManager.restaurants.Count);
            Assert.Equal("Restaurant1", reservationManager.restaurants[0].name);
            Assert.Equal(2, reservationManager.restaurants[0].tables.Length);
        }

        [Fact]
        public void FindTables_ShouldReturnFree()
        {
            ReservationManager reservationManager = new ReservationManager();

            DateTime date = new DateTime(2023, 12, 25);
            List<string> FreeTables = new List<string>  { "KFC - Table 1", "KFC - Table 2", "KFC - Table 3", "KFC - Table 4", "KFC - Table 5" };
            string restaurantName = "KFC";
            int tableCount = 5;

            reservationManager.AddRestaurant(restaurantName, tableCount);


            Assert.Equal(FreeTables, reservationManager.FindTables(date));

        }

        [Fact]
        public void ReservationTable_ShouldBookTableAndReturnTrue_ThenReturnFalse()
        {
            ReservationManager reservationManager = new ReservationManager();
            DateTime date = new DateTime(2023, 12, 25);
            string restaurantName = "KFC";
            bool firstBook = true;
            bool secondBook = false;
            int tableNumber = 3;

            reservationManager.AddRestaurant(restaurantName, 5);
            bool Reservation = reservationManager.ReservationTable(restaurantName, date, tableNumber);
            Assert.Equal(firstBook, Reservation);
            Assert.Equal(secondBook, reservationManager.ReservationTable(restaurantName, date, tableNumber));


        }

        [Fact]
        public void SortRestaurants_ShouldSortByAvailableTables()
        {
            ReservationManager reservationManager = new ReservationManager();
            
            DateTime date = new DateTime(2023, 12, 25);

            reservationManager.AddRestaurant("KFC", 5);
            reservationManager.ReservationTable("KFC", date, 0); 

            reservationManager.AddRestaurant("McDonalds", 10);
            reservationManager.ReservationTable("McDonalds", date, 0);

            
            reservationManager.SortRestaurants(date);

            
            Assert.Equal("McDonalds", reservationManager.restaurants[0].name); 
            Assert.Equal("KFC", reservationManager.restaurants[1].name);
        }

        [Fact]
        public void CountTables_ShouldReturnAvailableTableCount()
        {
            ReservationManager reservationManager = new ReservationManager();
          
            reservationManager.AddRestaurant("KFC", 3);
            DateTime date = new DateTime(2023, 12, 25);

            reservationManager.ReservationTable("KFC", date, 0); 

         
            int availableTables = 2;

          
            Assert.Equal(availableTables, reservationManager.CountTables(reservationManager.restaurants[0], date));
        }
    }
}
