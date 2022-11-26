using System.Text.Json;

namespace Samsung.SmartTv.Client.Serialization
{
    internal static class SerializationConstants
    {
        internal static readonly JsonSerializerOptions JsonSerializationOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
}
