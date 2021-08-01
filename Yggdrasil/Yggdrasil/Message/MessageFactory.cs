using System;
using Yggdrasil.Utils;

namespace Yggdrasil.Message
{
    public static class MessageFactory
    {
        private static ObjectPool<ConnectionMsg> _connectionMsgPool;
        private static ObjectPool<DisconnectionMsg> _disconnectionMsgPool;
        private static ObjectPool<PublishMsg> _publishMsgPool;
        private static ObjectPool<SubscribeMsg> _subscribeMsgPool;
        
        public static void Initialize(int poolSize)
        {
            _connectionMsgPool = new ObjectPool<ConnectionMsg>(poolSize);
            _disconnectionMsgPool = new ObjectPool<DisconnectionMsg>(poolSize);
            _publishMsgPool = new ObjectPool<PublishMsg>(poolSize);
            _subscribeMsgPool = new ObjectPool<SubscribeMsg>(poolSize);
        }

        private static bool ParseConnection(Span<byte> data, out IMessage msg, out int sizeRead)
        {
            if (_connectionMsgPool.TryGet(out var connectionMsg))
            {
                msg = connectionMsg;
                return msg.TryParse(data.Slice(1), out sizeRead);
            }

            msg = null;
            sizeRead = 0;
            return false;
        }

        private static bool ParseDisconnection(Span<byte> data, out IMessage msg, out int sizeRead)
        {
            if (_disconnectionMsgPool.TryGet(out var disconnectionMsg))
            {
                msg = disconnectionMsg;
                return msg.TryParse(data.Slice(1), out sizeRead);
            }

            msg = null;
            sizeRead = 0;
            return false;
        }
        
        private static bool ParsePublish(Span<byte> data, out IMessage msg, out int sizeRead)
        {
            if (_publishMsgPool.TryGet(out var publishMsg))
            {
                msg = publishMsg;
                return msg.TryParse(data.Slice(1), out sizeRead);
            }

            msg = null;
            sizeRead = 0;
            return false;
        }
        
        private static bool ParseSubscribe(Span<byte> data, out IMessage msg, out int sizeRead)
        {
            if (_connectionMsgPool.TryGet(out var subscribeMsg))
            {
                msg = subscribeMsg;
                return msg.TryParse(data.Slice(1), out sizeRead);
            }

            msg = null;
            sizeRead = 0;
            return false;
        }
        
        public static bool TryParse(Span<byte> data, out IMessage msg, out int sizeRead)
        {
            switch (data[0])
            {
                case (byte)MessageCode.Connection:
                    return ParseConnection(data, out msg, out sizeRead);
                case (byte)MessageCode.Disconnection:
                    return ParseDisconnection(data, out msg, out sizeRead);
                case (byte)MessageCode.Publish:
                    return ParsePublish(data, out msg, out sizeRead);
                case (byte)MessageCode.Subscribe:
                    return ParseSubscribe(data, out msg, out sizeRead);
                default:
                    msg = null;
                    sizeRead = 0;
                    return false;
            }
        }
    }
}
