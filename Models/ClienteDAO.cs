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
        /*public Funcionario GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM funcionario " +
                                                "LEFT JOIN sexo ON cod_sex = cod_sex_fk " +
                                                "LEFT JOIN endereco ON cod_end = cod_end_fk " +
                                                "WHERE cod_func = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var funcionario = new Funcionario();

                while (reader.Read())
                {
                    funcionario.Id = reader.GetInt32("cod_func");
                    funcionario.Nome = reader.GetString("nome_func");
                    funcionario.CPF = reader.GetString("cpf_func");
                    funcionario.RG = reader.GetString("rg_func");
                    funcionario.DataNascimento = DAOHelper.GetDateTime(reader, "datanasc_func");
                    funcionario.Email = reader.GetString("email_func");
                    funcionario.Celular = reader.GetString("celular_func");
                    funcionario.Funcao = reader.GetString("funcao_func");
                    funcionario.Salario = DAOHelper.GetDouble(reader, "salario_func");

                    if (!DAOHelper.IsNull(reader, "cod_sex_fk"))
                        funcionario.Sexo = new Sexo()
                        {
                            Id = reader.GetInt32("cod_sex"),
                            Nome = reader.GetString("nome_sex")
                        };

                    if (!DAOHelper.IsNull(reader, "cod_end_fk"))
                        funcionario.Endereco = new Endereco()
                        {
                            Id = reader.GetInt32("cod_end"),
                            Rua = reader.GetString("rua_end"),
                            Numero = reader.GetInt32("numero_end"),
                            Bairro = reader.GetString("bairro_end"),
                            Cidade = reader.GetString("cidade_end"),
                            Estado = reader.GetString("estado_end")
                        };
                }

                return funcionario;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
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
                    cliente.
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
