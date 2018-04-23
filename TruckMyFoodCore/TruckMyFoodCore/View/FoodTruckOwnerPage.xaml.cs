using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckMyFoodCore.Model.Users;
using TruckMyFoodCore.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TruckMyFoodCore.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FoodTruckOwnerPage : ContentPage
	{
        private Map userMap;
        private Pin userPin;
        private FoodTruck loggedFoodTruck;
        private FoodTruckMapViewModel foodTruckMapViewModel;
        private FoodTruckOwnerPageViewModel foodTruckOwnerPageViewModel;

        public FoodTruckOwnerPage(FoodTruck foodTruck)
        {
            InitializeComponent();

            this.loggedFoodTruck = new FoodTruckLoginViewModel().GetFoodTruck(foodTruck.Cnpj);
            this.foodTruckOwnerPageViewModel = new FoodTruckOwnerPageViewModel();
            this.foodTruckMapViewModel = new FoodTruckMapViewModel();

            if (foodTruckMapViewModel.IsLocationAvailable() == false) { DisplayAlert("Alerta", "Por favor ative o GPS!", "OK"); }
            this.userMap = foodTruckMapViewModel.CreateUserMap();

            MapArea.Children.Add(userMap);
            userMap.IsShowingUser = true;

            this.ChangeFoodTruckStatusButtonColor();
            this.CreatePins();
        }

        private void CreatePins()
        {
            var foodTruckList = foodTruckMapViewModel.GetOpenFoodTrucks();

            foreach (var foodTruck in foodTruckList)
            {
                this.userMap.Pins.Add(new Pin()
                {
                    Position = new Position(foodTruck.Latitude, foodTruck.Longitude),
                    Label = foodTruck.TradingName,
                    Type = PinType.Place
                });
            }
        }

        public void ChangeFoodTruckStatus(Object sender, EventArgs args)
        {
            if (foodTruckMapViewModel.IsLocationAvailable() == false) { DisplayAlert("Alerta", "Por favor ative o GPS!", "OK"); }
            var position = foodTruckMapViewModel.GetCurrentUserPosition();

            if (loggedFoodTruck.IsOpen == false)
            {
                loggedFoodTruck.IsOpen = true;
                loggedFoodTruck.Latitude = position.Latitude;
                loggedFoodTruck.Longitude = position.Longitude;

                this.CreatePin(this.loggedFoodTruck);
            }
            else
            {
                loggedFoodTruck.IsOpen = false;

                this.RemovePin();
            }

            foodTruckOwnerPageViewModel.UpdateFoodTruck(loggedFoodTruck);

            this.ChangeFoodTruckStatusButtonColor();

            this.CreatePins();
        }

        public void CreatePin(FoodTruck foodTruck)
        {
            this.userPin = new Pin()
            {
                Position = new Position(foodTruck.Latitude, foodTruck.Longitude),
                Label = foodTruck.TradingName,
                Type = PinType.Place
            };

            this.userMap.Pins.Add(userPin);
        }

        public void RemovePin()
        {
            this.userMap.Pins.Clear();
        }
        
        public void ChangeFoodTruckStatusButtonColor()
        {
            if(loggedFoodTruck.IsOpen == true)
            {
                FoodTruckStatus.BackgroundColor = Color.OrangeRed;
                FoodTruckStatus.Text = "Fechar Meu Food Truck";
                FoodTruckStatus.TextColor = Color.White;
            }
            else
            {
                FoodTruckStatus.BackgroundColor = Color.LawnGreen;
                FoodTruckStatus.Text = "Abrir Meu Food Truck";
                FoodTruckStatus.TextColor = Color.White;
            }
        }

        public void EditFoodtruckInformations(Object sender, EventArgs args)
        {
            Navigation.PushAsync(new FoodTruckOwnerInformation(loggedFoodTruck));
        }

        public void Logout(Object sender, EventArgs args)
        {
            App.Current.MainPage = new FoodTruckLogin();
        }


    }
}