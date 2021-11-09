using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Iterations { get; set; }
        public int LoginAttempts { get; set; }
        public UserStatus Status { get; set; }
    }

    public enum UserStatus
    {
        active = 10,
        deleted = 90,
        locked = 100
    }

}
