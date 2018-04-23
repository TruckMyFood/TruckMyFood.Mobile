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
	public partial class FoodTruckLogin : ContentPage
	{
		public FoodTruckLogin ()
		{
			InitializeComponent ();
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
            App.Current.MainPage = new NavigationPage(new FoodTruckOwnerPage());
        }
    }
}