using SqlFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Health.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
            
        }

        protected override void OnDisappearing()
        {
            NavigationPage.SetHasBackButton(this, false);
        }
        protected override bool OnBackButtonPressed()
        {
            //return base.OnBackButtonPressed();
            return true;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            btnAuth.Clicked += Auth_Clicked;

            

        }

        private  void Finger_Clicked(object sender, EventArgs e)
        {
           /* var availability = await
                CrossFingerprint.Current.IsAvailableAsync();
            if (!availability)
            {
                await DisplayAlert("Уведомление", "Нельзя", "Ок");
                return;
            }
            var authResult = await CrossFingerprint.Current.AuthenticateAsync(new
                AuthenticationRequestConfiguration("Салам", "использую биометрию"));
            if (authResult.Authenticated)
            {
                await DisplayAlert("Уведомление", "юхууу", "Ок");
            }
          */
                
                
               
        }

        private async void Auth_Clicked(object sender, EventArgs e)
        {
            if (SqlF.LoginUser(txtLogin.Text, txtPass.Text))
            {
                //await DisplayAlert("Уведомление", "Авторизованы", "Ок");
                App.Current.Properties["IsLogged"] = "true";
                App.Current.MainPage = new MainPage();

            }


            else
                await DisplayAlert("Уведомление", "Неверный логин или пароль", "Ок");

        }

        private async void TapGestureRecognizer_Tapped_Reg(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Registration());
        }
    }
}