using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Infrastructure;
using Android.Locations;
using TruckMyFoodCore.Service;
using Plugin.Geolocator.Abstractions;
using TruckMyFoodCore.Model.Users;

namespace TruckMyFoodCore.ViewModel
{
    public class FoodTruckListViewModel
    {
        private FoodTruckDatabase foodTruckDatabase;

        public FoodTruckListViewModel()
        {
            this.foodTruckDatabase = new FoodTruckDatabase();
        }

        public List<FoodTruck> GetFoodTruckList()
        {
            return this.foodTruckDatabase.GetOpenFoodTrucks();
        }

        public Position GetCurrentUserPosition()
        {
            return GpsLocator.GetCurrentPosition().GetAwaiter().GetResult();
        }
    }
}
