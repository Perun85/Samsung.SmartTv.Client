using System;

namespace Samsung.SmartTv.Client.Logging
{
    /// <summary>
    /// Represents a type used to perform logging operations.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log info message.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        void Info(string message);

        /// <summary>
        /// Log debug message.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        void Debug(string message);

        /// <summary>
        /// Log warning message.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        void Warn(string message);

        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        void Error(string message);

        /// <summary>
        /// Log error message with exception.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="exception">Exception to be logged. </param>
        void Error(string message, Exception exception);
    }
}