using CakeShop.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace CakeShop.Data
{
    public interface ILiteDBProvider<T> where T : ShopItem
    {
        IList<T> GetAll();
        IList<T> Find(Expression<Func<T, bool>> predicate, string collectionName = null);
        T Get(Guid id);
        void Update(T item);
        void Create(T item);
        void Delete(Guid id);
    }
}
