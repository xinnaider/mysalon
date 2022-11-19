using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_sallonnovo.Helpers;
using wpf_sallonnovo.bancodados;
using MySql.Data.MySqlClient;


namespace wpf_sallonnovo.Models
{
    class SalaoDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Salao salao)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Salao values (null, null, @nome, @telefone, @razaoSocial, @cnpj, @email, @fkEnd);";

                //comando.Parameters.AddWithValue("@null", salao.Foto);//

                comando.Parameters.AddWithValue("@nome", salao.Nome);
                comando.Parameters.AddWithValue("@telefone", salao.Telefone);
                comando.Parameters.AddWithValue("@razaoSocial", salao.Razao_Social);
                comando.Parameters.AddWithValue("@cnpj", salao.CNPJ);
                comando.Parameters.AddWithValue("@email", salao.Email);
                comando.Parameters.AddWithValue("@fkEnd", salao.IdEnd);

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
                    //salao.Foto = DAOHelper.GetString(reader, "foto_sal");//
                    salao.Nome = DAOHelper.GetString(reader, "nome_sal");
                    salao.Telefone = DAOHelper.GetString(reader, "telefone_sal");
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

        public void Delete(Salao salao)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Salao WHERE (id_sal = @id)";

                comando.Parameters.AddWithValue("@id", salao.Id);

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

        public void Update(Salao salao)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update salao set " +
                    "foto_sal = @foto, nome_sal = @nome, telefone_sal= @telefone, " +
                    "razao_social_sal = @razaoSocial, cnpj_sal = @cnpj, email_sal = @email;";

                //comando.Parameters.AddWithValue("@foto", salao.Foto);//
                comando.Parameters.AddWithValue("@nome", salao.Nome);
                comando.Parameters.AddWithValue("@telefone", salao.Telefone);
                comando.Parameters.AddWithValue("@razaoSocial", salao.Razao_Social);
                comando.Parameters.AddWithValue("@cnpj", salao.CNPJ);
                comando.Parameters.AddWithValue("@email", salao.Email);

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


