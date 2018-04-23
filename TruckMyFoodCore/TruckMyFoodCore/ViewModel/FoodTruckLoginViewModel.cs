using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Infrastructure;
using TruckMyFoodCore.Model.Users;

namespace TruckMyFoodCore.ViewModel
{
    public class FoodTruckLoginViewModel
    {
        private FoodTruckDatabase foodTruckDatabase;

        public FoodTruckLoginViewModel()
        {
            this.foodTruckDatabase = new FoodTruckDatabase();
        }

        public bool LogFoodTruck(FoodTruck foodTruck)
        {
            var registredFoodTruck = foodTruckDatabase.GetFoodTruck(foodTruck.Cnpj);

            if (registredFoodTruck == null) { return false; }
            if (String.Equals(foodTruck.Password, registredFoodTruck.Password) == false) { return false; }

            return true;
        }

        public FoodTruck GetFoodTruck(string cnpj)
        {
            return this.foodTruckDatabase.GetFoodTruck(cnpj);
        }
    }
}
