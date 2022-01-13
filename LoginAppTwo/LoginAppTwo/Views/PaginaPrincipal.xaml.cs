using LoginAppTwo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginAppTwo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private async void Logoff_Clicked(object sender, EventArgs e)
        {
            LoginService service = new LoginService();

            if (await service.Logoff())
            {
                App.Current.MainPage = new MainPage();
            }
        }
    }
}