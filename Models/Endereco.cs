using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_sallonnovo.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public int numero {get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
    }
}
