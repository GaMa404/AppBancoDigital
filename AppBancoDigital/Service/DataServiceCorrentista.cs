using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AppBancoDigital.Model;

namespace AppBancoDigital.Service
{
    public class DataServiceCorrentista : DataService
    {
        public static async Task<Correntista> AutenticarCorrentista(Correntista c)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/entrar");

            if (json == "false")
                return null;

            Correntista correntista = JsonConvert.DeserializeObject<Correntista>(json);

            return correntista;
        }

        public static async Task<Correntista> CadastrarCorrentista(Correntista c)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);
            
            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/salvar");

            return JsonConvert.DeserializeObject<Correntista>(json);
        }
    }
}
