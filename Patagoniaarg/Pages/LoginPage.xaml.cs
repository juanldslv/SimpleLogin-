using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Patagoniaarg.Pages
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginPage()
        {
            
            InitializeComponent();


            BindingContext = viewModel= new LoginViewModel(Navigation); 




        }
        protected override bool OnBackButtonPressed()
        {
            // This prevents a user from being able to hit the back button and leave the login page.
            return true;
        }




    }
}
