using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSupport.RSA
{
    public class RsaEncryptionContainer : RsaEncryption
    {
        string ContainerName;

        public RsaEncryptionContainer(string _containerName, int _keySize = 2048) : base(_keySize)
        {
            ContainerName = _containerName;
        }

        public override void AssignNewKey()
        {
            CspParameters cspParams = new CspParameters(1);
            cspParams.KeyContainerName = ContainerName;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;

            rsa = new RSACryptoServiceProvider(keySize, cspParams) { PersistKeyInCsp = true };
        }

        public override byte[] EncryptData(byte[] dataToEncrypt)
        {
            return rsa.Encrypt(dataToEncrypt, false);
        }

        public override byte[] DecryptData(byte[] dataToDecrypt)
        {
            return rsa.Decrypt(dataToDecrypt, false);
        }

        public void DeleteKeyInCsp()
        {
            rsa.Clear();
        }



        #region Old
        //string ContainerName;
        //public RsaEncryptionContainer(string _containerName)
        //{
        //    ContainerName = _containerName;
        //}

        //public void AssignNewKey()
        //{
        //    CspParameters cspParams = new CspParameters(1);
        //    cspParams.KeyContainerName = ContainerName;
        //    cspParams.Flags = CspProviderFlags.UseMachineKeyStore;

        //    var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = true };
        //}
        //public void DeleteKeyInCsp()
        //{
        //    var cspParams = new CspParameters { KeyContainerName = ContainerName };
        //    var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = false };

        //    rsa.Clear();
        //}

        //public byte[] EncryptData(byte[] dataToEncrypt)
        //{
        //    byte[] cipherbytes;

        //    var cspParams = new CspParameters { KeyContainerName = ContainerName };

        //    using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
        //    {
        //        cipherbytes = rsa.Encrypt(dataToEncrypt, false);
        //    }

        //    return cipherbytes;
        //}

        //public byte[] DecryptData(byte[] dataToDecrypt)
        //{
        //    byte[] plain;

        //    var cspParams = new CspParameters { KeyContainerName = ContainerName };

        //    using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
        //    {
        //        plain = rsa.Decrypt(dataToDecrypt, false);
        //    }

        //    return plain;
        //}
        #endregion
    }
}
