using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPaper.Accounts.DAL;
using NewsPaper.Accounts.Models;
using NewsPaper.Accounts.Models.Exceptions;

namespace NewsPaper.Accounts.BusinessLayer
{
    public class OperationAuthorsAccounts
    {
        private UnitOfWork _entity;
        public OperationAuthorsAccounts()
        {
            _entity = new UnitOfWork();
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _entity.AuthorsRepository.GetAllAsync();
        }

        public async Task<Author> GetByIdAuthorAsync(Guid authorGuid)
        {
            return await _entity.AuthorsRepository.GetByIdAsync(authorGuid);
        }

        public async Task<Guid> GetGuidByNikeNameAuthorAsync(string authorNikeName)
        {
            var authorGuid = await _entity.AuthorsRepository.GetGuidByNikeNameAuthorAsync(authorNikeName);
            if (authorGuid == null)
                throw new NoAuthorFoundException("No author found by nickname");
            return authorGuid;
        }

        public async Task<string> GetNikeNameByGuidAuthorAsync(Guid authorGuid)
        {
            var authorNikeName = await _entity.AuthorsRepository.GetNikeNameByGuidAuthorAsync(authorGuid);
            if (authorNikeName == null)
                throw new NoAuthorFoundException("No author found by authorId");
            return authorNikeName;
        }
    }
}