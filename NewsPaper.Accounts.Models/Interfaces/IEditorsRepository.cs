using System;
using System.Threading.Tasks;

namespace NewsPaper.Accounts.Models.Interfaces
{
    public interface IEditorsRepository : IRepository<Editor>
    {
        Task<Guid> GetGuidByNikeNameEditorAsync(string editorNikeName);
        Task<string> GetNikeNameByGuidEditorAsync(Guid editorGuid);
    }
}