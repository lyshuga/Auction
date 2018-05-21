using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.EF
{
    class LotMarketContextInitializer: DropCreateDatabaseAlways<LotMarketContext>
    {
        protected override void Seed(LotMarketContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            base.Seed(context);
        }
    }
}
