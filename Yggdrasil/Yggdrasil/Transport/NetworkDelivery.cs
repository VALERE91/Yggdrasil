namespace Yggdrasil.Transport
{
    public enum NetworkDelivery
    {
        /// <summary>
        /// Unreliable message
        /// </summary>
        Unreliable,

        /// <summary>
        /// Unreliable with sequencing
        /// </summary>
        UnreliableSequenced,

        /// <summary>
        /// Reliable message
        /// </summary>
        Reliable,

        /// <summary>
        /// Reliable message where messages are guaranteed to be in the right order
        /// </summary>
        ReliableSequenced
    }
}