using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class AttemptMessage
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public TypeAttempt AttemptType { get; set; }
        public AttemptMessage(bool _status, string _message)
        {
            Message = _message;
            Status = _status;
        }
        public AttemptMessage(bool _status, string _message, TypeAttempt _type) : this(_status, _message)
        {
            AttemptType = _type;
        }

        public AttemptMessage()
        {

        }
    }
    public enum TypeAttempt
    {
        CouldntFindUser,
        UsernameEmpty,
        LoginFailedIncorrectPassword,
        UserLocked,
        UserExists
    }
}
