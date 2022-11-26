using Samsung.SmartTv.Client.Logging;
using System;

namespace Samsung.SmartTv.Client.Security
{
    public static class RemoteCertificateValidatorFactory
    {
        public static IRemoteCertificateValidator Create(IRemoteCertificateValidator? validator, ILogger logger)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            if (validator != null)
                return validator;

            return new AlwaysValidRemoteCertificateValidator(logger);
        }
    }
}
