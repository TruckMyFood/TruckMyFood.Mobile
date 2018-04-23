using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Model.Users;

namespace TruckMyFoodCore.Infrastructure
{
    public class MockUsers
    {
        public List<User> MockLoginUsers()
        {
            var userList = new List<User>();

            userList.Add(new User(){ Email = "teste@teste.com", Password = "123456", Name = "Tester" });
            userList.Add(new User(){ Email = "teste1@teste.com", Password = "123456", Name = "Tester" });
            userList.Add(new User(){ Email = "teste2@teste.com", Password = "123456", Name = "Tester" });
            userList.Add(new User(){ Email = "teste3@teste.com", Password = "123456", Name = "Tester" });

            return userList;
        }

        public List<FoodTruck> MockFoodTrucks()
        {
            var foodTruckList = new List<FoodTruck>();

            foodTruckList.Add(new FoodTruck() { Email = "teste@teste.com", Password = "123456", TradingName = "Cyd Hamburgueria", Cnpj = "11111111111111", FoodTruckSpeciality = "Hamburgueria", IsOpen = true, Latitude = -23.2863843, Longitude = -47.2895351 });
            foodTruckList.Add(new FoodTruck() { Email = "teste@teste.com", Password = "123456", TradingName = "Don Pacco Pizza", Cnpj = "22222222222222", FoodTruckSpeciality = "Pizza no cone", IsOpen = true, Latitude = -23.2879277, Longitude = -47.2967258 });
            foodTruckList.Add(new FoodTruck() { Email = "teste@teste.com", Password = "123456", TradingName = "Dogão da Tia", Cnpj = "33333333333333", FoodTruckSpeciality = "Cachorro quente", IsOpen = true, Latitude = -23.2910074, Longitude = -47.2982519 });
            foodTruckList.Add(new FoodTruck() { Email = "teste@teste.com", Password = "123456", TradingName = "Los Pollos locos", Cnpj = "44444444444444", FoodTruckSpeciality = "Mexicana", IsOpen = true, Latitude = -23.2857364, Longitude = -47.2942156 });
            foodTruckList.Add(new FoodTruck() { Email = "teste@teste.com", Password = "123456", TradingName = "Ogro Burguer", Cnpj = "55555555555555", FoodTruckSpeciality = "Hamburgueria", IsOpen = true, Latitude = -23.2923971, Longitude = -47.2936245 });
            foodTruckList.Add(new FoodTruck() { Email = "teste@teste.com", Password = "123456", TradingName = "Tenshi no Himura", Cnpj = "66666666666666", FoodTruckSpeciality = "Japonesa", IsOpen = true, Latitude = -23.2917467, Longitude = -47.2898265 });

            return foodTruckList;
        }
    }
}
