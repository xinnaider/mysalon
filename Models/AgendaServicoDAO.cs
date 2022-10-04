using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_sallonnovo.bancodados;

namespace wpf_sallonnovo.Models
{
    internal class AgendaServicoDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(AgendaServicoDAO agendaServico)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into agenda values (null, @quantidade, @servico, @agenda);";

                comando.Parameters.AddWithValue("@quantidade", agendaServico);
                

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Deu erro no momento de salvar as informações");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
