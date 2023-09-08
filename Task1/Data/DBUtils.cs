using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Data
{
    public class DBUtils : IDisposable
    {
        public SqlConnection GetDBConnection()
        {
            string connection = @"Data Source=LAPTOP-BEKRMI39\SQLEXPRESS;Initial Catalog=Task1_DB;Trusted_Connection=true";

            SqlConnection conn = new SqlConnection(connection);

            return conn;
        }

        public void Dispose()
        {

        } 

        
    }
}
