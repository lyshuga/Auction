using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Identity;
using Auction.DAL.Interface;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Repostories
{
    public class UnitOfWork : IUnitOfWork
    {
        LotMarketContext db;
        IRepository<Lot> lots;
        IRepository<ApplicationProfile> profiles;
        public ApplicationUserManager UserManager { get; }
        public ApplicationRoleManager RoleManager { get; }
        public UnitOfWork(string connectionString)
        {
            db = new LotMarketContext(connectionString);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
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
        

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
