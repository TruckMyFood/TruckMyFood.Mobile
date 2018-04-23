using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Infrastructure;
using TruckMyFoodCore.Model.Users;

namespace TruckMyFoodCore.ViewModel
{
    public class FoodTruckOwnerPageViewModel
    {
        private FoodTruckDatabase foodTruckDatabase;

        public FoodTruckOwnerPageViewModel()
        {
            this.foodTruckDatabase = new FoodTruckDatabase();
        }

        public void UpdateFoodTruck(FoodTruck loggedFoodTruck)
        {
            this.foodTruckDatabase.UpdateFoodtruck(loggedFoodTruck);
        }
    }
}
