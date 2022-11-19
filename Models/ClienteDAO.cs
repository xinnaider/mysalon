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

                comando.CommandText = "insert into cliente values(null, null, @nome, @cpf, " +
                    "@rg, @telefone, @email, @sexo);";

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@rg", cliente.RG);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@sexo", cliente.Sexo);
      

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
        

        public List<Cliente> List()
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
                    cliente.Nome = DAOHelper.GetString(reader, "nome_cli");
                    cliente.CPF = DAOHelper.GetString(reader, "cpf_cli");
                    cliente.RG = DAOHelper.GetString(reader, "rg_cli");
                    cliente.Telefone = DAOHelper.GetString(reader, "telefone_cli");
                    cliente.Email = DAOHelper.GetString(reader, "email_cli");
                    cliente.Sexo = DAOHelper.GetString(reader, "sexo_cli");

                    lista.Add(cliente);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente GetByUsuario(string usuarioNome, string senha)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "SELECT * FROM login LEFT JOIN Cliente ON id_cli = id_cli_fk " +
                    "WHERE user_log = @usuario AND senha_log = @senha";

                query.Parameters.AddWithValue("@usuario", usuarioNome);
                query.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader reader = query.ExecuteReader();

                Cliente cli = null;

                while (reader.Read())
                {
                    cli = new Cliente() { Id = reader.GetInt32("id_cli"), Nome = reader.GetString("nome_cli"), CPF = reader.GetString("cpf_cli"),
                    RG = reader.GetString("rg_cli"), Telefone = reader.GetString("telefone_cli"), Email = reader.GetString("email_cli"), Sexo = reader.GetString("sexo_cli")};
                }

                return cli;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
