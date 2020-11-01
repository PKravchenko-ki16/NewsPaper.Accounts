using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPaper.Accounts.DAL;
using NewsPaper.Accounts.Models;

namespace NewsPaper.Accounts.BusinessLayer
{
    public class OperationAuthorsAccounts
    {
        private UnitOfWork entity;
        public OperationAuthorsAccounts()
        {
            entity = new UnitOfWork();
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await entity.AuthorsRepository.GetAllAsync();
        }

        public async Task<Author> GetByIdAuthorAsync(Guid authorIGuid)
        {
            return await entity.AuthorsRepository.GetByIdAsync(authorIGuid);
        }
    }
}