using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSupport.RSA
{
    public class RsaEncryptionXML : RsaEncryption
    {
        string publicKeyPath;
        string privateKeyPath;

        public RsaEncryptionXML(string _privatePath, string _publicPath, int keySize = 2048) : base(keySize)
        {
            publicKeyPath = _publicPath;
            privateKeyPath = _privatePath;
        }

        public override void AssignNewKey()
        {
            rsa.PersistKeyInCsp = false;

            if (File.Exists(privateKeyPath))
            {
                File.Delete(privateKeyPath);
            }

            if (File.Exists(publicKeyPath))
            {
                File.Delete(publicKeyPath);
            }

            var publicKeyfolder = Path.GetDirectoryName(publicKeyPath);
            var privateKeyfolder = Path.GetDirectoryName(privateKeyPath);

            if (!Directory.Exists(publicKeyfolder))
            {
                Directory.CreateDirectory(publicKeyfolder);
            }

            if (!Directory.Exists(privateKeyfolder))
            {
                Directory.CreateDirectory(privateKeyfolder);
            }

            File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
            File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
        }

        public override byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            rsa.PersistKeyInCsp = false;
            rsa.FromXmlString(File.ReadAllText(publicKeyPath));
            cipherbytes = rsa.Encrypt(dataToEncrypt, false);

            return cipherbytes;
        }

        public override byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            rsa.PersistKeyInCsp = false;
            rsa.FromXmlString(File.ReadAllText(privateKeyPath));
            plain = rsa.Decrypt(dataToDecrypt, false);

            return plain;
        }

        #region OLD
        //public void AssignNeyKey(string privateKeyPath, string publicKeyPath)
        //{
        //    using (var rsa = new RSACryptoServiceProvider(2048))
        //    {
        //        rsa.PersistKeyInCsp = false;

        //        if (File.Exists(privateKeyPath))
        //        {
        //            File.Delete(privateKeyPath);
        //        }

        //        if (File.Exists(publicKeyPath))
        //        {
        //            File.Delete(publicKeyPath);
        //        }

        //        var publicKeyfolder = Path.GetDirectoryName(publicKeyPath);
        //        var privateKeyfolder = Path.GetDirectoryName(privateKeyPath);

        //        if (!Directory.Exists(publicKeyfolder))
        //        {
        //            Directory.CreateDirectory(publicKeyfolder);
        //        }

        //        if (!Directory.Exists(privateKeyfolder))
        //        {
        //            Directory.CreateDirectory(privateKeyfolder);
        //        }

        //        File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
        //        File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
        //    }
        //}


        //public byte[] EncryptData(string publicKeyPath, byte[] dataToEncrypt)
        //{
        //    byte[] cipherbytes;

        //    using (var rsa = new RSACryptoServiceProvider(2048))
        //    {
        //        rsa.PersistKeyInCsp = false;
        //        rsa.FromXmlString(File.ReadAllText(publicKeyPath));

        //        cipherbytes = rsa.Encrypt(dataToEncrypt, false);
        //    }

        //    return cipherbytes;
        //}

        //public byte[] DecryptData(string privateKeyPath, byte[] dataToDecrypt)
        //{
        //    byte[] plain;

        //    using (var rsa = new RSACryptoServiceProvider())
        //    {
        //        rsa.PersistKeyInCsp = false;
        //        rsa.FromXmlString(File.ReadAllText(privateKeyPath));
        //        plain = rsa.Decrypt(dataToDecrypt, false);
        //    }

        //    return plain;
        //}
        #endregion
    }
}
