using CakeShop.Data;
using CakeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeShop.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : ShopItem
    {
        private readonly ILiteDBProvider<T> liteDBProvider;
        public Repository(ILiteDBProvider<T> liteDBProvider)
        {
            this.liteDBProvider = liteDBProvider;
        }
        public IList<T> All()
        {
            return liteDBProvider.GetAll();
        }

        public T GetById(Guid id)
        {
            return liteDBProvider.Get(id);
        }

        public bool Add(T item)
        {
            if (liteDBProvider.GetAll().Any(i => item.Id == i.Id))
            {
                return false;
            }
            liteDBProvider.Create(item);
            return true;
        }

        public bool Update(T item)
        {
            if (!Delete(item.Id))
            {
                return false;
            }
            liteDBProvider.Create(item);
            return true;
        }

        public bool Delete(Guid id)
        {
            var foundItem = GetById(id);
            if (foundItem == default(T))
            {
                return false;
            }
            liteDBProvider.Delete(foundItem.Id);
            return true;
        }
    }
}
