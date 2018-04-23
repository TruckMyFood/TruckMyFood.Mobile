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
	public partial class FoodTruckOwnerPage : ContentPage
	{
		public FoodTruckOwnerPage ()
		{
			InitializeComponent ();
		}

        public void ChangeFoodTruckStatus(Object sender, EventArgs args)
        {
             
        }

        public void EditFoodtruckInformations(Object sender, EventArgs args)
        {
            Navigation.PushAsync(new FoodTruckOwnerInformation());
        }

        public void Logout(Object sender, EventArgs args)
        {
            App.Current.MainPage = new FoodTruckLogin();
        }
    }
}