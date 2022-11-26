using System;
using System.Threading;
using System.Threading.Tasks;

namespace Samsung.SmartTv.Client
{
    /// <summary>
    /// Client that allows sending commands to the TV device.
    /// </summary>
    public interface IRemoteControlClient : IDisposable
    {
        /// <summary>
        /// Sends key to the TV device.
        /// </summary>
        /// <param name="key" cref="Key">Key to send.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task SendKeyAsync(Key key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Connects to the TV device.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        Task ConnectAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Disconnects from the TV device.
        /// </summary>
        /// <param name="cancellationToken"></param>
        Task DisconnectAsync(CancellationToken cancellationToken = default);
    }
}