using System;

namespace Yggdrasil.Message
{
    class DisconnectionMsg : IMessage
    {
        public void Parse(Span<byte> data)
        {
            throw new NotImplementedException();
        }

        public MessageCode Type()
        {
            return MessageCode.Disconnection;
        }
    }
}
