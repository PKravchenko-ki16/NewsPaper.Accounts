using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPaper.Accounts.DAL;
using NewsPaper.Accounts.Models;

namespace NewsPaper.Accounts.BusinessLayer
{
    public class OperationEditorsAccounts
    {
        private UnitOfWork entity;
        public OperationEditorsAccounts()
        {
            entity = new UnitOfWork();
        }

        public async Task<IEnumerable<Editor>> GetAllEditorsAsync()
        {
            return await entity.EditorsRepository.GetAllAsync();
        }

        public async Task<Editor> GetByIdEditorAsync(Guid editorGuid)
        {
            return await entity.EditorsRepository.GetByIdAsync(editorGuid);
        }
    }
}