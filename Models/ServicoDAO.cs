﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_sallonnovo.bancodados;
using wpf_sallonnovo.Helpers;
using MySql.Data.MySqlClient;

namespace wpf_sallonnovo.Models
{
    internal class ServicoDAO
    {
        private static conexao _conn = new conexao();

        public void Insert(Servico servico)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into servico values (null, null, @valor, @nome, @tipo, @fkSalao);";

                comando.Parameters.AddWithValue("@valor", servico.Valor);
                comando.Parameters.AddWithValue("@nome", servico.Name);
                comando.Parameters.AddWithValue("@tipo", servico.Tipo);
                comando.Parameters.AddWithValue("@fkSalao", servico.fkSalao);
                //comando.Parameters.AddWithValue("@salao", servico.Salao);

                var resultado = comando.ExecuteNonQuery();


                if (resultado == 0)
                {
                    throw new Exception("Erro no momento de salvar as informações!");

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Servico> List()
        {
            try
            {
                var lista = new List<Servico>();
                var comando = _conn.Query();

                comando.CommandText = "Select * from Servico";


                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var servico = new Servico();
                    servico.Id = reader.GetInt32("id_ser");
                    servico.Valor = reader.GetFloat("valor_ser");
                    servico.Name = DAOHelper.GetString(reader, "nome_ser");
                    servico.Tipo = DAOHelper.GetString(reader, "tipo_ser");
                  //  servico.Salao = reader.GetInt32("id_sal_fk");


                    lista.Add(servico);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Servico> ListEspecifico(int id)
        {
            try
            {
                var lista = new List<Servico>();
                var comando = _conn.Query();

                comando.CommandText = "Select * from Servico where id_sal_fk = " + id + ";";


                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var servico = new Servico();
                    servico.Id = reader.GetInt32("id_ser");
                    servico.Valor = reader.GetFloat("valor_ser");
                    servico.Name = DAOHelper.GetString(reader, "nome_ser");
                    servico.Tipo = DAOHelper.GetString(reader, "tipo_ser");
                    //servico.Salao = reader.GetInt32("id_sal_fk");


                    lista.Add(servico);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Servico servico)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Servico WHERE (id_ser = @id)";

                comando.Parameters.AddWithValue("@id", servico.Id);

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

        public void Update(Servico servico)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update servico set " +
                    "valor_ser = @valor, nome_ser = @nome, tipo_ser = @tipo where id_ser = @id;";

                comando.Parameters.AddWithValue("@valor", servico.Valor);
                comando.Parameters.AddWithValue("@nome", servico.Name);
                comando.Parameters.AddWithValue("@tipo", servico.Tipo);
                comando.Parameters.AddWithValue("@id", servico.Id);

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

        public double MinPreco(Salao salao)
        {

            try
            {
                var comando = _conn.Query();
                double preco = 0;
                comando.CommandText = "select min(valor_ser) as Preco from Servico where (id_sal_fk = @id)";

                comando.Parameters.AddWithValue("@id", salao.Id);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var servico = new Servico();
                   servico.Valor = DAOHelper.GetDouble(reader, "Preco");

                    preco = servico.Valor;

                }
                reader.Close();

                return preco;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }

}

