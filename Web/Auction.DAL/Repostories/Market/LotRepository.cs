using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Market.Repostories
{
    public class LotRepository : IRepository<Lot>
    {
        LotMarketContext db;
        public LotRepository(LotMarketContext context)
        {
            db = context;
        }
        public void Create(Lot item)
        {
            db.Lots.Add(item);
        }

        public async Task DeleteAsync(int id)
        {
            Lot lot = await db.Lots.FindAsync(id);
            if (lot !=null)
            {
                db.Lots.Remove(lot);
            }
        }

        public IEnumerable<Lot> Find(Func<Lot, bool> predicate)
        {
            return db.Lots.Where(predicate);
        }

        public async Task<Lot> Get(int id)
        {
            Lot lot = await db.Lots.FindAsync(id);
            return lot;
        }

        public IEnumerable<Lot> GetAll()
        {
            return db.Lots;
        }

        public void Update(Lot item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
