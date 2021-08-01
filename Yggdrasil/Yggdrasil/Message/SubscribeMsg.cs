using System;

namespace Yggdrasil.Message
{
    class SubscribeMsg : IMessage
    {
        public void Parse(Span<byte> data)
        {
            throw new NotImplementedException();
        }

        public MessageCode Type()
        {
            return MessageCode.Subscribe;
        }
    }
}
