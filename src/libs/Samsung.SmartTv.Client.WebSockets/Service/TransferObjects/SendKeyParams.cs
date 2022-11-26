using Samsung.SmartTv.Remote.WebSockets.Service;
using System.Text.Json.Serialization;

namespace Samsung.SmartTv.Client.WebSockets.Service.TransferObjects
{
    internal sealed class SendKeyParams
    {
        [JsonPropertyName(TransferObjectConstants.PropertyName.DataOfCmd)]
        public string? DataOfCmd { get; set; }

        [JsonPropertyName(TransferObjectConstants.PropertyName.Cmd)]
        public string Cmd => ServiceConstants.SendKey.Cmd;

        [JsonPropertyName(TransferObjectConstants.PropertyName.Option)]
        public string Option => ServiceConstants.SendKey.Option;

        [JsonPropertyName(TransferObjectConstants.PropertyName.TypeOfRemote)]
        public string TypeOfRemote => ServiceConstants.SendKey.TypeOfRemote;
    }
}
