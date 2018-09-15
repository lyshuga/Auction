using System.Threading.Tasks;
using Auction.DAL.EF;
using Auction.DAL.Entities;
using Auction.DAL.Identity;
using Auction.DAL.Interface;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Auction.DAL.UnitOfWork.Service
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        MarketContext db;
        
        public ApplicationUserManager UserManager { get; }
        public ApplicationRoleManager RoleManager { get; }
        public IdentityUnitOfWork(MarketContext db)
        {
            this.db = db;
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
        }
        
        
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
