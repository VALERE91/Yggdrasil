using System;

namespace BasicServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Yggdrasil.Yggdrasil.Initialize();
            using (Yggdrasil.Hub hub = new("0.0.0.0", 5000, 100))
            {
                hub.Start();
                Console.ReadLine();
            }
            Yggdrasil.Yggdrasil.Deinitialize();
        }
    }
}