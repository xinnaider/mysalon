using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using wpf_sallonnovo.bancodados;

namespace wpf_sallonnovo.Models
{
    class LoginDAO : AbstractDAO<Login>
    {
        //terminar de mexer login
        private static conexao conn = new conexao();
        public Login GetByUsuario(string usuarioNome, string senha)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM login LEFT JOIN Cliente ON id_cli = id_cli_fk " +
                    "WHERE user_log = @usuario AND senha_log = @senha";

                query.Parameters.AddWithValue("@usuario", usuarioNome);
                query.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader reader = query.ExecuteReader();

                Login usuario = null;

                while (reader.Read())
                {
                    usuario = Login.GetInstance();
                    usuario.Id = reader.GetInt32("id_log");
                    usuario.User = reader.GetString("user_log");
                    usuario.Cliente = new Cliente() { Id = reader.GetInt32("id_cli"), Nome = reader.GetString("nome_cli") };
                }

                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public void Insert(Login login)
        {
            try
            {
                var comando = conn.Query();

                comando.CommandText = "insert into login values (null, @user, @senha, @cliente);";

                comando.Parameters.AddWithValue("@user", login.User) ;
                comando.Parameters.AddWithValue("@senha", login.Password) ;
                comando.Parameters.AddWithValue("@cliente", login.Cliente) ;
                


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
