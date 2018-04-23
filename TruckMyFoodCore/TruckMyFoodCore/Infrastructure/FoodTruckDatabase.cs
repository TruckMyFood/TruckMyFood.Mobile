using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckMyFoodCore.Model.Users;
using Xamarin.Forms;

namespace TruckMyFoodCore.Infrastructure
{
    public class FoodTruckDatabase
    {
        private SQLiteConnection conection;

        public FoodTruckDatabase()
        {
            var dependecyService = DependencyService.Get<IDeviceConnection>();
            string path = dependecyService.GetDatabasePath("database.sqlite");

            conection = new SQLiteConnection(path);
            conection.CreateTable<FoodTruck>();

            this.MockUsers();
        }

        private void MockUsers()
        {
            foreach (var user in new MockUsers().MockFoodTrucks())
            {
                this.IsertUser(user);
            }
        }

        public FoodTruck GetFoodTruck(string cnpj)
        {
            return conection.Table<FoodTruck>().Where(a => a.Cnpj == cnpj).FirstOrDefault();
        }

        public bool IsertUser(FoodTruck foodTruck)
        {
            var registredUser = this.GetFoodTruck(foodTruck.Cnpj);

            if(registredUser == null)
            {
                conection.Insert(foodTruck);
                return true;
            }
            if (this.IsMockedUser(foodTruck.Cnpj) == true) { return true; }
            return false;
        }

        private bool IsMockedUser(string cnpj)
        {
            return cnpj == "11111111111111" ||
                   cnpj == "22222222222222" ||
                   cnpj == "33333333333333" ||
                   cnpj == "44444444444444" ||
                   cnpj == "55555555555555" ||
                   cnpj == "66666666666666";
        }

        public void UpdateFoodtruck(FoodTruck foodTruck)
        {
            conection.Update(foodTruck);
        }

        public List<FoodTruck> GetOpenFoodTrucks()
        {
            return conection.Table<FoodTruck>().Where(a => a.IsOpen == true).ToList();
        }
    }
}
