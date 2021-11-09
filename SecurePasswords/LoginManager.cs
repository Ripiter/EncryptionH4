using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionSupport;

namespace SecurePasswords
{
    class LoginManager
    {
        DbUserController dbController = null;
        const int ITERATION_COUNT = 500;
        public LoginManager()
        {
            dbController = new DbUserController();
        }
        public AttemptMessage AddUser(string username, string password)
        {
            User existingUser = dbController.GetUserByUserName(username);

            if (existingUser != null)
                return new AttemptMessage(false, "User Already Exists", TypeAttempt.UserExists);

            User user = new User();
            user.UserName = username;
            user.Password = password;

            CustomEncryption customEncryption = new CustomEncryption();

            string salt = RandomGeneration.GenerateRandomString(32);
            byte[] hashedPsW = customEncryption.HashPassword(user.Password.GetBytesUTF8(), salt.GetBytesUTF8(), ITERATION_COUNT);

            user.Password = hashedPsW.ToBase64();
            user.Salt = salt;
            user.Iterations = ITERATION_COUNT;

            dbController.AddUser(user);

            return new AttemptMessage(true, "Added user succesfully");
        }

        public AttemptMessage Login(string username, string password)
        {
            User user = dbController.GetUserByUserName(username);

            if (user == null)
            {
                return new AttemptMessage(false, "Couldn't find user", TypeAttempt.CouldntFindUser);
            }
            else if(user.Status == UserStatus.locked)
            {
                return new AttemptMessage(false, "User is locked", TypeAttempt.UserLocked);
            }
            else if (user.Status == UserStatus.deleted)
            {
                return new AttemptMessage(false, "User is deleted", TypeAttempt.UserLocked);
            }

            CustomEncryption customEncryption = new CustomEncryption();

            byte[] hashedPsW = customEncryption.HashPassword(password.GetBytesUTF8(), user.Salt.GetBytesUTF8(), user.Iterations);
            string psw = hashedPsW.ToBase64();

            if (user.Password == psw)
            {
                dbController.ResetLogin(user);
                return new AttemptMessage(true, "Login successfull");
            }

            return new AttemptMessage(false, "Login failed, incorect password", TypeAttempt.LoginFailedIncorrectPassword);
        }

        public AttemptMessage AddLoginAttempt(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return new AttemptMessage(false, "User name is empty", TypeAttempt.UsernameEmpty);

            User user = dbController.GetUserByUserName(username);

            if (user == null)
                return new AttemptMessage(false, "Couldn't find user", TypeAttempt.CouldntFindUser);

            int attempts = dbController.AddAttempt(user);

            if (attempts >= 5)
            {
                dbController.ChangeUserStatus(user, UserStatus.locked);
                return new AttemptMessage(false, "User is now locked", TypeAttempt.UserLocked);
            }

            return new AttemptMessage(true, "Added attempt");
        }
    }
}
