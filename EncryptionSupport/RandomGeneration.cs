using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSupport
{
    static class RandomGeneration
    {
        public static int GenerateRandomNumber(int lenght)
        {
            return BitConverter.ToInt32(GetRandomByteArray(lenght), 0);
        }
        public static string GenerateRandomString(int lenght)
        {
            return Convert.ToBase64String(GetRandomByteArray(lenght));
        }

        public static byte[] GenerateRandomByteArray(int lenght)
        {
            return GetRandomByteArray(lenght);
        }

        static byte[] GetRandomByteArray(int length)
        {
            byte[] data = new byte[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(data);
            }

            return data;
        }
    }
}
