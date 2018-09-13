using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Interface;
using Auction.DAL.Market.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Repostories
{
    public class MarketUnitOfWork : IMarketUnitOfWork
    {
        MarketContext db;
        IRepository<Lot> lotRepository;
        IRepository<ApplicationProfile> profileRepository;
        public MarketUnitOfWork(MarketContext db)
        {
            this.db = db;
        }
        public IRepository<Lot> Lots => lotRepository ?? (lotRepository = new LotRepository(db));
        public IRepository<ApplicationProfile> Profiles => profileRepository ?? (profileRepository = new ProfileRepository(db));

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
