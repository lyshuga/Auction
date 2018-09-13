using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Repostories.Service;

namespace Auction.DAL.Market.Repostories
{
    public class ProfileRepository : AbstractService<ApplicationProfile, string>
    {
        public ProfileRepository(MarketContext context) : base(context) { }

        public override IEnumerable<ApplicationProfile> Find(Func<ApplicationProfile, bool> predicate)
        {
            return db.Profiles/*.Include(x => x.User)*/.Where(predicate);
        }

        public override async Task<ApplicationProfile> Get(string id)
        {
            ApplicationProfile profile = await db.Profiles.FindAsync(id);
            return profile;
        }
        
    }
}
