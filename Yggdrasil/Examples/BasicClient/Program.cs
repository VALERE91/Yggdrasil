using System;
using System.Text;

namespace BasicClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the client");
            Yggdrasil.Yggdrasil.Initialize();
            using(Yggdrasil.Stub stub = new("127.0.0.1", 5000))
            {
                stub.Start();
                Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes("Hello world!!!");
                stub.SendData(0, ref data);
                Console.ReadLine();
            }
            Yggdrasil.Yggdrasil.Deinitialize();
        }
    }
}