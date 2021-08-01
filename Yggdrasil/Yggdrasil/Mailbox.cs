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

            IMessage msg;
            if(!MessageFactory.TryParse(packetData, out msg))
            {
                //Corrupted packet let's return and ditch it
                return;
            }

            MessageCode messageCode = msg.Type();
            switch (messageCode)
            {
                case MessageCode.Connection:
                    break;
                case MessageCode.Disconnection:
                    break;
                case MessageCode.Publish:
                    break;
                case MessageCode.Subscribe:
                    break;
                default:
                    break;
            }
        }
    }
}