using System;

namespace Yggdrasil.Message
{
    public class MessageFactory
    {
        public static void Initialize()
        {

        }

        public static bool TryParse(Span<byte> data, out IMessage msg, out int sizeRead)
        {
            switch (data[0])
            {
                case (byte)MessageCode.Connection:
                    msg = new ConnectionMsg();
                    return msg.TryParse(data.Slice(1), out sizeRead);
                case (byte)MessageCode.Disconnection:
                    msg = new DisconnectionMsg();
                    return msg.TryParse(data.Slice(1), out sizeRead);
                case (byte)MessageCode.Publish:
                    msg = new PublishMsg();
                    return msg.TryParse(data.Slice(1), out sizeRead);
                case (byte)MessageCode.Subscribe:
                    msg = new SubscribeMsg();
                    return msg.TryParse(data.Slice(1), out sizeRead);
                default:
                    msg = null;
                    sizeRead = 0;
                    return false;
            }
        }
    }
}
