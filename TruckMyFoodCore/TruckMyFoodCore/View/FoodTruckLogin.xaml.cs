using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckMyFoodCore.Model.Users;
using TruckMyFoodCore.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckMyFoodCore.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FoodTruckLogin : ContentPage
	{
        private FoodTruckLoginViewModel foodTruckLoginVM;

        public FoodTruckLogin ()
		{
			InitializeComponent ();

            this.foodTruckLoginVM = new FoodTruckLoginViewModel();
		}

        private void CreateFoodTruckAccount(Object sender, EventArgs arngs)
        {
            Navigation.PushModalAsync(new FoodTruckRegisterPage());
        }

        private void BackToUserLoginPage(Object sender, EventArgs args)
        {
            App.Current.MainPage = new UserLoginPage();
        }

        private void LogUser(Object sender, EventArgs arngs)
        {
            if (IsvalidUser() == true)
            {
                var foodTruck = new FoodTruck()
                {
                    Cnpj = Cnpj.Text,
                    Password = Password.Text
                };

                if (this.foodTruckLoginVM.LogFoodTruck(foodTruck) == true)
                {
                    App.Current.MainPage = new NavigationPage(new FoodTruckOwnerPage(foodTruck));
                }
                else
                {
                    DisplayAlert("Alerta", "Usuário ou senha errados.", "OK");
                }
            }
        }

        private bool IsvalidUser()
        {
            if (Cnpj.Text == null) { DisplayAlert("Alerta", "O Cnpj está vazio", "OK"); return false; }
            if (Password.Text == null) { DisplayAlert("Alerta", "O senha está vazia", "OK"); return false; }

            return true;
        }
    }
}