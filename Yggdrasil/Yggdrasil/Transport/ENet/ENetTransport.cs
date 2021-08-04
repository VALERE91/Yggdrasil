using System;
using System.Collections.Generic;
using System.Net;

namespace Yggdrasil.Transport.ENet
{
    /// <summary>
    /// ENetTransport represents a Transport for Yggdrasil based on the ENet library
    /// </summary>
    public class ENetTransport : Transport
    {
        public override void Init(Dictionary<NetworkChannel, NetworkDelivery> config)
        {
            throw new NotImplementedException();
        }

        public override void StartServer(IPEndPoint localEndpoint)
        {
            throw new NotImplementedException();
        }

        public override void StartClient(IPEndPoint remoteEndpoint)
        {
            throw new NotImplementedException();
        }

        public override void StartClient(IPEndPoint remoteEndpoint, IPEndPoint localEndpoint)
        {
            throw new NotImplementedException();
        }

        public override void Send(uint peerId, Span<byte> data, NetworkChannel channel)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}