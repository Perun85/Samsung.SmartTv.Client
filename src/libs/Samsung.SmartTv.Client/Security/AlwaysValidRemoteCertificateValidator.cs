using Samsung.SmartTv.Client.Logging;
using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Samsung.SmartTv.Client.Security
{
    internal sealed class AlwaysValidRemoteCertificateValidator : IRemoteCertificateValidator
    {
        private readonly ILogger logger;

        internal AlwaysValidRemoteCertificateValidator(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        bool IRemoteCertificateValidator.Validate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            logger.Debug($"Remote certificate subject {certificate.Subject}");
            return true;
        }
    }
}