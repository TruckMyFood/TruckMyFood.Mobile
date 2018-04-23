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
	public partial class FoodTruckOwnerInformation : ContentPage
	{
        private FoodTruckOwnerInformationViewModel foodTruckOwnerInformationVM;
        private FoodTruck foodTruck;

		public FoodTruckOwnerInformation (FoodTruck foodTruck)
		{
			InitializeComponent ();

            this.foodTruck = foodTruck;
            this.foodTruckOwnerInformationVM = new FoodTruckOwnerInformationViewModel();

            BindingContext = foodTruckOwnerInformationVM.GetInformations(foodTruck.Cnpj);
        }

        public void Cancel(Object sender, EventArgs args)
        {
            Navigation.PopAsync();
        }

        public void SaveChanges(Object sender, EventArgs args)
        {
            var newInformations = new FoodTruck()
            {
                TradingName = TradingName.Text,
                Cnpj = this.foodTruck.Cnpj,
                Email = Email.Text,
                FoodTruckSpeciality = FoodTruckSpeciality.Text,
                Descrption = Descrption.Text
            };

            this.foodTruckOwnerInformationVM.UpdateInformations(newInformations);
        }
    }
}