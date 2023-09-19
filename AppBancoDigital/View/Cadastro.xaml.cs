using AppBancoDigital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppBancoDigital.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Security.Cryptography;

namespace AppBancoDigital.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cadastro : ContentPage
	{
		public Cadastro ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            carregando.Color = Color.White;

			dtpck_data_nascimento.MaximumDate = DateTime.Today; 
        }

        private async void btn_cadastrar_Clicked(object sender, EventArgs e)
        {
			try
			{
                carregando.IsRunning = true;

                string[] cpf_pontuado = cpf.Text.Split('.', '-');
                string cpf_digitado = cpf_pontuado[0] + cpf_pontuado[1] + cpf_pontuado[2] + cpf_pontuado[3];

                string senha_digitada = senha.Text;
                string senha_sha1;
                using (var sha1 = new SHA1Managed())
                {
                    senha_sha1 = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(senha_digitada)));
                    senha_sha1 = string.Join("", senha_sha1.ToLower().Split('-'));
                }

                Correntista c = await DataServiceCorrentista.CadastrarCorrentista(new Correntista
				{
					Nome = usuario.Text,
					Email = email.Text,
					Data_nasc = dtpck_data_nascimento.Date,
					Cpf = cpf_digitado,
					Senha = senha.Text,
					Data_cadastro = DateTime.Now,
				});

				if (c != null)
				{
					App.DadosCorrentista = c;

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
					throw new Exception("Erro ao realizar cadastro");
				}
			}
			catch(Exception err) 
			{
				await DisplayAlert(err.Message, err.StackTrace, "OK");
			}
			finally
			{
                carregando.IsRunning = false;
            }
        }
    }
}