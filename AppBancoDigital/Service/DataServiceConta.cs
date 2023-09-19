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
        public static async Task<ContaCorrentista> BuscarDadosConta(ContaCorrentista cc)
        {
            var json_a_enviar = JsonConvert.SerializeObject(cc);

            Console.WriteLine("=============================================================================");
            Console.WriteLine(" ");
            Console.WriteLine(json_a_enviar);
            Console.WriteLine(" ");
            Console.WriteLine("=============================================================================");

            string json = await DataService.PostDataToService(json_a_enviar, "/conta/dados");

            if (json == "false")
                return null;

            ContaCorrentista conta = JsonConvert.DeserializeObject<ContaCorrentista>(json);

            return conta;
        }
    }
}
