using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace EnviromentTest
{
    class Contexto : IDisposable
    {
        private readonly SqlConnection conexao;
        public Contexto()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStringConfigDemo01"].ConnectionString);
            conexao.Open();
        }
        public void ExecutaComando(string strQuery)
        {
            var cmdQuery = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            cmdQuery.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdQuery = new SqlCommand(strQuery, conexao);
            return cmdQuery.ExecuteReader();
        }
        public void Dispose()
        {
            if (conexao.State==System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
