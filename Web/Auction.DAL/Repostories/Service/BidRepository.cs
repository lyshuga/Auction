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
    public class BidRepository : AbstractRepository<Bid, int>
    {
        public BidRepository(MarketContext context) : base(context) { }
        public override IEnumerable<Bid> Find(Func<Bid, bool> predicate)
        {
            return db.Bids.Include(x => x.Bidder).Include(x => x.Lot).Where(predicate).AsEnumerable();
        }

        public override Task<Bid> Get(int id)
        {
            return db.Bids.Include(x => x.Bidder).Include(x => x.Lot).FirstAsync(x => x.Id == id);
        }
    }
}
