using System.Net;

namespace Samsung.SmartTv.Client.WebSockets.Service
{
    internal interface IServiceUriProviderFactory
    {
        IServiceUriProvider Create(IPEndPoint ipEndPoint);
    }
}