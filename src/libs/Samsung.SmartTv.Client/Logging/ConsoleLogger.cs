using System;

namespace Samsung.SmartTv.Client.Logging
{
    internal sealed class ConsoleLogger : ILogger
    {
        void ILogger.Info(string message) => WriteMessageToConsole(LoggingConstants.Header.Info, message);

        void ILogger.Debug(string message) => WriteMessageToConsole(LoggingConstants.Header.Debug, message);

        void ILogger.Warn(string message) => WriteMessageToConsole(LoggingConstants.Header.Warn, message);

        void ILogger.Error(string message) => WriteMessageToConsole(LoggingConstants.Header.Error, message);

        void ILogger.Error(string message, Exception exception) => WriteExceptionToConsole(message, exception);

        private static void WriteExceptionToConsole(string message, Exception exception)
        {
            if (exception is null) throw new ArgumentNullException(nameof(exception));

            WriteMessageToConsole(LoggingConstants.Header.Error, message);
            Console.WriteLine(exception.Message);
            Console.WriteLine(exception.StackTrace);
        }

        private static void WriteMessageToConsole(string header, string message)
        {
            if (string.IsNullOrEmpty(header)) throw new ArgumentNullException(nameof(header));
            if (string.IsNullOrEmpty(message)) throw new ArgumentException(nameof(message));

            Console.WriteLine($"{header}{LoggingConstants.Header.Separator} {message}");
        }
    }
}