namespace NewsPaper.Accounts.Models.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> UsersRepository { get; }
        IRepository<Author> AuthorsRepository { get; }
        IRepository<Editor> EditorsRepository { get; }
        bool SaveChanges();
        void Discard();
    }
}