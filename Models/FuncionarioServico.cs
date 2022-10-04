using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_sallonnovo.Models
{
    public class FuncionarioServico
    {
        public  int Id { get; set; }

        public Funcionario Funcionario { get; set; }

        public Servico Servico { get; set; }
        

    }
}
