using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_sallonnovo.bancodados;
using MySql.Data.MySqlClient;
using wpf_sallonnovo.Helpers;

namespace wpf_sallonnovo.Models
{
    internal class ClienteDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into cliente values (null, null, @nome, @cpf, " +
                    "@rg, @telefone, @email, @sexo, @endereco);";

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@rg", cliente.RG);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@sexo", cliente.Sexo);
                comando.Parameters.AddWithValue("@endereco", cliente.Endereco);
      

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
        public void Update(Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update cliente set " +
                    "nome_cli = @nome, cpf_cli = @cpf, rg_cli= @rg, " +
                    "telefone_cli = @telefone, email_cli = @email, sexo_cli = @sex;";

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@rg", cliente.RG);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@sex", cliente.Sexo);


                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao atualizar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*public List<Cliente> List()
        {
            try
            {
            var lista = new List<Cliente>();
                var comando = _conn.Query();

                comando.CommandText = "select * from cliente;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new Cliente();
                    cliente.Id = reader.GetInt32("id_cli");
                    //fotinha
                    cliente.Nome = DAOHelper.GetString(reader, "nome_cli");
                    cliente.CPF = DAOHelper.GetString(reader, "cpf_cli");
                    cliente.RG = DAOHelper.GetString(reader, "rg_cli");
                    cliente.Telefone = DAOHelper.GetString(reader, "telefone_cli");
                    cliente.Email = DAOHelper.GetString(reader, "email_cli");
                    cliente.Sexo = DAOHelper.GetString(reader, "sexo_cli");
                    cliente.Endereco = reader.GetInt32("id_end_fk");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}
