using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.ApplicationLogic.Abstractions;
using BookShop.ApplicationLogic.Model;
namespace BookShop.EFDataAccess
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        protected readonly BookShopDBContext dbContext;
        public BaseRepository(BookShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public T Add(T itemToAdd)
        {
            var entity = dbContext.Add<T>(itemToAdd);
            dbContext.SaveChanges();
            return entity.Entity;
        }

        public bool Delete(T itemToDelete)
        {
            dbContext.Remove<T>(itemToDelete);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>()
                            .AsEnumerable();
        }

        public T Update(T itemToUpdate)
        {
            var entity = dbContext.Update<T>(itemToUpdate);
            dbContext.SaveChanges();
            return entity.Entity;
        }
    }
}
