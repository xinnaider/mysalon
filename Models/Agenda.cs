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
        public DateTime? Data { get; set; } //fazer esquema para o date -> olhar no projeto da escola!
        public string Horario { get; set; } //fazer esquema para o date -> olhar no projeto da escola!
        public float Valor { get; set; }
        public string TempoEstimado { get; set; } //fazer esquema para o date -> olhar no projeto da escola!
        public virtual Cliente Cliente { get; set; }
        public virtual Salao Salao { get; set; }
    }
}
