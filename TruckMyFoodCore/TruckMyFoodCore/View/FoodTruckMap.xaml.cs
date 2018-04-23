using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckMyFoodCore.Model.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using TruckMyFoodCore.Service;
using TruckMyFoodCore.ViewModel;

namespace TruckMyFoodCore.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FoodTruckMap : ContentPage
	{
        private Map userMap;
        private FoodTruckMapViewModel foodTruckMapViewModel;

        public FoodTruckMap ()
		{
			InitializeComponent ();

            this.foodTruckMapViewModel = new FoodTruckMapViewModel();

            if(foodTruckMapViewModel.IsLocationAvailable() == false) { DisplayAlert("Alerta", "Por favor ative o GPS!", "OK"); }
            this.userMap = foodTruckMapViewModel.CreateUserMap();

            MapArea.Children.Add(userMap);
            userMap.IsShowingUser = true;

            this.CreatePins();
        }

        private void CreatePins()
        {
            var foodTruckList = foodTruckMapViewModel.GetOpenFoodTrucks();

            foreach(var foodTruck in foodTruckList)
            {
                this.userMap.Pins.Add(new Pin()
                {
                    Position = new Position(foodTruck.Latitude, foodTruck.Longitude),
                    Label = foodTruck.TradingName,
                    Type = PinType.Place
                });
            }
        }

        public void ShowFoodTruckList(Object sender, EventArgs args)
        {
            Navigation.PopAsync();
        }

        public void OpenFilters(Object sender, EventArgs args)
        {

        }

        public void Logout(Object sender, EventArgs args)
        {
            App.Current.MainPage = new UserLoginPage();
        }
    }
}