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
	public partial class FoodTruckRegisterPage : ContentPage
	{
		public FoodTruckRegisterPage ()
		{
			InitializeComponent ();
		}

        private void CloseModal(Object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        private void CreateUser(Object sender, EventArgs arngs)
        {
            App.Current.MainPage = new NavigationPage(new FoodTruckOwnerPage());
        }
    }
}