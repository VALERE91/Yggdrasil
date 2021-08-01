namespace Yggdrasil
{
    public class Yggdrasil
    {
        public static void Initialize()
        {
            ENet.Library.Initialize();
        }

        public static void Deinitialize()
        {
            ENet.Library.Deinitialize();
        }
    }
}