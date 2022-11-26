using Samsung.SmartTv.Remote.WebSockets.Service;

namespace Samsung.SmartTv.Client.WebSockets.Service.TransferObjects
{
    internal sealed class SendKeyRequest
    {
        public string Method => ServiceConstants.SendKey.Method;

        public SendKeyParams? Params { get; set; }
    }
}