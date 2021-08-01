using System;

namespace Yggdrasil.Message
{
    public class MessageFactory
    {
        public static void Initialize()
        {

        }

        public static bool TryParse(Span<byte> data, out IMessage msg)
        {
            switch (data[0])
            {
                case (byte)MessageCode.Connection:
                    msg = new ConnectionMsg();
                    msg.Parse(data.Slice(1));
                    return true;
                case (byte)MessageCode.Disconnection:
                    msg = new DisconnectionMsg();
                    msg.Parse(data.Slice(1));
                    return true;
                case (byte)MessageCode.Publish:
                    msg = new PublishMsg();
                    msg.Parse(data.Slice(1));
                    return true;
                case (byte)MessageCode.Subscribe:
                    msg = new SubscribeMsg();
                    msg.Parse(data.Slice(1));
                    return true;
                default:
                    msg = null;
                    return false;
            }
        }
    }
}
