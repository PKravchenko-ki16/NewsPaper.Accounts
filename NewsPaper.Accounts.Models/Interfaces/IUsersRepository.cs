using System;
using System.Threading.Tasks;

namespace NewsPaper.Accounts.Models.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<Guid> GetGuidByNikeNameUserAsync(string userNikeName);
        Task<string> GetNikeNameByGuidUserAsync(Guid userGuid);
    }
}