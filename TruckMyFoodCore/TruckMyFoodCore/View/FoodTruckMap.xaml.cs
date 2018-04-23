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
	public partial class FoodTruckMap : ContentPage
	{
		public FoodTruckMap ()
		{
			InitializeComponent ();
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