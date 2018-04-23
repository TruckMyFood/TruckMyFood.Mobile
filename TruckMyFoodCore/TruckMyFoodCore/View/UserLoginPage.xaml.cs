using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckMyFoodCore.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserLoginPage : ContentPage
	{
		public UserLoginPage ()
		{
			InitializeComponent ();
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
            App.Current.MainPage = new NavigationPage(new FoodTruckList());
        }
    }
}