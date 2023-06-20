using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MySqlConnector;

namespace ProductSoapAPI.Model.DAO
{
    public class DBConnection
    {
        private static MySqlConnection sqlConnection;
        private static MySqlCommand command;

        public void conectar()
        {
            sqlConnection = new MySqlConnection("server=localhost;port=3306;User Id=root;database=alan; password=root");
            sqlConnection.Open();
        }

        public void desconectar()
        {
            sqlConnection.Close();
        }

        public void comandosql(string sql)
        {

            command = new MySqlCommand(sql, sqlConnection);
            command.ExecuteNonQuery();

        }
    }
}