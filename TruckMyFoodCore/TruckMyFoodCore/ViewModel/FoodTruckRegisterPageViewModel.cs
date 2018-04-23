using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Infrastructure;
using TruckMyFoodCore.Model.Users;

namespace TruckMyFoodCore.ViewModel
{
    public class FoodTruckRegisterPageViewModel
    {
        private FoodTruckDatabase foodTruckDatabase;

        public FoodTruckRegisterPageViewModel()
        {
            this.foodTruckDatabase = new FoodTruckDatabase();
        }

        public bool RegisterFoodTruck(FoodTruck foodTruck)
        {
            return this.foodTruckDatabase.IsertUser(foodTruck);
        }
    }
}
