﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_sallonnovo.Models
{
    public class Servico
    {
        public int Id { get; set; }
        // foto
        public double Valor { get; set; }
        public string Name { get; set; }
        public string Tipo { get; set; }
        public int fkSalao { get; set; }
        //public Salao Salao { get; set; }
    }
}
