using ContactManager.Data.Models.Result.Interfaces;
using System;

namespace ContactManager.Data.Models.Result.Implementations
{
    public class ResponseMessage : IResponseMessage
    {
        public string Message { get; }
        public Exception Exception { get; }

        public ResponseMessage(string message)
        {
            Message = message;
        }

        public ResponseMessage(string message, Exception exception)
        {
            Message = message;
            Exception = exception;
        }
    }
}
