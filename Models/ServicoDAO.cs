using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_sallonnovo.Helpers;
using wpf_sallonnovo.Models;
using wpf_sallonnovo.bancodados;
using MySql.Data.MySqlClient;
using wpf_sallonnovo.Views;

namespace wpf_sallonnovo.Models.Salao
{
    class ServicoDAO
    {
        private static conexao _conn = new conexao();

        public List<Servico> List()
        {
            try
            {
                var lista = new List<Servico>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Servico";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var servico = new Servico();

                    servico.Id = reader.GetInt32("id_ser");
                    servico.Valor = reader.GetInt32("valor_ser");
                    servico.Name = DAOHelper.GetString(reader, "nome_ser");
                    servico.Tipo = DAOHelper.GetString(reader, "tipo_ser");
                    servico.Descricao = DAOHelper.GetString(reader, "descricao_ser");

                    servico.Salao = reader.GetInt32("id_sal_fk");

                    lista.Add(servico);
                }

                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
