namespace NewsPaper.Accounts.Models.Interfaces
{
    public interface IUnitOfWork
    {
        IUsersRepository UsersRepository { get; }
        IAuthorsRepository AuthorsRepository { get; }
        IEditorsRepository EditorsRepository { get; }
        bool SaveChanges();
        void Discard();
    }
}