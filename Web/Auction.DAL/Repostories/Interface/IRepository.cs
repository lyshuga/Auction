using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Interface
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        Task DeleteAsync(int id);
    }
}
