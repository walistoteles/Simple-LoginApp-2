using LoginAppTwo.Models;
using LoginAppTwo.Services;
using LoginAppTwo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginAppTwo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            LoginAutomatic();

            base.OnAppearing();
        }
        public async void LoginAutomatic()
        {

            LoginService service = new LoginService();

            if (await service.LoginAutomatic())
            {
                App.Current.MainPage = new NavigationPage(new PaginaPrincipal());

            }
            else
            {
                //

            }
        }



        private async void Login_Clicked(object sender, EventArgs e)
        {
            LoginService service = new LoginService();
            User user = new User
            {
                UserName = username.Text,
                Password = password.Text
            };

            bool r = await service.Login(user);

            if (r)
            {
                await DisplayAlert("Sucess", "LOGADO com sucesso senhor " + user.UserName, "Ok");
                App.Current.MainPage = new NavigationPage(new PaginaPrincipal());
            }
            else
            {
                await DisplayAlert("Error", "Algo deu errado!", "Ok");

            }

        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            LoginService service = new LoginService();
            User user = new User
            {
                UserName = username.Text,
                Password = password.Text
            };

            bool r = await service.Register(user);
            if (r)
            {
                await DisplayAlert("Sucess", "Registrado com sucesso senhor " + user.UserName, "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Algo deu errado!", "Ok");

            }


        }
    }
}
