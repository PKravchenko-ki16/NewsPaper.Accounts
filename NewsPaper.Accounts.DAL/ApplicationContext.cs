using Microsoft.EntityFrameworkCore;
using NewsPaper.Accounts.Models;

namespace NewsPaper.Accounts.DAL
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Editor> Editor { get; set; }
        public DbSet<User> User { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-U4JR3LV;Database=NewsPaperAccountsDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FakeInitializerEntity.Init(10);
            //modelBuilder.Entity<Article>().HasKey(u => u.Id);
            //modelBuilder.Entity<Article>().HasData(FakeInitializerEntity.Article);
        }
    }
}