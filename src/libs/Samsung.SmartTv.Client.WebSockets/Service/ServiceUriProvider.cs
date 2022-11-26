using Samsung.SmartTv.Client.Text;
using Samsung.SmartTv.Remote.WebSockets.Service;
using System;
using System.Net;

namespace Samsung.SmartTv.Client.WebSockets.Service
{
    internal sealed class ServiceUriProvider : IServiceUriProvider
    {
        private readonly IPEndPoint ipEndPoint;

        internal ServiceUriProvider(IPEndPoint ipEndPoint) =>
            this.ipEndPoint = ipEndPoint ?? throw new ArgumentNullException(nameof(ipEndPoint));

        Uri IServiceUriProvider.GetDefault(string appName)
        {
            if (string.IsNullOrEmpty(appName)) throw new StringNullOrEmptyException(appName);

            var uriString = string.Format(ServiceConstants.UriTemplate.Default,
                ipEndPoint.Address, ipEndPoint.Port, appName);

            return new Uri(uriString);
        }

        Uri IServiceUriProvider.GetAuthenticated(string appName, string token)
        {
            if (string.IsNullOrEmpty(appName)) throw new StringNullOrEmptyException(appName);
            if (string.IsNullOrEmpty(token)) throw new StringNullOrEmptyException(token);

            var uriString = string.Format(ServiceConstants.UriTemplate.WithToken,
                ipEndPoint.Address, ipEndPoint.Port, appName, token);

            return new Uri(uriString);
        }
    }
}