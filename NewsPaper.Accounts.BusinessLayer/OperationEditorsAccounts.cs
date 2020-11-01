using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPaper.Accounts.DAL;
using NewsPaper.Accounts.Models;
using NewsPaper.Accounts.Models.Exceptions;

namespace NewsPaper.Accounts.BusinessLayer
{
    public class OperationEditorsAccounts
    {
        private UnitOfWork _entity;
        public OperationEditorsAccounts()
        {
            _entity = new UnitOfWork();
        }

        public async Task<IEnumerable<Editor>> GetAllEditorsAsync()
        {
            return await _entity.EditorsRepository.GetAllAsync();
        }

        public async Task<Editor> GetByIdEditorAsync(Guid editorGuid)
        {
            return await _entity.EditorsRepository.GetByIdAsync(editorGuid);
        }

        public async Task<Guid> GetGuidByNikeNameEditorAsync(string editorNikeName)
        {
            var editorGuid = await _entity.EditorsRepository.GetGuidByNikeNameEditorAsync(editorNikeName);
            if (editorGuid == null)
                throw new NoEditorFoundException("No editor found by nickname");
            return editorGuid;
        }

        public async Task<string> GetNikeNameByGuidEditorAsync(Guid editorGuid)
        {
            var editorNikeName = await _entity.EditorsRepository.GetNikeNameByGuidEditorAsync(editorGuid);
            if (editorNikeName == null)
                throw new NoEditorFoundException("No editor found by editorId");
            return editorNikeName;
        }
    }
}