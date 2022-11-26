using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Samsung.SmartTv.Client.Security
{
    /// <summary>
    /// Represents a type used to perform TV device's certificate validation.
    /// </summary>
    public interface IRemoteCertificateValidator
    {
        /// <summary>
        /// Validates certificate of the TV device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="certificate">TV device certificate.</param>
        /// <param name="chain">TV device certificate chain.</param>
        /// <param name="sslPolicyErrors">Policy errors.</param>
        /// <returns>Boolean value that indicates is the certificate valid.</returns>
        bool Validate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors);
    }
}