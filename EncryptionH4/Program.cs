using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EncryptionSupport;
using EncryptionSupport.RSA;

namespace EncryptionH4
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomEncryption customEncryptor = new CustomEncryption();
            while (true)
            {
                Console.WriteLine("Insert encryption type");
                Console.WriteLine("1. Sha256 \n2. Md5 \n3. Hmac md5 \n4. Des \n5. Aes \n6. Rsa xml\n7. Rsa container\n8. Rsa Keys");

                string choice = Console.ReadLine();
                Console.Write("Text: ");
                string text = Console.ReadLine();

                byte[] computed = null;

                switch (choice)
                {
                    case "1":
                        computed = Hash.ComputeHashSha256(text.GetBytesUTF8());
                        break;
                    case "2":
                        computed = Hash.ComputeHashMd5(text.GetBytesUTF8());
                        break;
                    case "3":
                        Console.Write("Key: ");
                        string hmacMd5Key = Console.ReadLine();
                        computed = Hmac.ComputeHmacmd5(text.GetBytesUTF8(), hmacMd5Key.GetBytesUTF8());
                        break;
                    case "4":
                        {
                            byte[] key = RandomGeneration.GenerateRandomByteArray(8);
                            byte[] iv = RandomGeneration.GenerateRandomByteArray(8);

                            computed = customEncryptor.EncryptDes(text.GetBytesUTF8(), key, iv);

                            byte[] decrypted = customEncryptor.DecryptDes(computed, key, iv);
                            Console.WriteLine("Decrypted: " + decrypted.GetString());
                        }
                        break;
                    case "5":
                        {
                            byte[] key = RandomGeneration.GenerateRandomByteArray(32);
                            byte[] iv = RandomGeneration.GenerateRandomByteArray(16);

                            computed = customEncryptor.EncryptAes(text.GetBytesUTF8(), key, iv);

                            byte[] decrypted = customEncryptor.DecryptAes(computed, key, iv);
                            Console.WriteLine("Decrypted: " + decrypted.GetString());
                        }
                        break;
                    case "6":
                        {
                            string publicPath = @"C:\DeleteLater\RsaKeys\publicKey.xml";
                            string privatePath = @"C:\DeleteLater\RsaKeys\privateKey.xml";
                            RsaEncryptionXML rsa = new RsaEncryptionXML(privatePath, publicPath);

                            rsa.AssignNewKey();
                            computed = rsa.EncryptData(text.GetBytesUTF8());

                            byte[] decrypted = rsa.DecryptData(computed);
                            Console.WriteLine("Decrypted: " + decrypted.GetString());
                        }
                        break;
                    case "7":
                        {
                            RsaEncryptionContainer rsa = new RsaEncryptionContainer("peters container");
                            rsa.AssignNewKey();

                            computed = rsa.EncryptData(text.GetBytesUTF8());

                            byte[] decrypted = rsa.DecryptData(computed);
                            Console.WriteLine("Decrypted: " + decrypted.GetString());
                            rsa.DeleteKeyInCsp();
                        }
                        break;
                    case "8":
                        {
                            RsaEncryptionKey rsa = new RsaEncryptionKey();
                            rsa.AssignNewKey();

                            computed = rsa.EncryptData(text.GetBytesUTF8());

                            byte[] decrypted = rsa.DecryptData(computed);
                            Console.WriteLine("Decrypted: " + decrypted.GetString());
                        }
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }

                if (computed != null)
                {
                    Console.WriteLine("Base: " + computed.ToBase64());
                    Console.WriteLine("Hex: " + computed.ToHex());
                }

                Console.WriteLine("-------------------");
            }
        }
    }
}
