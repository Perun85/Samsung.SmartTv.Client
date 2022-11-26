using Samsung.SmartTv.Client.Logging;
using Samsung.SmartTv.Client.Security;
using Samsung.SmartTv.Client.Serialization;
using Samsung.SmartTv.Client.WebSockets.Service;
using Samsung.SmartTv.Remote.WebSockets.Service;
using Samsung.SmartTv.Remote.WebSockets.Service.TransferObjects;
using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Samsung.SmartTv.Client.WebSockets
{
    internal sealed class AppRegistryClient : IAppRegistryClient
    {
        private readonly ILogger logger;
        private readonly ISerializer serializer;
        private readonly IServiceUriProvider uriProvider;
        private readonly IRemoteCertificateValidator remoteCertificateValidator;

        internal AppRegistryClient
        (
            ILogger logger,
            ISerializer serializer,
            IServiceUriProviderFactory uriProviderFactory,
            IRemoteCertificateValidator remoteCertificateValidator,
            IPEndPoint ipEndPoint
        )
        {
            if (logger is null) throw new ArgumentNullException(nameof(logger));
            if (serializer is null) throw new ArgumentNullException(nameof(serializer));
            if (uriProviderFactory is null) throw new ArgumentNullException(nameof(uriProviderFactory));
            if (remoteCertificateValidator is null) throw new ArgumentNullException(nameof(remoteCertificateValidator));
            if (ipEndPoint is null) throw new ArgumentNullException(nameof(ipEndPoint));

            this.logger = logger;
            this.serializer = serializer;
            this.remoteCertificateValidator = remoteCertificateValidator;

            uriProvider = uriProviderFactory.Create(ipEndPoint);
        }

        Task<string?> IAppRegistryClient.RegisterAppAsync(string appName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(appName)) throw new ArgumentNullException(nameof(appName));

            return RegisterAppInternalAsync(appName, cancellationToken);
        }

        private async Task<string?> RegisterAppInternalAsync(string appName, CancellationToken cancellationToken)
        {
            using var webSocketClient = CreateWebSocketClient();

            var buffer = new byte[ServiceConstants.DefaultBufferSizeBytes];
            var data = new ArraySegment<byte>(buffer);

            await webSocketClient.ConnectAsync(uriProvider.GetDefault(appName), cancellationToken).ConfigureAwait(false);
            logger.Debug("Connection established");

            var receiveResult = await webSocketClient.ReceiveAsync(data, cancellationToken).ConfigureAwait(false);
            logger.Debug("Receive operation completed");

            return ExtractTokenFromResponse(receiveResult, data);
        }

        private ClientWebSocket CreateWebSocketClient()
        {
            var webSocketClient = new ClientWebSocket();
            webSocketClient.Options.RemoteCertificateValidationCallback = remoteCertificateValidator.Validate;

            return webSocketClient;
        }

        private string? ExtractTokenFromResponse(WebSocketReceiveResult receiveResult, ArraySegment<byte> data)
        {
            if (receiveResult is null || receiveResult.Count == 0)
            {
                logger.Warn("No data received");
                return null;
            }

            logger.Debug("Data received");

            var responseText = serializer.BytesToText(data.Array[0..receiveResult.Count]);
            var getToken = serializer.JsonToObject<GetTokenResponse>(responseText);

            if (getToken?.Data?.Token is null)
            {
                logger.Error("Token not present in response");
                return null;
            }

            logger.Info("Token extracted, application registered");

            return getToken.Data.Token;
        }
    }
}