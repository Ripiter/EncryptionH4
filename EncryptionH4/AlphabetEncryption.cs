using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionH4
{
    class AlphabetEncryption
    {
        //static void Main(string[] args)
        //{
        //    char[] alphabet = new char[26];

        //    for (int i = 0; i < alphabet.Length; i++)
        //        alphabet[i] = (char)(i + 97);

        //    char[] movesAlphabet = new char[alphabet.Length];

        //    int offSet = 5;
        //    for (int i = 0; i < alphabet.Length; i++)
        //    {
        //        if (i + offSet < alphabet.Length)
        //        {
        //            movesAlphabet[i] = alphabet[i + offSet];
        //        }

        //        if (i + offSet >= alphabet.Length)
        //        {
        //            movesAlphabet[i] = alphabet[offSet + i - alphabet.Length];
        //        }
        //    }

        //    Dictionary<char, char> alphabetPair = new Dictionary<char, char>();

        //    for (int i = 0; i < alphabet.Length; i++)
        //    {
        //        alphabetPair.Add(alphabet[i], movesAlphabet[i]);
        //    }

        //    alphabetPair.Add(' ', ' ');

        //    string beforeEncryption = "hello world potato".ToLower();
        //    string afterEncryption = "";


        //    for (int i = 0; i < beforeEncryption.Length; i++)
        //    {
        //        afterEncryption += alphabetPair[beforeEncryption[i]];
        //    }

        //    Console.WriteLine(afterEncryption);

        //    string decrypted = "";

        //    for (int i = 0; i < afterEncryption.Length; i++)
        //    {
        //        decrypted += GetKeyByValue(alphabetPair, afterEncryption[i]);
        //    }


        //    Console.WriteLine(decrypted);

        //    Console.ReadLine();
        //}

        //static char GetKeyByValue(Dictionary<char, char> pairs, char value)
        //{
        //    foreach (var pair in pairs)
        //    {
        //        if (pair.Value == value)
        //            return pair.Key;
        //    }

        //    return 'x';
        //}
    }
}
