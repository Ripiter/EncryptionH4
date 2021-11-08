using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EncryptionSupport;

namespace EncryptionH4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Insert encryption type");
                Console.WriteLine("1. Sha256 \n2. Md5 \n3. Hmac md5");

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
