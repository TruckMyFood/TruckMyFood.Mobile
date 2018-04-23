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
	public partial class UserLoginPage : ContentPage
	{
        private UserLoginPageViewModel userLoginPageVM;

        public UserLoginPage ()
		{
			InitializeComponent ();

            this.userLoginPageVM = new UserLoginPageViewModel();
		}

        private void CreateUserAccount(Object sender, EventArgs arngs)
        {
            Navigation.PushModalAsync(new UserRegisterPage());
        }

        private void LoginWithFoodTruckAccount(Object sender, EventArgs arngs)
        {
            App.Current.MainPage = new FoodTruckLogin();
        }

        private void LogUser(Object sender, EventArgs arngs)
        {
            if(IsvalidUser() == true)
            {
                var user = new User()
                {
                    Email = Email.Text,
                    Password = Password.Text
                };

                if (this.userLoginPageVM.LogUser(user) == true)
                {
                    App.Current.MainPage = new NavigationPage(new FoodTruckList());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuário ou senha errados.", "OK");
                }
            }
        }

        private bool IsvalidUser()
        {
            if(Email.Text == null) { DisplayAlert("Alerta", "O email está vazio", "OK"); return false; }
            if(Password.Text == null) { DisplayAlert("Alerta", "O senha está vazia", "OK"); return false; }

            return true;
        }
    }
}