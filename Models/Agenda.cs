using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_sallonnovo.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime? dataHorario { get; set; }
        public string DataHora { get; set; }
        public string status { get; set; }
        public string Cliente { get; set; }
        public string Salao  { get; set; }
        public string Servico  { get; set; }
        public int FkCli { get; set; }
        public int FkSer { get; set; }
        public int FkSal { get; set; }
    }
}
