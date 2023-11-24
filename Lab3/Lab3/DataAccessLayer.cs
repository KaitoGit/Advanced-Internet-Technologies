using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;//added
using System.Configuration;//added
using System.Data;//added

namespace Lab3
{
    public class DataAccessLayer
    {
        SqlConnection sqlConnection 
            = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnectionString"].ConnectionString);

        public DataTable selectData(SqlCommand sqlCommand)
        {
            // this method support only select queries
            //open connection is not required
            DataTable dt = new DataTable();
            sqlCommand.Connection = sqlConnection;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            sda.Fill(dt);
            return dt;
        }
        public SqlDataReader returnReader(SqlCommand sqlCommand)
        {
            // this method support only select queries
            //open connection is required
            sqlCommand.Connection = sqlConnection;
            return sqlCommand.ExecuteReader();
        }
        public int queryExecution(SqlCommand SqlCommand)
        {
            // this method support insert, update, delete queries
            //open connection is required
            SqlCommand.Connection = sqlConnection;
            return SqlCommand.ExecuteNonQuery();
            
        }

        public bool openConnection()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch
            {
               return false;
            }
        }
        
        public void closeConnection()
        {
            sqlConnection.Close();
        }
    }
}