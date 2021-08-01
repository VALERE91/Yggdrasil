using System;

namespace Yggdrasil.Message
{
    class ConnectionMsg : IMessage
    {
        public bool TryParse(Span<byte> data, out int sizeRead)
        {
            throw new NotImplementedException();
        }

        public MessageCode Type()
        {
            return MessageCode.Connection;
        }
    }
}
