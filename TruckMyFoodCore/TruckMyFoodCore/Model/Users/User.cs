using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TruckMyFoodCore.Model.Users
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
