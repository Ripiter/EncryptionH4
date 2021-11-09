using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EncryptionSupport
{
    public class CustomEncryption
    {
        public byte[] HashPassword(byte[] toHashed, byte[] salt, int rounds, int byteSize = 32)
        {
            byte[] hashed = new byte[byteSize];

            using (var rfc = new Rfc2898DeriveBytes(toHashed, salt, rounds))
            {
                hashed = rfc.GetBytes(byteSize);
            }

            return hashed;
        }

        public byte[] EncryptDes(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                return Encrypt(des, dataToEncrypt, key, iv);
            }
        }
        public byte[] EncryptAes(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                return Encrypt(aes, dataToEncrypt, key, iv);
            }
        }

        public byte[] DecryptDes(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                return Decrypt(des, dataToDecrypt, key, iv);
            }
        }
        public byte[] DecryptAes(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                return Decrypt(aes, dataToDecrypt, key, iv);
            }
        }

        private byte[] Encrypt(SymmetricAlgorithm symmetricAlgorithm, byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            symmetricAlgorithm.Mode = CipherMode.CBC;
            symmetricAlgorithm.Padding = PaddingMode.PKCS7;

            symmetricAlgorithm.Key = key;
            symmetricAlgorithm.IV = iv;

            using (var memoryStream = new MemoryStream())
            {
                var cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(),
                    CryptoStreamMode.Write);

                cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }
        private byte[] Decrypt(SymmetricAlgorithm symmetricAlgorithm, byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            symmetricAlgorithm.Mode = CipherMode.CBC;
            symmetricAlgorithm.Padding = PaddingMode.PKCS7;

            symmetricAlgorithm.Key = key;
            symmetricAlgorithm.IV = iv;

            using (var memoryStream = new MemoryStream())
            {
                var cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateDecryptor(),
                    CryptoStreamMode.Write);

                cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }
    }
}
