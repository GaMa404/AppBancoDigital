using AppBancoDigital.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppBancoDigital
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Conta)));

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void botao_logout_Clicked(object sender, EventArgs e)
        {
            bool confirmar = await DisplayAlert("Sair", "Tem certeza que quer sair?", "Sim", "Não");

            if (confirmar)
            {
                App.Current.Properties.Remove("usuario_logado");
                App.Current.MainPage = new Login();
            }
        }
    }
}
