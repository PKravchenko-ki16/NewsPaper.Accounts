using System;
using System.Runtime.Serialization;

namespace NewsPaper.Accounts.Models.Exceptions
{
    public class NoAuthorFoundException : ApplicationException
    {
        public short CodeException => 1011;

        public NoAuthorFoundException() : base(Base.Exceptions.NoAuthorFoundException) {}

        public NoAuthorFoundException(string message) : base(message) { }

        public NoAuthorFoundException(string message, Exception inner) : base(message, inner) { }

        protected NoAuthorFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}