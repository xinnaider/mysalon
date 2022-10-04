using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_sallonnovo.Models
{
    public class AgendaServico
    {
        public int Id { get; set; }
        public string Quantidade { get; set;}

        public Servico Servico { get; set; }

        public Agenda Agenda { get; set; }
        
    }
}
