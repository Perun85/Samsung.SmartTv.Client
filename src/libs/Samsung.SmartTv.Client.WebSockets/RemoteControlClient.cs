using Samsung.SmartTv.Client.Logging;
using Samsung.SmartTv.Client.Net;
using Samsung.SmartTv.Client.Security;
using Samsung.SmartTv.Client.Serialization;
using Samsung.SmartTv.Client.Text;
using Samsung.SmartTv.Client.WebSockets.Service;
using Samsung.SmartTv.Client.WebSockets.Service.TransferObjects;
using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Samsung.SmartTv.Client.WebSockets
{
    internal sealed class RemoteControlClient : IRemoteControlClient
    {
        private readonly ILogger logger;
        private readonly ISerializer serializer;
        private readonly ClientWebSocket webSocketClient;
        private readonly Uri serviceUri;

        internal RemoteControlClient
        (
            ILogger logger,
            ISerializer serializer,
            IServiceUriProviderFactory uriProviderFactory,
            IRemoteCertificateValidator remoteCertificateValidator,
            IPEndPoint ipEndPoint,
            string appName,
            string token
        )
        {
            if (logger is null) throw new ArgumentNullException(nameof(logger));
            if (serializer is null) throw new ArgumentNullException(nameof(serializer));
            if (uriProviderFactory is null) throw new ArgumentNullException(nameof(uriProviderFactory));
            if (ipEndPoint is null) throw new ArgumentNullException(nameof(ipEndPoint));
            if (remoteCertificateValidator is null) throw new ArgumentNullException(nameof(remoteCertificateValidator));
            if (string.IsNullOrEmpty(appName)) throw new StringNullOrEmptyException(nameof(appName));
            if (string.IsNullOrEmpty(token)) throw new StringNullOrEmptyException(nameof(token));

            this.logger = logger;
            this.serializer = serializer;
            webSocketClient = new ClientWebSocket();
            webSocketClient.Options.RemoteCertificateValidationCallback = remoteCertificateValidator.Validate;
            serviceUri = uriProviderFactory.Create(ipEndPoint).GetAuthenticated(appName, token);
        }

        async Task IRemoteControlClient.ConnectAsync(CancellationToken cancellationToken)
        {
            if (disposed) throw new ObjectDisposedException(nameof(disposed));

            await webSocketClient.ConnectAsync(serviceUri, cancellationToken).ConfigureAwait(false);
            logger.Info($"Connected to {serviceUri.GetEndPointInfo()}");
        }

        async Task IRemoteControlClient.DisconnectAsync(CancellationToken cancellationToken)
        {
            if (disposed) throw new ObjectDisposedException(nameof(disposed));

            await webSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
            logger.Info($"Disconnected from {serviceUri.GetEndPointInfo()}");
        }

        Task IRemoteControlClient.SendKeyAsync(Key key, CancellationToken cancellationToken)
        {
            if (disposed) throw new ObjectDisposedException(nameof(disposed));
            if (key is null) throw new ArgumentNullException(nameof(key));

            return SendKeyInternalAsync(key, cancellationToken);
        }

        private async Task SendKeyInternalAsync(Key key, CancellationToken cancellationToken)
        {
            var request = new SendKeyRequest { Params = new SendKeyParams { DataOfCmd = key } };
            var serializedRequest = serializer.ObjectToJson(request);
            var requestBytes = new ArraySegment<byte>(TextConstants.DefaultEncoding.GetBytes(serializedRequest));

            await webSocketClient.SendAsync(requestBytes, WebSocketMessageType.Text,
                true, cancellationToken).ConfigureAwait(false);

            logger.Info($"Key {key} sent to {serviceUri.GetEndPointInfo()}");
        }

        #region Disposal

        private volatile bool disposed;

        void IDisposable.Dispose()
        {
            InternalDispose(true);
            GC.SuppressFinalize(this);
        }

        private void InternalDispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                webSocketClient.Dispose();

            disposed = true;
        }

        ~RemoteControlClient() => InternalDispose(false);

        #endregion
    }
}