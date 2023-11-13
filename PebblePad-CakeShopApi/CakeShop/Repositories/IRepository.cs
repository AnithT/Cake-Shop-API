using CakeShop.Models;
using System;
using System.Collections.Generic;

namespace CakeShop.Repositories
{
    public interface IRepository<T> where T : ShopItem
    {
        IList<T> All();
        T GetById(Guid id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(Guid id);
    }
}