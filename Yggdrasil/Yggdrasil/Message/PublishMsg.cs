using System;

namespace Yggdrasil.Message
{
    public class PublishMsg : IMessage
    {
        public int ChannelId { get; set; }

        public byte[] Data { get; set; }

        public int Sender { get; set; }

        public bool TryParse(Span<byte> data, out int sizeRead)
        {
            throw new NotImplementedException();
        }

        public MessageCode Type()
        {
            return MessageCode.Publish;
        }
    }
}
