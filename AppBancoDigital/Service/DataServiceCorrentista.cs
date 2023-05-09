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
            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/entrar");

            if (json == "false")
                return null;

            Correntista correntista = JsonConvert.DeserializeObject<Correntista>(json);

            return correntista;
        }
    }
}
