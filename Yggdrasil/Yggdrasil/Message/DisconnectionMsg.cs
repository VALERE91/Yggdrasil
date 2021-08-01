using System;
using Yggdrasil.Utils;

namespace Yggdrasil.Message
{
    public class DisconnectionMsg : IMessage, IPoolObject
    {
        public bool TryParse(Span<byte> data, out int sizeRead)
        {
            throw new NotImplementedException();
        }

        public MessageCode Type()
        {
            return MessageCode.Disconnection;
        }

        public void Reset()
        {
            
        }
    }
}
