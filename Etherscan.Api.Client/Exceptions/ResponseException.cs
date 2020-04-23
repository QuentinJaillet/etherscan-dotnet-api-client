using System;

namespace Etherscan.Api.Client.Exceptions
{
    public class ResponseException : Exception
    {
        public ResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}