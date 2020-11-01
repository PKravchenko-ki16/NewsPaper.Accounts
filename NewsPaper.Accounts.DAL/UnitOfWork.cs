using System;
using NewsPaper.Accounts.DAL.Repository;
using NewsPaper.Accounts.Models.Interfaces;

namespace NewsPaper.Accounts.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context = new ApplicationContext();
        private AuthorsRepository _authors;
        private EditorsRepository _editors;
        private UsersRepository _users;

        public IUsersRepository UsersRepository => _users ?? (_users = new UsersRepository(_context));

        public IAuthorsRepository AuthorsRepository => _authors ?? (_authors = new AuthorsRepository(_context));

        public IEditorsRepository EditorsRepository => _editors ?? (_editors = new EditorsRepository(_context));

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Discard()
        {
            _context.Dispose();
            _context = new ApplicationContext();
        }
    }
}