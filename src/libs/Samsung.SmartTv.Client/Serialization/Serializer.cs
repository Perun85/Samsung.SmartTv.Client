using Samsung.SmartTv.Client.Text;
using System;
using System.Text.Json;

namespace Samsung.SmartTv.Client.Serialization
{
    public sealed class Serializer : ISerializer
    {
        public string BytesToText(byte[] bytes)
        {
            if (bytes is null) throw new ArgumentNullException(nameof(bytes));

            return TextConstants.DefaultEncoding.GetString(bytes);
        }

        public T? JsonToObject<T>(string json) where T : class
        {
            if (string.IsNullOrEmpty(json)) throw new StringNullOrEmptyException(nameof(json));

            return JsonSerializer.Deserialize<T>(json, SerializationConstants.JsonSerializationOptions);
        }

        public string ObjectToJson(object entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            return JsonSerializer.Serialize(entity, SerializationConstants.JsonSerializationOptions);
        }

        public byte[] TextToBytes(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new StringNullOrEmptyException(nameof(text));

            return TextConstants.DefaultEncoding.GetBytes(text);
        }
    }
}