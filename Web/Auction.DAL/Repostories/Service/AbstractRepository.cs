using Auction.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.EF;
using Auction.DAL.Entities;

namespace Auction.DAL.Repostories.Service
{
    public abstract class AbstractRepository<TEntity, TArg> : IRepository<TEntity, TArg> where TEntity: class
    {
        protected MarketContext db;
        public AbstractRepository(MarketContext context)
        {
            db = context;
        }
        public void Create(TEntity item)
        {
            var entity = db.Set<TEntity>().Add(item);
        }

        public async Task DeleteAsync(TArg id)
        {
            var entity = await db.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                db.Set<TEntity>().Remove(entity);
            }
        }
        public abstract IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        public abstract Task<TEntity> Get(TArg id);

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public void Update(TEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
