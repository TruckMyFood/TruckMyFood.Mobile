using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Infrastructure;
using TruckMyFoodCore.Model.Users;

namespace TruckMyFoodCore.ViewModel
{
    class FoodTruckOwnerInformationViewModel
    {
        private FoodTruckDatabase foodTruckDatabase;

        public FoodTruckOwnerInformationViewModel()
        {
            this.foodTruckDatabase = new FoodTruckDatabase();
        }

        public void UpdateInformations(FoodTruck newFoodtruckInformations)
        {
            this.foodTruckDatabase.UpdateFoodtruck(newFoodtruckInformations);
        }

        public FoodTruck GetInformations(string cnpj)
        {
            return this.foodTruckDatabase.GetFoodTruck(cnpj);
        }
    }
}
