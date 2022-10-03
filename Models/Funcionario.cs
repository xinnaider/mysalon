using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_sallonnovo.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        //foto 
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
    
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }

        //fk Endereco 
        //fk Salao
    
    
    }
}
