using System;
using System.Threading.Tasks;

namespace NewsPaper.Accounts.Models.Interfaces
{
    public interface IAuthorsRepository : IRepository<Author>
    {
        Task<Guid> GetGuidByNikeNameAuthorAsync(string authorNikeName);
        Task<string> GetNikeNameByGuidAuthorAsync(Guid authorGuid);
        Task<Author> GetByIdentityIdAsync(Guid identityId);
    }
}