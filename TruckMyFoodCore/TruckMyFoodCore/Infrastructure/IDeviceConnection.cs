using System;
using System.Collections.Generic;
using System.Text;

namespace TruckMyFoodCore.Infrastructure
{
    public interface IDeviceConnection
    {
        string GetDatabasePath(string DatabaseName);
    }
}
