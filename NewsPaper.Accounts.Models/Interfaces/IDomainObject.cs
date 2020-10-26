using System;

namespace NewsPaper.Accounts.Models.Interfaces
{
    public interface IDomainObject
    {
        Guid Id { get; }
    }
}