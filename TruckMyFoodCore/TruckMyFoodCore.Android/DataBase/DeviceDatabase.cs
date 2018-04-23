using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TruckMyFoodCore.Droid.DataBase;
using TruckMyFoodCore.Infrastructure;
using Xamarin.Forms;

[assembly:Dependency(typeof(DeviceDatabase))]
namespace TruckMyFoodCore.Droid.DataBase
{
    public class DeviceDatabase : IDeviceConnection
    {
        public string GetDatabasePath(string DatabaseName)
        {
            var databaseFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return Path.Combine(databaseFolder, DatabaseName);
        }
    }
}