using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Parameterized_Query
{
    public class Product
    {
        private readonly string connectionString;
        public Product(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int ExecuteIUD(string sql,Dictionary<string,object>? parameters = null)  //I = INSERT , U = UPDATE , D = DELETE operations..
        {
            using var command = CreateCommand(sql,parameters);
            int affected = command.ExecuteNonQuery();
            return affected;
        }
        public List<Dictionary<string,object>> ExecuteQuery(string sql,Dictionary<string,object>? parameters = null)
        {
            var command = CreateCommand(sql,parameters);
            SqlDataReader reader = command.ExecuteReader();
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            while(reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for(int i=0;i<reader.FieldCount;i++)
                {
                    string columnName = reader.GetName(i);
                    object columnValue = reader.GetValue(i);
                    row.Add(columnName, columnValue);
                }
                data.Add(row);
            }
            return data;
        }
        private SqlCommand CreateCommand(string sql,Dictionary<string,object>? parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
            }
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            return command;
        }
    }
}
