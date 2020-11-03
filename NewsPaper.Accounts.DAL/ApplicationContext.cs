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
            FakeInitializerEntity.Init(2);
            modelBuilder.Entity<Author>().HasKey(u => u.Id);
            modelBuilder.Entity<Editor>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Author>().Property(b => b.IdentityGuid).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction); ;
            modelBuilder.Entity<Editor>().Property(b => b.IdentityGuid).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction); ;
            modelBuilder.Entity<User>().Property(b => b.IdentityGuid).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction); ;
            modelBuilder.Entity<Author>().HasData(FakeInitializerEntity.Authors);
            modelBuilder.Entity<Editor>().HasData(FakeInitializerEntity.Editors);
            modelBuilder.Entity<User>().HasData(FakeInitializerEntity.Users);
        }
    }
}