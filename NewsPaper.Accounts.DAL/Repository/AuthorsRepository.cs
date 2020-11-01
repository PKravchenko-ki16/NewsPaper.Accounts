using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPaper.Accounts.Models;
using NewsPaper.Accounts.Models.Interfaces;

namespace NewsPaper.Accounts.DAL.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly ApplicationContext _context;

        public AuthorsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Author.ToListAsync();
        }
        
        public async Task<Author> GetByIdAsync(Guid authorGuid)
        {
            return await _context.Author.Where(x => x.Id == authorGuid).FirstOrDefaultAsync();
        }

        public async Task<Guid> GetGuidByNikeNameAuthorAsync(string authorNikeName)
        {
            return await _context.Author.Where(x => x.NikeName == authorNikeName).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<string> GetNikeNameByGuidAuthorAsync(Guid authorGuid)
        {
            return await _context.Author.Where(x => x.Id == authorGuid).Select(x => x.NikeName).FirstOrDefaultAsync();
        }
    }
}