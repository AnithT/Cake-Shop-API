using CakeShop.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CakeShop.Data
{
    public class LiteDBProvider<T>: ILiteDBProvider<T> where T : ShopItem
    {
        private readonly LiteRepository liteRepository;
        public LiteDBProvider(string dbName)
        {
            
            this.liteRepository = new LiteRepository(dbName);
        }


        public IList<T> GetAll()
        {
            return liteRepository.Query<T>().ToList();
        }

        public IList<T> Find(Expression<Func<T, bool>> predicate, string collectionName = null)
        {
            return liteRepository.Fetch(predicate, collectionName);
        }

        public T Get(Guid id)
        {
            return GetAll().FirstOrDefault<T>(x => x.Id == id);
        }

        public void Update(T item)
        {
            liteRepository.Update(item);
        }

        public void Create(T item)
        {
            liteRepository.Insert(item);
        }

        public void Delete(Guid id)
        {
            liteRepository.Delete<T>(x => x.Id == id);
        }
    }
}
