namespace Samsung.SmartTv.Client.Serialization
{
    public interface ISerializer
    {
        string BytesToText(byte[] bytes);

        byte[] TextToBytes(string text);

        T? JsonToObject<T>(string json) where T: class;

        string ObjectToJson(object entity);
    }
}