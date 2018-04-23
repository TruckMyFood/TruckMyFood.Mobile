using System;
using System.Collections.Generic;
using System.Text;
using TruckMyFoodCore.Infrastructure;
using TruckMyFoodCore.Model.Users;

namespace TruckMyFoodCore.ViewModel
{
    public class UserRegisterPageViewModel
    {
        private UserDatabase userDB;

        public UserRegisterPageViewModel()
        {
            this.userDB = new UserDatabase();
        }
        public bool RegisterNewUser(User user)
        {
            return userDB.IsertUser(user);
        }
    }
}
