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
	public partial class FoodTruckRegisterPage : ContentPage
	{
        private FoodTruckRegisterPageViewModel foodTruckRegisterPageVM;

        public FoodTruckRegisterPage ()
		{
			InitializeComponent ();

            this.foodTruckRegisterPageVM = new FoodTruckRegisterPageViewModel();

        }

        private void CloseModal(Object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        private void CreateUser(Object sender, EventArgs arngs)
        {
            if (this.IsValidUser())
            {
                var foodTruck = new FoodTruck()
                {
                    TradingName = TradingName.Text,
                    Cnpj = Cnpj.Text,
                    Email = Email.Text,
                    Password = Password.Text,
                    Descrption = "",
                    FoodTruckSpeciality = "",
                    IsOpen = false,
                    Latitude = 0,
                    Longitude = 0
                };

                var success = this.foodTruckRegisterPageVM.RegisterFoodTruck(foodTruck);

                if(success == true)
                {
                    DisplayAlert("Mensagem", "Bem vindo ao Truck My Food!", "OK");

                    App.Current.MainPage = new NavigationPage(new FoodTruckOwnerPage(foodTruck));
                }

                DisplayAlert("Alerta", "Food Truck já cadastrado, tente fazer o login.", "OK");
            }
        }

        private bool IsValidUser()
        {
            if (TradingName.Text == null) { DisplayAlert("Alerta", "O nome fantasia não pode estar vazio.", "OK"); return false; }

            if (Cnpj.Text == null) { DisplayAlert("Alerta", "O CNPJ é obrigatório.", "OK"); return false; }

            if (Cnpj.Text.Trim().Length != 14) { DisplayAlert("Alerta", "O CNPJ invalido.", "OK"); return false; }

            if (Email.Text.Contains("@") == false || Email.Text.Contains(".com") == false)
            {
                DisplayAlert("Alerta", "O email está incorreto.", "OK");
                return false;
            }

            if (Password.Text.Length < 6) { DisplayAlert("Alerta", "A senha deve conter pelo menos 6 caracteres.", "OK"); return false; }

            if (String.Equals(Password.Text, ConfirmedPassword.Text) == false)
            {
                DisplayAlert("Alerta", "As senahs não são idênticas.", "OK");
                return false;
            }

            return true;
        }
    }
}