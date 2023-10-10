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
    public partial class Cadastro2 : ContentPage
    {
        public Cadastro2()
        {
            InitializeComponent();
        }

        private void btn_proximo_Clicked(object sender, EventArgs e)
        {
            /*if (txt_nome.Text != null)
                Navigation.PushAsync(new Cadastro3());
            else
                DisplayAlert("Erro", "Digite seu nome", "OK");*/
        }
    }
}