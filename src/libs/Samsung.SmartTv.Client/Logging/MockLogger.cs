using System;

namespace Samsung.SmartTv.Client.Logging
{
    internal sealed class MockLogger : ILogger
    {
        void ILogger.Info(string message)
        {
            // Should do nothing
        }

        void ILogger.Debug(string message)
        {
            // Should do nothing
        }

        void ILogger.Warn(string message)
        {
            // Should do nothing
        }

        void ILogger.Error(string message)
        {
            // Should do nothing
        }

        void ILogger.Error(string message, Exception exception)
        {
            // Should do nothing
        }
    }
}