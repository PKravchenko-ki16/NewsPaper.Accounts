using System;
using System.Runtime.Serialization;

namespace NewsPaper.Accounts.Models.Exceptions
{
    public class NoEditorFoundException : ApplicationException
    {
        public short CodeException => 1012;

        public NoEditorFoundException() : base(Base.Exceptions.NoEditorFoundException) { }

        public NoEditorFoundException(string message) : base(message) { }

        public NoEditorFoundException(string message, Exception inner) : base(message, inner) { }

        protected NoEditorFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}