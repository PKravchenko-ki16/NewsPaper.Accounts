﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPaper.Accounts.Models;
using NewsPaper.Accounts.Models.Interfaces;

namespace NewsPaper.Accounts.DAL.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext _context;

        public UsersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid userGuid)
        {
            return await _context.User.Where(x => x.Id == userGuid).FirstOrDefaultAsync();
        }

        public async Task<Guid> GetGuidByNikeNameUserAsync(string userNikeName)
        {
            return await _context.User.Where(x => x.NikeName == userNikeName).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<string> GetNikeNameByGuidUserAsync(Guid userGuid)
        {
            return await _context.User.Where(x => x.Id == userGuid).Select(x => x.NikeName).FirstOrDefaultAsync();
        }
    }
}