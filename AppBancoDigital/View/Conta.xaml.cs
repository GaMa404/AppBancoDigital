using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conta : ContentPage
    {
        public Conta()
        {
            InitializeComponent();

            propaganda.Source = ImageSource.FromResource("AppBancoDigital.Imagens.cartao.png");

            imgbtn_pix.Source = ImageSource.FromResource("AppBancoDigital.Imagens.pix_icon.png");
            imgbtn_pagar.Source = ImageSource.FromResource("AppBancoDigital.Imagens.boleto_icon.png");
            imgbtn_transferir.Source = ImageSource.FromResource("AppBancoDigital.Imagens.transferir_icon.png");
            imgbtn_depositar.Source = ImageSource.FromResource("AppBancoDigital.Imagens.depositar_icon.png");
        }

        private void imgbtn_pix_Clicked(object sender, EventArgs e)
        {

        }

        private void imgbtn_pagar_Clicked(object sender, EventArgs e)
        {

        }

        private void imgbtn_transferir_Clicked(object sender, EventArgs e)
        {

        }

        private void imgbtn_depositar_Clicked(object sender, EventArgs e)
        {

        }
    }
}