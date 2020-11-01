using System;
using System.Runtime.Serialization;

namespace NewsPaper.Accounts.Models.Exceptions
{
    public class NoUserFoundException : ApplicationException
    {
        public short CodeException => 1013;

        public NoUserFoundException() : base(Base.Exceptions.NoUserFoundException) { }

        public NoUserFoundException(string message) : base(message) { }

        public NoUserFoundException(string message, Exception inner) : base(message, inner) { }

        protected NoUserFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}