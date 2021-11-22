
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
    public partial class MainAutorizedPage : TabbedPage
    {
        public MainAutorizedPage()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            //return base.OnBackButtonPressed();
            return true;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (App.Current.Properties.ContainsKey("IsLogged"))
            {
                if (App.Current.Properties["IsLogged"].ToString() == "true")
                {
                    App.Current.MainPage = new MainPage();
                }
                else
                    await Navigation.PushModalAsync(new Pages.login(), true);
            }
            else
                await Navigation.PushModalAsync(new Pages.login(), true);




            /*var availability = await
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
                //await DisplayAlert("Уведомление", "юхууу", "Ок");

                await Navigation.PushModalAsync(new Pages.login());
            }*/



        }




    }
}