﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppBancoDigital.Model
{
    public class Conta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Saldo { get; set; }
        public string Limite { get; set; }
        public string Tipo { get; set; }
        public string Senha { get; set; }
        public string Data_abertura { get; set; }
        public int Id_correntista { get; set; } 
    }
}
