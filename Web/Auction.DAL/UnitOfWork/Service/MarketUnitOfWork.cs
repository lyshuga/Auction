using System.Threading.Tasks;
using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Interface;
using Auction.DAL.Market.Repostories;
using Auction.DAL.Repostories.Service;

namespace Auction.DAL.UnitOfWork.Service
{
    public class MarketUnitOfWork : IMarketUnitOfWork
    {
        MarketContext db;
        IRepository<Lot, int> lotRepository;
        IRepository<Bid, int> bidRepository;
        IRepository<ApplicationProfile, string> profileRepository;
        public MarketUnitOfWork(MarketContext db)
        {
            this.db = db;
        }
        public IRepository<Lot, int> Lots 
            => lotRepository ?? (lotRepository = new LotRepository(db));
        public IRepository<Bid, int> Bids
            => bidRepository ?? (bidRepository = new BidRepository(db));
        public IRepository<ApplicationProfile, string> Profiles 
            => profileRepository ?? (profileRepository = new ProfileRepository(db));

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
