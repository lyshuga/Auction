using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Interface;
using Auction.DAL.Repostories.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Market.Repostories
{
    public class LotRepository : AbstractService<Lot, int>
    {
        public LotRepository(MarketContext context):base(context){}

        public override IEnumerable<Lot> Find(Func<Lot, bool> predicate)
        {
            return db.Lots./*Include(x=>x.Seller).Include(x=>x.LastBid).*/Where(predicate).AsEnumerable();
        }

        public override async Task<Lot> Get(int id)
        {
            Lot lot = await db.Lots/*.Include(x => x.Seller).Include(x => x.Bids)*/.FirstAsync(x => x.Id == id);
            return lot;
        }
    }
}
