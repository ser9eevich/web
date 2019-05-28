using System;
using System.Collections.Generic;
using ;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataProcessor
{
    class Data
    {
        private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ClientsDB;
                                            Integrated Security=True;Connect Timeout=60;Encrypt=False;
                                            TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Save<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(ConnectionString))
            {
                cnn.Execute(sql, data);
            }
        }

        public void Create()
        {

        }
    }
}
