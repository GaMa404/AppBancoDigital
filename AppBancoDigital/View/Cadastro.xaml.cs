﻿using AppBancoDigital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppBancoDigital.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        }

        private async void btn_cadastrar_Clicked(object sender, EventArgs e)
        {
			try
			{
                carregando.IsRunning = true;

                string[] cpf_pontuado = cpf.Text.Split('.', '-');
                string cpf_digitado = cpf_pontuado[0] + cpf_pontuado[1] + cpf_pontuado[2] + cpf_pontuado[3];

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

                    App.Current.Properties.Add("usuario_logado", cpf_digitado);
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