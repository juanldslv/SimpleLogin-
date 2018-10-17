using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Patagoniaar;
using Xamarin.Forms;

namespace Patagoniaarg
{
    public class LoginViewModel : BaseViewModel
    {

        public ICommand LoginCommand { get; set; }
        public INavigation Navigation;

        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public LoginViewModel(INavigation nav)
        {
            Navigation = nav;
            IsBusy = false;
            LoginCommand = new Command(Login);
        }
        public async void Login()
        {

            IsBusy = true;

            try
            {
                if (Username != null)
                {
                    if (Password != null)
                    {
                        var mongoservice = new MongoService();
                        var response = await mongoservice.GetUserByUserName(Username);
                        if (response == null)
                        {
                            IsBusy = false;
                            Message = "El Usuario no existe";
                            await Application.Current.MainPage.DisplayAlert("Error ", "El Usuario no existe", "Ok");
                        }
                        else{
                            await Navigation.PushAsync(new MainPage());
                        }

                    }
                    else
                    {
                        IsBusy = false;
                        Message = "El Password es requerido";
                        await Application.Current.MainPage.DisplayAlert("Error ", "El Password es requerido", "Ok");

                    }


                }
                else
                {
                    IsBusy = false;
                    Message = "El Username es requerido";
                    await Application.Current.MainPage.DisplayAlert("Error ", "El Username es requerido", "Ok");
                }




            }
            finally
            {
                IsBusy = false;

            }


        }


       
    }
}
