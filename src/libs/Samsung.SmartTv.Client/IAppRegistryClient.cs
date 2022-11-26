using System.Threading;
using System.Threading.Tasks;

namespace Samsung.SmartTv.Client
{
    /// <summary>
    /// Client that enables you to register you application on the TV device.
    /// </summary>
    public interface IAppRegistryClient
    {
        /// <summary>
        /// Registers application on the TV device. 
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Application registration token.</returns>
        Task<string?> RegisterAppAsync(string appName, CancellationToken cancellationToken = default);
    }
}