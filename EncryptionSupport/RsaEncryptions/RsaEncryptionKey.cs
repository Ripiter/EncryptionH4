using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EncryptionSupport.RSA
{
    public class RsaEncryptionKey : RsaEncryption
    {
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;
        public RsaEncryptionKey(int keySize = 2048) : base(keySize)
        {

        }

        public override void AssignNewKey()
        {
            rsa.PersistKeyInCsp = false;
            _publicKey = rsa.ExportParameters(false);
            _privateKey = rsa.ExportParameters(true);
        }

        public override byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            rsa.PersistKeyInCsp = false;
            rsa.ImportParameters(_publicKey);

            cipherbytes = rsa.Encrypt(dataToEncrypt, true);


            return cipherbytes;
        }


        public override byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            rsa.PersistKeyInCsp = false;
            rsa.ImportParameters(_privateKey);
            plain = rsa.Decrypt(dataToDecrypt, true);

            return plain;
        }




        #region OLD
        //private RSAParameters _publicKey;
        //private RSAParameters _privateKey;

        //public void AssignNewKey()
        //{
        //    using (var rsa = new RSACryptoServiceProvider(2048))
        //    {
        //        rsa.PersistKeyInCsp = false;
        //        _publicKey = rsa.ExportParameters(false);
        //        _privateKey = rsa.ExportParameters(true);
        //    }
        //}

        //public byte[] EncryptData(byte[] dataToEncrypt)
        //{
        //    byte[] cipherbytes;

        //    using (var rsa = new RSACryptoServiceProvider(2048))
        //    {
        //        rsa.PersistKeyInCsp = false;
        //        rsa.ImportParameters(_publicKey);

        //        cipherbytes = rsa.Encrypt(dataToEncrypt, true);
        //    }

        //    return cipherbytes;
        //}

        //public byte[] DecryptData(byte[] dataToEncrypt)
        //{
        //    byte[] plain;

        //    using (var rsa = new RSACryptoServiceProvider(2048))
        //    {
        //        rsa.PersistKeyInCsp = false;

        //        rsa.ImportParameters(_privateKey);
        //        plain = rsa.Decrypt(dataToEncrypt, true);
        //    }

        //    return plain;
        //}
        #endregion
    }
}
