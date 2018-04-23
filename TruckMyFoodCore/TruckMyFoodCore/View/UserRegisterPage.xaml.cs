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
	public partial class UserRegisterPage : ContentPage
	{
        private UserRegisterPageViewModel userRegisterPageVM;

        public UserRegisterPage ()
		{
			InitializeComponent ();

            this.userRegisterPageVM = new UserRegisterPageViewModel();
		}

        private void CloseModal(Object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        private void CreateUser(Object sender, EventArgs arngs)
        {
            if(IsValidUser() == true)
            {
                var user = new User()
                {
                    Name = Name.Text,
                    Email = Email.Text,
                    Password = Password.Text
                };

                var success = this.userRegisterPageVM.RegisterNewUser(user);

                if(success == true)
                {
                    DisplayAlert("Menssagem", "Bem vindo ao Truck My Food!", "OK");

                    App.Current.MainPage = new NavigationPage(new FoodTruckList());
                }

                DisplayAlert("Alerta", "Usuário já cadastrado, tente fazer o login.", "OK");
            }
        }

        private bool IsValidUser()
        {
            if(Name.Text == null) { DisplayAlert("Alerta", "O nome não pode estar vazio.", "OK"); return false; }

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