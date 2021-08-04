using System;
using System.Collections.Generic;
using System.Net;

namespace Yggdrasil.Transport
{
    using ChanelConfig = Dictionary<NetworkChannel, NetworkDelivery>;
    
    /// <summary>
    /// The list of the channel used by Yggdrasil
    /// </summary>
    public enum NetworkChannel : byte
    {
        Internal,
        TimeSync,
        ReliableEvent,
        UnreliableEvent,
        ReliablePublish,
        UnreliablePublish,
        PublishIFrame,
        Subscribe
    };
    
    /// <summary>
    /// Transport represents a transport layer allowing Yggdrasil
    /// to send data over the network. 
    /// </summary>
    public abstract class Transport
    {
        /// <summary>
        /// Initialize the transport
        /// </summary>
        public abstract void Init(ChanelConfig config);

        /// <summary>
        /// Start the transport layer in server mode
        /// </summary>
        /// <param name="localEndpoint">The endpoint to listen to</param>
        public abstract void StartServer(IPEndPoint localEndpoint);

        /// <summary>
        /// Start the transport in client mode.
        /// The local endpoint will be automatically determined depending on your operating system.
        /// </summary>
        /// <param name="remoteEndpoint">The endpoint to connect to</param>
        public abstract void StartClient(IPEndPoint remoteEndpoint);

        /// <summary>
        /// Start the transport in client mode.
        /// </summary>
        /// <param name="remoteEndpoint">The endpoint to connect to</param>
        /// <param name="localEndpoint">The local endpoint to connect from</param>
        public abstract void StartClient(IPEndPoint remoteEndpoint, IPEndPoint localEndpoint);

        /// <summary>
        /// Send data to a specific peer
        /// </summary>
        /// <param name="peerId">The peer to send to</param>
        /// <param name="data">The data to send</param>
        /// <param name="channel">The channel on which the data must be sent</param>
        public abstract void Send(uint peerId, Span<byte> data, NetworkChannel channel);

        /// <summary>
        /// Delegate for data reception
        /// </summary>
        public delegate void DataReceivedDelegate(ulong peerId, NetworkChannel channel, Span<byte> payload, long receiveTimestamp);

        /// <summary>
        /// Occurs when a new data has been received by the transport layer
        /// </summary>
        public event DataReceivedDelegate OnDataReceived;

        /// <summary>
        /// Delegate for new client connection
        /// </summary>
        public delegate void ClientConnectionDelegate(ulong peerId);

        /// <summary>
        /// Occurs when a new client try to connect
        /// </summary>
        public event ClientConnectionDelegate OnClientConnected;
        
        /// <summary>
        /// Delegate for client disconnection
        /// </summary>
        public delegate void ClientDisconnectionDelegate(ulong peerId);

        /// <summary>
        /// Occurs when a client is disconnected
        /// </summary>
        public event ClientDisconnectionDelegate OnClientDisconnected;

        /// <summary>
        /// This function will be called repeatedly in a thread
        /// </summary>
        public abstract void Update();
    }
}