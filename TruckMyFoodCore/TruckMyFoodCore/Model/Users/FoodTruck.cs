using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TruckMyFoodCore.Model.Users
{
    [Table("FoodTruck")]
    public class FoodTruck
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string TradingName { get; set; }

        public string Cnpj { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FoodTruckSpeciality { get; set; }

        public string Descrption { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool IsOpen { get; set; }

        public string FormattedCnpj
        {
            get
            {
                return Convert.ToUInt64(this.Cnpj).ToString(@"00\.000\.000\/0000\-00");
            }
        }
    }
}
