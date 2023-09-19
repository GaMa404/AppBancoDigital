using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class ContaCorrentista
    {
        public int Id { get; set; }
        public string Saldo { get; set; }
        public string Limite { get; set; }
        public string Tipo { get; set; }
        public DateTime Data_abertura { get; set; }
        public int Id_correntista { get; set; } 
    }
}
