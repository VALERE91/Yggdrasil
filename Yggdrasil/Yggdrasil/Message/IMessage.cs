using System;

namespace Yggdrasil.Message
{
    public interface IMessage
    {
        void Parse(Span<byte> data);

        MessageCode Type();
    }
}
