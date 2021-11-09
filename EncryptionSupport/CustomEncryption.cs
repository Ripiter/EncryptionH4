using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EncryptionSupport
{
    public class CustomEncryption
    {
        public byte[] HashPassword(byte[] toHashed, byte[] salt, int rounds, int byteSize = 32)
        {
            byte[] hashed = new byte[byteSize];

            using(var rfc = new Rfc2898DeriveBytes(toHashed, salt, rounds))
            {
                hashed = rfc.GetBytes(byteSize);
            }

            return hashed;
        }
    }
}
