using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Interface
{
    public interface IRepository<TEntity, TArg> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> Get(TArg id);
        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        Task DeleteAsync(TArg id);
    }
}
