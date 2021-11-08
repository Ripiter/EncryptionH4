using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionH4
{
    class RandomTest
    {
        //static void Main(string[] args)
        //{
        //    Random rnd = new Random(Guid.NewGuid().GetHashCode());
        //    Stopwatch stopWatch = new Stopwatch();

        //    Console.WriteLine("------------------");
        //    Console.WriteLine("System.Radom");

        //    stopWatch.Start();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine($"Round: {i} random: {rnd.Next(int.MinValue, int.MaxValue)}");
        //    }

        //    stopWatch.Stop();
        //    Console.WriteLine($"Time ticks: {stopWatch.ElapsedTicks}");
        //    stopWatch.Reset();

        //    Console.WriteLine("------------------");
        //    Console.WriteLine("Rng Crypto");

        //    stopWatch.Start();


        //    byte[] data = new byte[10];

        //    using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            rng.GetBytes(data);

        //            Console.WriteLine($"Round: {i} random: {BitConverter.ToInt32(data, 0)}");
        //        }
        //    }

        //    //for (int i = 0; i < 10; i++)
        //    //{
        //    //    Console.WriteLine($"Round: {i} random: {RandomGeneration.GenerateRandomNumber(10)}");
        //    //}


        //    stopWatch.Stop();
        //    Console.WriteLine($"Time ticks: {stopWatch.ElapsedTicks}");

        //    Console.ReadLine();
        //}
    }
}
