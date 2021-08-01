using System;

namespace Yggdrasil.Message
{
    public interface IMessage
    {
        bool TryParse(Span<byte> data, out int sizeRead);

        MessageCode Type();
    }
}
