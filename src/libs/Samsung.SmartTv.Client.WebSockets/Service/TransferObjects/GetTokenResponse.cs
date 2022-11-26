namespace Samsung.SmartTv.Remote.WebSockets.Service.TransferObjects
{
    public sealed class GetTokenResponse
    {
        public string? Event { get; set; }

        public GetTokenData? Data { get; set; }
    }

    public sealed class GetTokenData
    {
        public string? Id { get; set; }

        public string? Token { get; set; }
    }
}
