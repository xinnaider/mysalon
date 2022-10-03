using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace wpf_sallonnovo.bancodados
{
    internal class conexao
    {
        private static string host = "localhost";

        private static string port = "3306";

        private static string user = "root";

        private static string password = "root";

        private static string dbname = "bd_escola";

        private static MySqlConnection connection;

        private static MySqlCommand command;

        public conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={host};database={dbname};port={port};user={user};password={password}");
                connection.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MySqlCommand Query(string query)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = query;

                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
