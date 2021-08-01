using ENet;
using System;
using System.Threading;

namespace Yggdrasil
{
    public class Stub : IDisposable
    {
        private Host _client;

        private bool _stop;

        Thread _runningThread;

        Peer _localPeer;

        public Stub(string hostIP, ushort hostPort)
        {
            _client = new Host();
            Address address = new Address();
            address.SetIP(hostIP);
            address.Port = hostPort;
            _client.Create();
            _localPeer = _client.Connect(address);
        }

        public void Dispose()
        {
            Stop();
            _client.Dispose();
        }

        public void Start()
        {
            _runningThread = new Thread(Run);
            _runningThread.Start();
            _stop = false;
        }

        public void Stop()
        {
            _localPeer.Disconnect(0);
            _stop = true;
            _runningThread.Join();
        }

        public void SendData(byte channel, ref byte[] data)
        {
            Packet packet = default;

            packet.Create(data);
            _localPeer.Send(channel, ref packet);
        }

        private void Run()
        {
            Event netEvent;

            while (!_stop)
            {
                bool polled = false;

                while (!polled)
                {
                    if (_client.CheckEvents(out netEvent) <= 0)
                    {
                        if (_client.Service(15, out netEvent) <= 0)
                            break;

                        polled = true;
                    }

                    switch (netEvent.Type)
                    {
                        case EventType.None:
                            break;

                        case EventType.Connect:
                            Console.WriteLine("Client connected to server");
                            break;

                        case EventType.Disconnect:
                            Console.WriteLine("Client disconnected from server");
                            break;

                        case EventType.Timeout:
                            Console.WriteLine("Client connection timeout");
                            break;

                        case EventType.Receive:
                            Console.WriteLine("Packet received from server - Channel ID: " + netEvent.ChannelID + ", Data length: " + netEvent.Packet.Length);
                            netEvent.Packet.Dispose();
                            break;
                    }
                }
            }

            _client.Flush();
        }
    }
}
