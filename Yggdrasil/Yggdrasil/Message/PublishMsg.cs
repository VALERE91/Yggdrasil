using System;

namespace Yggdrasil.Message
{
    public class PublishMsg : IMessage
    {
        public int ChannelId { get; set; }

        public byte[] Data { get; set; }

        public int Sender { get; set; }

        public void Parse(Span<byte> data)
        {
            
        }

        public MessageCode Type()
        {
            return MessageCode.Publish;
        }
    }
}
