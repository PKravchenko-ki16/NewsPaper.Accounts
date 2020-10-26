﻿using System.Collections.Generic;

namespace NewsPaper.Accounts.Models.Interfaces
{
    public interface IRepository<T>
        where T : IDomainObject, new()
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T obj);
        void Delete(T obj);
        void Create(T obj);
    }
}