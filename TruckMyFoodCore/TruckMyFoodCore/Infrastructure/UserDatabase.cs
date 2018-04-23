using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Model.Users;
using Xamarin.Forms;

namespace TruckMyFoodCore.Infrastructure
{
    public class UserDatabase
    {
        private SQLiteConnection conection;

        public UserDatabase()
        {
            var dependecyService = DependencyService.Get<IDeviceConnection>();
            string path = dependecyService.GetDatabasePath("database.sqlite");

            conection = new SQLiteConnection(path);
            conection.CreateTable<User>();
        }

        public User GetUser(string email)
        {
            return conection.Table<User>().Where(a => a.Email == email).FirstOrDefault();
        }

        public void IsertUser(User user)
        {
            conection.Insert(user);
        }
    }
}
