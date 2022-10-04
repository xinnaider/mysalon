using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_sallonnovo.bancodados;
using wpf_sallonnovo.Helpers;

namespace wpf_sallonnovo.Models
{
    internal class AgendaDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Agenda agenda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into agenda values (null, @data, @horario, @valor, " +
                    "@tempoEstimado, @cliente, @salao);";

                comando.Parameters.AddWithValue("@data", agenda.Data);
                comando.Parameters.AddWithValue("@horario", agenda.Horario);
                comando.Parameters.AddWithValue("@valor", agenda.Valor);
                comando.Parameters.AddWithValue("@tempoEstimado", agenda.TempoEstimado);
                comando.Parameters.AddWithValue("@email", agenda.Cliente);
           //     comando.Parameters.AddWithValue("@sexo", agenda.Salao);

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

        public List<Agenda> List()
        {
            try
            {
                var lista = new List<Agenda>();
                var comando = _conn.Query();

                comando.CommandText = "Select * from Agenda";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var agenda = new Agenda();
                    agenda.Id = reader.GetInt32("id_age");
                    agenda.Data = DAOHelper.GetDateTime(reader, "data_age");
                    agenda.Horario = DAOHelper.GetString(reader, "horario_age");
                    agenda.Valor = reader.GetFloat("valor_age");
                    agenda.TempoEstimado = DAOHelper.GetString(reader, "tempo_estimado");
                //    agenda.Cliente = reader.GetInt32("id_cli_fk");

                    lista.Add(agenda);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(Agenda agenda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Agenda WHERE (id_end = @id)";

                comando.Parameters.AddWithValue("@id", agenda.Id);

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
        public void Update(Agenda agenda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update agenda set " +
                    "data_age = @data, horario_age = @horario, valor_age = @valor, " +
                    "tempo_estimado = @tempo, id_cli_fk = @cliente, id_sal_fk = @salao;";

                comando.Parameters.AddWithValue("@data", agenda.Data);
                comando.Parameters.AddWithValue("@horario", agenda.Horario);
                comando.Parameters.AddWithValue("@valor", agenda.Valor);
                comando.Parameters.AddWithValue("@tempo_estimado", agenda.TempoEstimado);
                comando.Parameters.AddWithValue("@cliente", agenda.Cliente);
               // comando.Parameters.AddWithValue("@salao", agenda.Salao);

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
