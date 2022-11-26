using Samsung.SmartTv.Client.Logging;
using Samsung.SmartTv.Client.Security;
using Samsung.SmartTv.Client.Serialization;
using Samsung.SmartTv.Client.WebSockets.Service;
using System.Net;

namespace Samsung.SmartTv.Client.WebSockets
{
    public static class RemoteControlClientFactory
    {
        public static IRemoteControlClient Create(IPEndPoint ipEndPoint, string appName, string token, 
            ILogger? logger = null, bool useConsoleLogger = false, IRemoteCertificateValidator? remoteCertificateValidator = null)
        {
            logger = LoggerFactory.Create(logger, useConsoleLogger);
            remoteCertificateValidator = RemoteCertificateValidatorFactory.Create(remoteCertificateValidator, logger);

            return  new RemoteControlClient
            (
                 logger,
                 new Serializer(),
                 new ServiceUriProviderFactory(),
                 remoteCertificateValidator,
                 ipEndPoint,
                 appName,
                 token
            );
        }
    }
}