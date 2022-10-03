using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_sallonnovo.bancodados;
using wpf_sallonnovo.Helpers;
using MySql.Data.MySqlClient;

namespace wpf_sallonnovo.Models
{
    internal class EnderecoDAO
    {

        private static conexao _conn = new conexao();


        public void Insert (Endereco endereco)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into endereco values (null, @rua, @bairro, @numero, @cidade, @estado, @cep);";

                comando.Parameters.AddWithValue("@rua", endereco.rua);
                comando.Parameters.AddWithValue("@bairro", endereco.bairro);
                comando.Parameters.AddWithValue("@numero", endereco.numero);
                comando.Parameters.AddWithValue("@cidade", endereco.cidade);
                comando.Parameters.AddWithValue("@estado", endereco.estado);
                comando.Parameters.AddWithValue("@cep", endereco.cep);


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
        public List<Endereco> List()
        {
            try
            {
                var lista = new List<Endereco>();
                var comando = _conn.Query();

                comando.CommandText = "Select * from Endereco";


                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var endereco = new Endereco();
                    endereco.Id = reader.GetInt32("id_end");
                    endereco.rua = DAOHelper.GetString(reader,"rua_end");
                    endereco.bairro = DAOHelper.GetString(reader,"bairro_end");
                    endereco.numero = reader.GetInt32("numero_end");
                    endereco.cidade = DAOHelper.GetString(reader,"cidade_end");
                    endereco.estado = DAOHelper.GetString(reader,"estado_end");
                    endereco.cep = DAOHelper.GetString(reader,"cep_end");


                    lista.Add(endereco);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //terminar essa parada
    }
}
