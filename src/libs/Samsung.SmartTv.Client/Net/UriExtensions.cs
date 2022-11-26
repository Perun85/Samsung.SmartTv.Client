using System;

namespace Samsung.SmartTv.Client.Net
{
    public static class UriExtensions
    {
        public static string GetEndPointInfo(this Uri uri)
        {
            if (uri is null) throw new ArgumentNullException(nameof(uri));

            return $"{uri.Host}:{uri.Port}";
        }
    }
}