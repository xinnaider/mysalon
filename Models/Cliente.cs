﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_sallonnovo.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        // pubic foto {get;set} dar uma olhada como faz
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Sexo  { get; set; }

        public Endereco Endereco { get; set; }
    }
}
