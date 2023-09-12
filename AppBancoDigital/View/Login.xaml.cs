using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppBancoDigital.Model;
using AppBancoDigital.Service;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            carregando.Color = Color.White;
        }

        private async void btn_entrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                string[] cpf_pontuado = usuario.Text.Split('.', '-');
                string cpf_digitado = cpf_pontuado[0] + cpf_pontuado[1] + cpf_pontuado[2] + cpf_pontuado[3];
                string senha_digitada = senha.Text;


                string senha_sha1;
                using (var sha1 = new SHA1Managed())
                {
                    senha_sha1 = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(senha_digitada)));
                    senha_sha1 = string.Join("", senha_sha1.ToLower().Split('-'));
                }

                Correntista c = await DataServiceCorrentista.AutenticarCorrentista(new Correntista
                {
                    Cpf = cpf_digitado,
                    Senha = senha_sha1
                });

                if (c != null)
                {
                    Application.Current.Properties.Add("usuario_logado", cpf_digitado);
                    Application.Current.Properties.Add("usuario_senha", senha_sha1);
                    await Application.Current.SavePropertiesAsync();

                    App.Current.MainPage = new NavigationPage(new MainPage()
                    {
                        BindingContext = c
                    });
                }
                else
                {
                    DisplayAlert("Erro", "Dados incorretos!", "OK");
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }

        private void btn_esqueci_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new NavigationPage(new View.EsqueciSenha());
        }

        private void btn_cadastrar_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Cadastro());
            Navigation.PushAsync(new NavigationPage(new Cadastro()));
        }
    }
}