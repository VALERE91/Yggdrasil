using System;
using Yggdrasil.Message;

namespace Yggdrasil
{
    public class MailBox
    {
        public uint PeerId { get; private set; }

        public MailBox(uint peerId)
        {
            PeerId = peerId;
        }

        public void SendData(byte[] data)
        {

        }

        public void ReceiveData(IntPtr data, int length)
        {
            ushort packetHeader = 0x0000;
            byte numberOfMsg = 0;
            Span<byte> packetData;

            unsafe
            {
                byte* packet = (byte*)data.ToPointer();
                packetHeader |= (ushort)((packet[0] << 8) | (packet[1]));
                numberOfMsg = packet[2];
                packetData = new Span<byte>(packet + 3, length - 3);
            }

            var sizeRead = 0;
            for (var i = 0; i < numberOfMsg; ++i)
            {
                if(!MessageFactory.TryParse(packetData.Slice(sizeRead), out var msg, out sizeRead))
                {
                    //Corrupted packet let's return and ditch it
                    return;
                }

                MessageCode messageCode = msg.Type();
                switch (messageCode)
                {
                    case MessageCode.Connection:
                        Connect(msg as ConnectionMsg);
                        break;
                    case MessageCode.Disconnection:
                        Disconnect(msg as DisconnectionMsg);
                        break;
                    case MessageCode.Publish:
                        Publish(msg as PublishMsg);
                        break;
                    case MessageCode.Subscribe:
                        Subscribe(msg as SubscribeMsg);
                        break;
                }   
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void Connect(ConnectionMsg msg)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void Disconnect(DisconnectionMsg msg)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void Publish(PublishMsg msg)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void Subscribe(SubscribeMsg msg)
        {
            
        }
    }
}