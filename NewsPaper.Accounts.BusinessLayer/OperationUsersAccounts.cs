using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPaper.Accounts.DAL;
using NewsPaper.Accounts.Models;
using NewsPaper.Accounts.Models.Exceptions;

namespace NewsPaper.Accounts.BusinessLayer
{
    public class OperationUsersAccounts
    {
        private UnitOfWork _entity;
        public OperationUsersAccounts()
        {
            _entity = new UnitOfWork();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _entity.UsersRepository.GetAllAsync();
        }

        public async Task<User> GetByIdUserAsync(Guid userGuid)
        {
            return await _entity.UsersRepository.GetByIdAsync(userGuid);
        }

        public async Task<Guid> GetGuidByNikeNameUserAsync(string userNikeName)
        {
            var userGuid = await _entity.UsersRepository.GetGuidByNikeNameUserAsync(userNikeName);
            if (userGuid == null)
                throw new NoUserFoundException("No user found by nickname");
            return userGuid;
        }

        public async Task<string> GetNikeNameByGuidUserAsync(Guid userGuid)
        {
            var userNikeName = await _entity.UsersRepository.GetNikeNameByGuidUserAsync(userGuid);
            if (userNikeName == null)
                throw new NoUserFoundException("No user found by userId");
            return userNikeName;
        }
    }
}