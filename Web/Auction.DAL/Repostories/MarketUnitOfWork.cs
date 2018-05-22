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
        LotMarketContext db;
        IRepository<Lot> lots;
        IRepository<ApplicationProfile> profiles;
        public MarketUnitOfWork(string connectionString)
        {
            db = new LotMarketContext(connectionString);
        }
        public IRepository<Lot> Lots
        {
            get
            {
                if (lots == null)
                {
                    lots = new LotRepository(db);
                }
                return lots;
            }
        }
        public IRepository<ApplicationProfile> Profiles
        {
            get
            {
                if (profiles == null)
                {
                    profiles = new ProfileRepository(db);
                }
                return profiles;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
