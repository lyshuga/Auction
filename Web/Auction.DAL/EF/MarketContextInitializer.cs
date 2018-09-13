using System;
using Auction.DAL.Entities;
using Auction.DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;

namespace Auction.DAL.EF
{
    public class MarketContextInitializer: DropCreateDatabaseIfModelChanges<MarketContext>
    {
        protected override void Seed(MarketContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            var role1 = new ApplicationRole { Name = "admin" };
            var role2 = new ApplicationRole { Name = "moder" };
            var role3 = new ApplicationRole { Name = "user" };
            
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            ApplicationUser admin;
            admin = new ApplicationUser
            {
                Email = "admin@gmail.com", UserName = "admin@gmail.com",
                ApplicationProfile = new ApplicationProfile()
                    {
                        Name = "Admin",
                        Balance = 30,
                        CreditCard = "sdsd"
                    }
            };
            admin.ApplicationProfile.User = admin;
            string password = "adminKiller";
            var result = userManager.Create(admin, password);
            
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            Lot Lot = new Lot()
            {
                Name = "KK",
                Description = "DSec",
                GoodType = "DD",
                StartPrice = 200,
                StartDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                Seller = admin.ApplicationProfile
            };
            context.Lots.Add(Lot);

            var user = new ApplicationUser { Email = "user@gmail.com", UserName = "user@gmail.com" };
            password = "userBoy";
            result = userManager.Create(user, password);
            
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, role3.Name);
            }
            var list = userManager.Users.ToList();
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
