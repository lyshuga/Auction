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
    public class ProfileRepository : IRepository<Profile>
    {
        LotMarketContext db;
        public ProfileRepository(LotMarketContext context)
        {
            db = context;
        }

        public void Create(Profile item)
        {
            db.Profiles.Add(item);
        }

        public async Task DeleteAsync(int id)
        {
            Profile profile = await db.Profiles.FindAsync(id);
            if (profile != null)
            {
                db.Profiles.Remove(profile);
            }
        }

        public IEnumerable<Profile> Find(Func<Profile, bool> predicate)
        {
            var hash = db.Database.Connection.GetHashCode();
            return db.Profiles.Include(x => x.User).Where(predicate);
        }

        public async Task<Profile> Get(int id)
        {
            Profile profile = await db.Profiles.FindAsync(id);
            return profile;
        }

        public IEnumerable<Profile> GetAll()
        {
            return db.Profiles;
        }

        public void Update(Profile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
