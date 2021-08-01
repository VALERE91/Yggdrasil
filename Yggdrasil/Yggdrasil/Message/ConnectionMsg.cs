using System;
using Yggdrasil.Utils;

namespace Yggdrasil.Message
{
    class ConnectionMsg : IMessage, IPoolObject
    {
        public bool TryParse(Span<byte> data, out int sizeRead)
        {
            throw new NotImplementedException();
        }

        public MessageCode Type()
        {
            return MessageCode.Connection;
        }

        public void Reset()
        {
            
        }
    }
}
