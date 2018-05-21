using Auction.DAL.Entities;
using Auction.DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            var userManager = new ApplicationRoleManager(new UserStore<ApplicationUser>(context));

            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            base.Seed(context);
        }
    }
}
