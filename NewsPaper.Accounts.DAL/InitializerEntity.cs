using System;
using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;
using NewsPaper.Accounts.Models;

namespace NewsPaper.Accounts.DAL
{
    public static class FakeInitializerEntity
    {
        public static List<Author> Authors = new List<Author>();
        public static List<Editor> Editors = new List<Editor>();
        public static List<User> Users = new List<User>();

        public static void Init(int count)
        {
            var authorsFaker = new Faker<Author>("ru")
                .RuleFor(x => x.FullName, f => f.Name.FullName(Name.Gender.Male))
                .RuleFor(x => x.NikeName, f => f.Name.FirstName(Name.Gender.Male))
                .RuleFor(x => x.Email, f => f.Internet.Email());

            var editorsFaker = new Faker<Editor>("ru")
                .RuleFor(x => x.FullName, f => f.Name.FullName(Name.Gender.Male))
                .RuleFor(x => x.NikeName, f => f.Name.FirstName(Name.Gender.Male))
                .RuleFor(x => x.Email, f => f.Internet.Email());

            var usersFaker = new Faker<User>("ru")
                .RuleFor(x => x.NikeName, f => f.Name.FirstName(Name.Gender.Male));

            var authors = authorsFaker.Generate(count);
            var editors = editorsFaker.Generate(count);
            var users = usersFaker.Generate(count);

            InitId(count);
            SetAuthors(authors, editors, users);
        }

        private static void InitId(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Authors.Add(new Author(Guid.NewGuid(), Guid.NewGuid()));
                Editors.Add(new Editor(Guid.NewGuid(), Guid.NewGuid()));
                Users.Add(new User(Guid.NewGuid(), Guid.NewGuid()));
            }
        }

        private static void SetAuthors(List<Author> authors, List<Editor> editors, List<User> users)
        {
            for (int i = 0; i < Authors.Count; i++)
            {
                Authors[i].NikeName = authors[i].NikeName;
                Authors[i].FullName = authors[i].FullName;
                Authors[i].Email = authors[i].Email;
                
                Editors[i].NikeName = editors[i].NikeName;
                Editors[i].FullName = editors[i].FullName;
                Editors[i].Email = editors[i].Email;

                Users[i].NikeName = users[i].NikeName;
            }
        }
    }
}