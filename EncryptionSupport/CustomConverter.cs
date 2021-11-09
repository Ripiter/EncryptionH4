using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSupport
{
    public static class CustomConverter
    {
        public static string ToHex(this byte[] byteArray)
        {
            return BitConverter.ToString(byteArray);
        }
        public static byte[] GetBytesUTF8(this string convertText)
        {
            return Encoding.UTF8.GetBytes(convertText);
        }
        public static string GetString(this byte[] byteArray)
        {
            return Encoding.UTF8.GetString(byteArray);
        }
        public static string ToBase64(this byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }
    }
}
