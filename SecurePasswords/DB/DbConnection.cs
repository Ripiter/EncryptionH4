using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    class DbConnection
    {
        string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

    }
}
