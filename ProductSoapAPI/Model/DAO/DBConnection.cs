using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MySqlConnector;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace ProductSoapAPI.Model.DAO
{
    public class DBConnection
    {
        private static MySqlConnection sqlConnection;
        private static MySqlCommand command;
        private string sqlConnectionString = "server=localhost;port=3306;User Id=root;database=productssoapapi; password=root";

        public void conectar()
        {
            sqlConnection = new MySqlConnection(sqlConnectionString);
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

        public String GetData(string sql, string tableName)
        {
            command = new MySqlCommand(sql, sqlConnection);
            MySqlDataReader reader = command.ExecuteReader();

            XElement resultNode = new XElement("Result");
            while (reader.Read())
            {
                XElement row = new XElement(tableName);
                for (int i = 0; i < reader.FieldCount;i ++)
                {
                    row.Add(new XElement(reader.GetName(i), reader.GetValue(i)));
                }
                resultNode.Add(row);
            }
            reader.Close();
            return resultNode.ToString();
        }
    }
}