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


        public void Insert(Endereco endereco)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into endereco values (null, @rua, @bairro, @numero, @cidade, @estado, @cep);";

                comando.Parameters.AddWithValue("@rua", endereco.Rua);
                comando.Parameters.AddWithValue("@bairro", endereco.Bairro);
                comando.Parameters.AddWithValue("@numero", endereco.Numero);
                comando.Parameters.AddWithValue("@cidade", endereco.Cidade);
                comando.Parameters.AddWithValue("@estado", endereco.Estado);
                comando.Parameters.AddWithValue("@cep", endereco.Cep);


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
                    endereco.Rua = DAOHelper.GetString(reader, "rua_end");
                    endereco.Bairro = DAOHelper.GetString(reader, "bairro_end");
                    endereco.Numero = DAOHelper.GetString(reader,"numero_end");
                    endereco.Cidade = DAOHelper.GetString(reader, "cidade_end");
                    endereco.Estado = DAOHelper.GetString(reader, "estado_end");
                    endereco.Cep = DAOHelper.GetString(reader, "cep_end");


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
        public String BuscarEnd(Salao salao)
        {
            try
            {
                var a = "";
                var comando = _conn.Query();

                comando.CommandText = "Select rua_end as Rua, numero_end as Numero from Endereco where (id_end = @idfk)";
                comando.Parameters.AddWithValue("@idfk", salao.Id);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var endereco = new Endereco();
                    endereco.Rua = DAOHelper.GetString(reader, "Rua");
                    endereco.Numero = DAOHelper.GetString(reader, "Numero");

                    a = endereco.Rua + " " + endereco.Numero;
                    
                }                
                reader.Close();
                
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Delete(Endereco endereco)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Endereco WHERE (id_end = @id)";

                comando.Parameters.AddWithValue("@id", endereco.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao deletar as informações");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(Endereco endereco)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update endereco set " +
                    "rua_end = @rua, bairro_end = @bairro, numero_end= @numero, " +
                    "cidade_end = @cidade, estado_end = @estado, cep_end = @cep;";

                comando.Parameters.AddWithValue("@rua", endereco.Rua);
                comando.Parameters.AddWithValue("@bairro", endereco.Bairro);
                comando.Parameters.AddWithValue("@numero", endereco.Numero);
                comando.Parameters.AddWithValue("@cidade", endereco.Cidade);
                comando.Parameters.AddWithValue("@estado", endereco.Estado);
                comando.Parameters.AddWithValue("@cep", endereco.Cep);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}