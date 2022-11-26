using Samsung.SmartTv.Client.Logging;
using Samsung.SmartTv.Client.Security;
using Samsung.SmartTv.Client.Serialization;
using Samsung.SmartTv.Client.WebSockets.Service;
using System.Net;

namespace Samsung.SmartTv.Client.WebSockets
{
    /// <summary>
    /// Creates instances of <see cref=IAppRegistryClient/>.
    /// </summary>
    public static class AppRegistryClientFactory
    {
        /// <summary>
        /// Creates new instance of <see cref="IAppRegistryClient"/>.
        /// </summary>
        /// <param name="ipEndPoint">IP end point of your TV device.</param>
        /// <param name="logger">Optional custom logger.</param>
        /// <param name="remoteCertificateValidator">Optional component for custom validation of remote certificate.</param>
        /// <returns>Instance of <see cref="IAppRegistryClient"/>.</returns>
        public static IAppRegistryClient Create(IPEndPoint ipEndPoint, 
            ILogger? logger = null, bool useConsoleLogger = false, IRemoteCertificateValidator? remoteCertificateValidator = null)
        {
            logger = LoggerFactory.Create(logger, useConsoleLogger);
            remoteCertificateValidator = RemoteCertificateValidatorFactory.Create(remoteCertificateValidator, logger);

            return new AppRegistryClient
            (
                logger,
                new Serializer(),
                new ServiceUriProviderFactory(),
                remoteCertificateValidator,
                ipEndPoint
            );
        }
    }
}