using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckMyFoodCore.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckMyFoodCore.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FoodTruckList : ContentPage
	{
        private FoodTruckListViewModel foodTruckListViewModel;
        public FoodTruckList ()
		{
			InitializeComponent ();

            this.foodTruckListViewModel = new FoodTruckListViewModel();
            
            FoodTruckDetailList.ItemsSource = this.foodTruckListViewModel.GetFoodTruckList();
        }

        public void ShowFoodTruckMap(Object sender, EventArgs args)
        {
            Navigation.PushAsync(new FoodTruckMap());
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