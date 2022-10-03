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

namespace wpf_sallonnovo.Models
{
    class SalaoDAO
    {
        private static conexao _conn = new conexao();

        public List<Salao> List()
        {
            try
            {
                var lista = new List<Salao>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM salao";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var salao = new Salao();

                    salao.Id = reader.GetInt32("id_sal");
                    salao.Nome = DAOHelper.GetString(reader, "nome_sal");
                    salao.Telefone = DAOHelper.GetString(reader, "telefone_sal");
                    salao.Descricao = DAOHelper.GetString(reader, "descricao_sal");
                    salao.Razao_Social = DAOHelper.GetString(reader, "razao_social_sal");
                    salao.CNPJ = DAOHelper.GetString(reader, "cnpj_sal");
                    salao.Email = DAOHelper.GetString(reader, "email_sal");

                    lista.Add(salao);
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
