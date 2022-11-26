using System;

namespace Samsung.SmartTv.Client.WebSockets.Service
{
    internal interface IServiceUriProvider
    {
        Uri GetDefault(string appName);

        Uri GetAuthenticated(string appName, string token);
    }
}