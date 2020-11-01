using System;

namespace NewsPaper.Accounts.Models.Interfaces
{
    public abstract class DomainObject
    {
        public abstract Guid Id { get; }
    }
}