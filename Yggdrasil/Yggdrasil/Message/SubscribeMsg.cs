using System;

namespace Yggdrasil.Message
{
    class SubscribeMsg : IMessage
    {
        public bool TryParse(Span<byte> data, out int sizeRead)
        {
            throw new NotImplementedException();
        }

        public MessageCode Type()
        {
            return MessageCode.Subscribe;
        }
    }
}
