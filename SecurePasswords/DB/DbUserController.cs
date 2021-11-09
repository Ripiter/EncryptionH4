using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    class DbUserController : DbController
    {
        public void AddUser(User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@username", user.UserName);
            parameters.Add("@password", user.Password);
            parameters.Add("@salt", user.Salt);
            parameters.Add("@iterations", user.Iterations);

            RunProcedure("SP_CreateUser", parameters);            
        }

        public User GetUserByUserName(string username)
        {
            User user = null;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Username", username);

            using (var table = RunProcedure("SP_GetUserByUsername", parameters))
            {
                if(table.Rows.Count != 0)
                    user = TableRowToUser(table.Rows[0]);
            }

            return user;
        }

        public int AddAttempt(User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Username", user.UserName);

            using (var table = RunProcedure("SP_AddUserAttempt", parameters))
            {
                user = TableRowToUser(table.Rows[0]);
            }

            return user.LoginAttempts;
        }
        public void ResetLogin(User user)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Username", user.UserName);

            using (var table = RunProcedure("SP_ResetLogin", parameters))
            {
                user = TableRowToUser(table.Rows[0]);
            }
        }

        public void ChangeUserStatus(User user, UserStatus userStatus)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Username", user.UserName);

            using (var table = RunProcedure("SP_ChangeUserStatus", parameters))
            {
                user = TableRowToUser(table.Rows[0]);
            }
        }

        private User TableRowToUser(DataRow oReader)
        {
            User user = new User();
            user.UserName = oReader["UserName"].ToString();
            user.Salt = oReader["Salt"].ToString();
            user.Password = oReader["password"].ToString();
            user.Iterations = Convert.ToInt32(oReader["Iterations"].ToString());
            user.LoginAttempts = Convert.ToInt32(oReader["LoginAttempts"].ToString());
            user.Status = (UserStatus)Convert.ToInt32(oReader["userstatus"].ToString());

            return user;
        }
    }
}
