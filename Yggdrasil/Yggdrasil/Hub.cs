using System;
using System.Collections.Generic;
using System.Threading;
using ENet;

namespace Yggdrasil
{
    public class Hub : IDisposable
    {
        private readonly Host _host;

        private bool _stop;

        private Thread _runningThread;
        
        private readonly Dictionary<uint, MailBox> _peerMailboxes = new Dictionary<uint, MailBox>();

        public Hub(string iface, ushort port, int peerLimit)
        {
            _host = new Host();
            Address address = new Address();
            address.SetIP(iface);
            address.Port = port;
            _host.Create(address, peerLimit);
        }

        public void Dispose()
        {
            Stop();
            _host.Dispose();
        }

        public void Start()
        {
            _runningThread = new Thread(Run);
            _runningThread.Start();
            _stop = false;
        }

        public void Stop()
        {
            _stop = true;
            _runningThread.Join();
        }

        private void Run()
        {
            Event netEvent;

            while (!_stop)
            {
                bool polled = false;

                while (!polled)
                {
                    if (_host.CheckEvents(out netEvent) <= 0)
                    {
                        if (_host.Service(15, out netEvent) <= 0)
                            break;

                        polled = true;
                    }

                    switch (netEvent.Type)
                    {
                        case EventType.None:
                            break;

                        case EventType.Connect:
                            var m = new MailBox(netEvent.Peer.ID);
                            _peerMailboxes.Add(netEvent.Peer.ID, m);
                            Console.WriteLine("Client connected - ID: " + netEvent.Peer.ID + ", IP: " + netEvent.Peer.IP);
                            break;

                        case EventType.Disconnect:
                        case EventType.Timeout:
                            _peerMailboxes.Remove(netEvent.Peer.ID);
                            Console.WriteLine("Client disconnected - ID: " + netEvent.Peer.ID + ", IP: " + netEvent.Peer.IP);
                            break;

                        case EventType.Receive:
                            Console.WriteLine("Packet received from - ID: " + netEvent.Peer.ID + ", IP: " + netEvent.Peer.IP + ", Channel ID: " + netEvent.ChannelID + ", Data length: " + netEvent.Packet.Length);
                            _peerMailboxes[netEvent.Peer.ID].ReceiveData(netEvent.Packet.UserData, netEvent.Packet.Length);
                            netEvent.Packet.Dispose();
                            break;
                    }
                }
            }

            _host.Flush();
        }
    }
}