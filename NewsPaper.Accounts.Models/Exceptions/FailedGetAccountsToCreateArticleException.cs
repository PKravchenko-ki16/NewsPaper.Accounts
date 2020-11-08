using System;
using System.Runtime.Serialization;

namespace NewsPaper.Accounts.Models.Exceptions
{
    public class FailedGetAccountsToCreateArticleException : ApplicationException
    {
        public short CodeException => 1014;

        public FailedGetAccountsToCreateArticleException() : base(Base.Exceptions.NoAuthorFoundException) { }

        public FailedGetAccountsToCreateArticleException(string message) : base(message) { }

        public FailedGetAccountsToCreateArticleException(string message, Exception inner) : base(message, inner) { }

        protected FailedGetAccountsToCreateArticleException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}