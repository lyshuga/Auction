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
    public class LotMarketContextInitializer: DropCreateDatabaseAlways<LotMarketContext>
    {
        protected override void Seed(LotMarketContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            var role1 = new ApplicationRole { Name = "admin" };
            var role2 = new ApplicationRole { Name = "moder" };
            var role3 = new ApplicationRole { Name = "user" };
            
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            var admin = new ApplicationUser { Email = "admin@gmail.com", UserName = "admin@gmail.com" };
            string password = "adminKiller";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            var user = new ApplicationUser { Email = "user@gmail.com", UserName = "user@gmail.com" };
            password = "userBoy";
            result = userManager.Create(user, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role3.Name);
            }
            var list = userManager.Users.ToList();
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
