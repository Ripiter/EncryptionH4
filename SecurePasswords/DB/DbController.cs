using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    abstract class DbController
    {
        protected DbConnection dbConnection = null;

        public DbController()
        {
            dbConnection = new DbConnection();
        }

        protected virtual DataTable RunProcedure(string procedureName, Dictionary<string, object> parameters = null)
        {
            DataTable table = null;

            using (var db = dbConnection.GetSqlConnection())
            {
                db.Open();
                SqlCommand command = new SqlCommand(procedureName, db);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                if (parameters != null)
                {
                    foreach (var pair in parameters)
                    {
                        command.Parameters.AddWithValue(pair.Key, pair.Value);
                    }
                }

                SqlDataReader oReader = command.ExecuteReader();

                table = new DataTable();
                table.Load(oReader);
                db.Close();
            }

            return table;
        }
    }
}
