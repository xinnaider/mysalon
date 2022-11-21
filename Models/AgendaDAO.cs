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

                comando.CommandText = "call InserirAgenda(@data, @servico, @cliente, @salao);";

                comando.Parameters.AddWithValue("@data", agenda.DataHora);
                comando.Parameters.AddWithValue("@servico", agenda.FkSer);
                comando.Parameters.AddWithValue("@cliente", agenda.FkCli);
                comando.Parameters.AddWithValue("@salao", agenda.FkSal);

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

        public List<Agenda> ListResolvido(int id)
        {
            try
            {
                var lista = new List<Agenda>();
                var comando = _conn.Query();

                comando.CommandText = "Select Agenda.id_age as Id, Agenda.dataHorario_age as DataHorario, Agenda.status_age as Status, Servico.nome_ser as Servico, Cliente.nome_cli as Cliente, Salao.nome_sal as Salao from Agenda, Servico, Cliente, Salao where (Agenda.id_ser_fk = Servico.id_ser) and (Agenda.id_cli_fk = Cliente.id_cli) and (Agenda.id_sal_fk = Salao.id_sal) and (Agenda.id_cli_fk = " + id + ");";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var agenda = new Agenda();
                    agenda.Id = reader.GetInt32("Id");
                    agenda.dataHorario = DAOHelper.GetDateTime(reader, "DataHorario");
                    agenda.status = DAOHelper.GetString(reader, "Status");
                    agenda.Servico = DAOHelper.GetString(reader, "Servico");
                    agenda.Cliente = DAOHelper.GetString(reader, "Cliente");
                    agenda.Salao = DAOHelper.GetString(reader, "Salao");

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
                    agenda.dataHorario = DAOHelper.GetDateTime(reader, "dataHorario_age");
                    agenda.status = DAOHelper.GetString(reader, "status_age");
                    agenda.Servico = DAOHelper.GetString(reader, "id_ser_fk");
                    agenda.Cliente = DAOHelper.GetString(reader, "id_cli_fk");
                    agenda.Salao = DAOHelper.GetString(reader, "id_sal_fk");

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
                    "dataHorario_age = @data, status_age = @status, id_ser_fk = @servico, " +
                    "id_cli_fk = @cliente, id_sal_fk = @salao";

                comando.Parameters.AddWithValue("@data", agenda.dataHorario);
                comando.Parameters.AddWithValue("@status", agenda.status);
                comando.Parameters.AddWithValue("@servico", agenda.Servico);
                comando.Parameters.AddWithValue("@cliente", agenda.Cliente);
                comando.Parameters.AddWithValue("@salao", agenda.Salao);

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
