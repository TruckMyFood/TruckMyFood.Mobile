using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Infrastructure;
using TruckMyFoodCore.Model.Users;
using TruckMyFoodCore.Service;
using Xamarin.Forms.Maps;

namespace TruckMyFoodCore.ViewModel
{
    public class FoodTruckMapViewModel
    {
        private GpsLocator gpsLocator;
        private FoodTruckDatabase foodTruckDatabase;

        public FoodTruckMapViewModel()
        {
            this.gpsLocator = new GpsLocator();
            this.foodTruckDatabase = new FoodTruckDatabase();
        }

        public Map CreateUserMap()
        {
            var userPosition = this.GetCurrentUserPosition();
            if(userPosition != null)
            {
                return new Map(MapSpan.FromCenterAndRadius(new Position(userPosition.Latitude, userPosition.Longitude), Distance.FromKilometers(0.5)));
            }

            return new Map(MapSpan.FromCenterAndRadius(new Position(-14.6957112, -45.6549011), Distance.FromKilometers(30)));
        }

        public bool IsLocationAvailable()
        {
            return this.gpsLocator.IsLocationAvailable();
        }

        public Plugin.Geolocator.Abstractions.Position GetCurrentUserPosition()
        {
            return GpsLocator.GetCurrentPosition().GetAwaiter().GetResult();
        }

        public List<FoodTruck> GetOpenFoodTrucks()
        {
           return foodTruckDatabase.GetOpenFoodTrucks();
        }
    }
}
