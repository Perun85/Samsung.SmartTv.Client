namespace Samsung.SmartTv.Remote.WebSockets.Service
{
    internal static class ServiceConstants
    {
        internal const ushort DefaultPort = 8002;
        internal const ushort DefaultBufferSizeBytes = 4096;

        internal static class UriTemplate
        {
            internal const string Default = "wss://{0}:{1}/api/v2/channels/samsung.remote.control?name={2}";
            internal static readonly string WithToken = Default + "&token={3}";
        }

        internal static class SendKey
        {
            internal const string Method = "ms.remote.control";
            internal const string Cmd = "Click";
            internal const string Option = "false";
            internal const string TypeOfRemote = "SendRemoteKey";
        }
    }
}