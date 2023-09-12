using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDigital.Service
{
    public class DataServiceConta : DataService
    {
        public static async Task<Conta> BuscarDadosConta(Conta ct)
        {
            var json_a_enviar = JsonConvert.SerializeObject(ct);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/conta");

            if (json == "false")
                return null;

            Conta conta = JsonConvert.DeserializeObject<Conta>(json);

            return conta;
        }
    }
}
