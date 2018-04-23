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

            this.MockUsers();
        }
        
        private void MockUsers()
        {
            foreach(var user in new MockUsers().MockLoginUsers())
            {
                this.IsertUser(user);
            }
        }

        public User GetUser(string email)
        {
            return conection.Table<User>().Where(a => a.Email == email).FirstOrDefault();
        }

        public bool IsertUser(User user)
        {
            var registredUser = this.GetUser(user.Email);
            if (registredUser == null)
            {
                conection.Insert(user);
                return true;
            }
            if (this.IsMockedUser(user.Email) == true) { return true; }
            return false;
        }

        private bool IsMockedUser(string email)
        {
            return email == "teste@teste.com" ||
                   email == "teste1@teste.com" ||
                   email == "teste2@teste.com" ||
                   email == "teste3@teste.com";
        }
    }
}
