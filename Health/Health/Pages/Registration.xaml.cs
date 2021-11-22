
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
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
            btnReg.Clicked += Reg_Clicked;
        }

        private void Reg_Clicked(object sender, EventArgs e)
        {
            if (txtPass.Text == txtRetryPass.Text)
            {
                if (SqlF.RegUser(txtLogin.Text, txtPass.Text, txtEmail.Text))
                {
                    DisplayAlert("Уведомление", "Вы успешно зарегистрированы", "Ок");
                }
            }
            else
                DisplayAlert("Уведомление", "Пароли не совпадают", "Ок");

        }

        private async void TapGestureRecognizer_Tapped_Auth(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pages.login());
        }


    }
}