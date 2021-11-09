using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginManager login = new LoginManager();
            string userName = "jonny";
            string password = "abcdef";

            //AttemptMessage addMessage = login.AddUser(userName, password);

            //if (addMessage.Status == false)
            //    Console.WriteLine(addMessage.Message);

            AttemptMessage res = login.Login(userName, password);

            if (res.Status == false)
            {
                Console.WriteLine(res.Message);

                if (res.AttemptType != TypeAttempt.CouldntFindUser)
                {
                    AttemptMessage attemptMessage = login.AddLoginAttempt(userName);

                    Console.WriteLine(attemptMessage.Message);
                }
            }
            else
            {
                Console.WriteLine(res.Message);
            }

            Console.ReadLine();
        }
    }
}
