using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPaper.Accounts.DAL;
using NewsPaper.Accounts.Models;

namespace NewsPaper.Accounts.BusinessLayer
{
    public class OperationUsersAccounts
    {
        private UnitOfWork entity;
        public OperationUsersAccounts()
        {
            entity = new UnitOfWork();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await entity.UsersRepository.GetAllAsync();
        }

        public async Task<User> GetByIdUserAsync(Guid userGuid)
        {
            return await entity.UsersRepository.GetByIdAsync(userGuid);
        }
    }
}