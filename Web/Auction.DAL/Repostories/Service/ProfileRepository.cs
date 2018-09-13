﻿using Auction.DAL.EF;
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
    public class ProfileRepository : IRepository<ApplicationProfile>
    {
        MarketContext db;
        public ProfileRepository(MarketContext context)
        {
            db = context;
        }

        public void Create(ApplicationProfile item)
        {
            db.Profiles.Add(item);
        }

        public async Task DeleteAsync(int id)
        {
            ApplicationProfile profile = await db.Profiles.FindAsync(id);
            if (profile != null)
            {
                db.Profiles.Remove(profile);
            }
        }

        public IEnumerable<ApplicationProfile> Find(Func<ApplicationProfile, bool> predicate)
        {
            var hash = db.Database.Connection.GetHashCode();
            return db.Profiles.Include(x => x.User).Where(predicate);
        }

        public async Task<ApplicationProfile> Get(int id)
        {
            ApplicationProfile profile = await db.Profiles.FindAsync(id);
            return profile;
        }

        public IEnumerable<ApplicationProfile> GetAll()
        {
            return db.Profiles;
        }

        public void Update(ApplicationProfile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}