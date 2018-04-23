using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckMyFoodCore.Model.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckMyFoodCore.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserRegisterPage : ContentPage
	{
		public UserRegisterPage ()
		{
			InitializeComponent ();
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
                    Password = Password.text
                };
                App.Current.MainPage = new NavigationPage(new FoodTruckList());
            }
        }

        private bool IsValidUser()
        {
            if(Name.Text == null) { return false; }
            if(Email.Text == null) { return false; }
            if(Password.Text.Length < 6) { return false; }
            if(String.Compare(Password.Text, ConfirmedPassword.Text) == false) { return false; }

            return true;
        }
    }
}