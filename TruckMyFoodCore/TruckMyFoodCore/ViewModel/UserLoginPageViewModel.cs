using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Infrastructure;
using TruckMyFoodCore.Model.Users;

namespace TruckMyFoodCore.ViewModel
{
    public class UserLoginPageViewModel
    {
        private UserDatabase userDB;

        public UserLoginPageViewModel()
        {
            this.userDB = new UserDatabase();
        }

        public bool LogUser(User user)
        {
            var registredUser = userDB.GetUser(user.Email);

            if(registredUser == null) { return false; }
            if(String.Equals(user.Password, registredUser.Password) == false) { return false; }

            return true;
        }
    }
}
