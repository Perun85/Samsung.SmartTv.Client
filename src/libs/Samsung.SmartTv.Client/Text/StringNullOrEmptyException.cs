using System.Runtime.Serialization;
using System;

namespace Samsung.SmartTv.Client.Text
{
    /// <summary>
    /// Exception thrown in case that string is null or empty.
    /// </summary>
    [Serializable]
    public sealed class StringNullOrEmptyException : ArgumentNullException
    {
        public StringNullOrEmptyException()
        {
        }

        public StringNullOrEmptyException(string paramName) : base(paramName)
        {
        }

        public StringNullOrEmptyException(string paramName, string message) : base(paramName, message)
        {
        }

        public StringNullOrEmptyException(string message, Exception innerException)
        {
        }

        private StringNullOrEmptyException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}
