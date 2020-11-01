using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPaper.Accounts.Models;
using NewsPaper.Accounts.Models.Interfaces;

namespace NewsPaper.Accounts.DAL.Repository
{
    public class EditorsRepository : IEditorsRepository
    {
        private readonly ApplicationContext _context;

        public EditorsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Editor>> GetAllAsync()
        {
            return await _context.Editor.ToListAsync();
        }

        public async Task<Editor> GetByIdAsync(Guid editorGuid)
        {
            return await _context.Editor.Where(x => x.Id == editorGuid).FirstOrDefaultAsync();
        }
    }
}