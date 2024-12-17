using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservation
{
    public class Restaurant
    {
        
        public string name {  get; set; }
        public RestaurantTable[] tables = new RestaurantTable[100];
    }
}
