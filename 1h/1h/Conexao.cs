using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

using System.Data.SqlClient;
using _1h;

namespace _1h
{
    public class Conexao
    {
        private static MySqlConnection _objConexao = null;

        #region Conectar
        private static void Conectar()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["lpr"].ConnectionString;
            _objConexao = new MySqlConnection(connectionString);
            _objConexao.Open();
        }
        #endregion

        #region Desconectar
        private static void Desconectar()
        {
            _objConexao.Close();
            _objConexao.Dispose();
        }
        #endregion

        #region ExecutarConsulta
        public IList<T> ExecutarConsulta<T>(string comandoSql, List<MySqlParameter> parameters)
        {
            
                var table = ExecutarConsulta(comandoSql, parameters);

                return HelperDominio.ConvertTo<T>(table);
            

        }

        public DataTable ExecutarConsulta(string comandosql, List<MySqlParameter> parameters)
        {
            
                using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["lpr"].ConnectionString))
                {
                    conn.Open();
                    DataTable tblRetorno = null;
                    var comando = new MySqlCommand(comandosql, conn);

                    if (parameters != null)
                    {
                        foreach (var mySqlParameter in parameters)
                        {
                            comando.Parameters.Add(mySqlParameter);
                        }
                    }

                    var adaptador = new MySqlDataAdapter(comando);
                    tblRetorno = new DataTable();
                    adaptador.Fill(tblRetorno);

                    conn.Close();
                    return tblRetorno;
                }
            

        }
        #endregion

        #region ExecuteScalar
        public void ExecuteNonQuery(string comandosql, List<MySqlParameter> parameters)
        {
            long id = 0;
            ExecuteNonQuery(comandosql, parameters, ref id);
        }


        public void ExecuteNonQuery(string comandosql, List<MySqlParameter> parameters, ref long id)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["lpr"].ConnectionString))
            {
                conn.Open();
                var comando = new MySqlCommand(comandosql, conn);

                if (parameters != null)
                {
                    foreach (var mySqlParameter in parameters)
                    {
                        comando.Parameters.Add(mySqlParameter);
                    }
                }

                comando.ExecuteNonQuery();
                id = comando.LastInsertedId;

                conn.Close();
            }
        }
        #endregion
    }


    //Teste com sqlServer
    public class ConexaoSqlServer
    {
        private static SqlConnection _objConexao = null;

        #region Conectar
        private static void Conectar()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["lpr"].ConnectionString;
            _objConexao = new SqlConnection(connectionString);
            _objConexao.Open();
        }
        #endregion

        #region Desconectar
        private static void Desconectar()
        {
            _objConexao.Close();
            _objConexao.Dispose();
        }
        #endregion

        #region ExecutarConsulta
        public IList<T> ExecutarConsulta<T>(string comandoSql, List<SqlParameter> parameters)
        {
            try
            {
                var table = ExecutarConsulta(comandoSql, parameters);

                return HelperDominio.ConvertTo<T>(table);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ExecutarConsulta(string comandosql, List<SqlParameter> parameters)
        {
            try
            {
                using (var conn = new SqlConnection("Data source=REC-SRV-AD-01;Initial Catalog=eLPR;Persist Security Info=True;User ID=sa;Password=12345678;"))
                {
                    conn.Open();
                    DataTable tblRetorno = null;
                    var comando = new SqlCommand(comandosql, conn);

                    if (parameters != null)
                    {
                        foreach (var sqlParameter in parameters)
                        {
                            comando.Parameters.Add(sqlParameter);
                        }
                    }

                    var adaptador = new SqlDataAdapter(comando);
                    tblRetorno = new DataTable();
                    adaptador.Fill(tblRetorno);

                    conn.Close();
                    return tblRetorno;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
