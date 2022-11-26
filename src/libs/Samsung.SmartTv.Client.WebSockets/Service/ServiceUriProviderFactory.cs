using System.Net;

namespace Samsung.SmartTv.Client.WebSockets.Service
{
    internal sealed class ServiceUriProviderFactory : IServiceUriProviderFactory
    {
        IServiceUriProvider IServiceUriProviderFactory.Create(IPEndPoint ipEndPoint) =>
            new ServiceUriProvider(ipEndPoint);
    }
}