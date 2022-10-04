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
    internal class FuncionarioDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into funcionario values (null, null, @nome, @cpf, " +
                    "@rg, @telefone, @email, @sexo);";

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@cpf", funcionario.CPF);
                comando.Parameters.AddWithValue("@rg", funcionario.RG);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);

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

        public List<Funcionario> List()
        {
            try
            {
                var lista = new List<Funcionario>();
                var comando = _conn.Query();

                comando.CommandText = "Select * from Funcionario";


                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var funcionario = new Funcionario();
                    funcionario.Id = reader.GetInt32("id_func");
                    funcionario.Nome = DAOHelper.GetString(reader, "nome_func");
                    funcionario.CPF = DAOHelper.GetString(reader, "cpf_func");
                    funcionario.RG = DAOHelper.GetString(reader, "rg_func");
                    funcionario.Telefone = DAOHelper.GetString(reader, "telefone_func");
                    funcionario.Email = DAOHelper.GetString(reader, "email_func");
                    funcionario.Sexo = DAOHelper.GetString(reader, "sexo_func");


                    lista.Add(funcionario);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Delete(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Funcionario WHERE (id_func = @id)";

                comando.Parameters.AddWithValue("@id", funcionario.Id);

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
        public void Update(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update Funcionario set " +
                    "nome_func = @nome, cpf_func = @cpf, rg_func = @rg " +
                    "telefone_func = @telefone, email_func = @email, sexo_func = @sexo;";

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@cpf", funcionario.CPF);
                comando.Parameters.AddWithValue("@rg", funcionario.RG);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);

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
