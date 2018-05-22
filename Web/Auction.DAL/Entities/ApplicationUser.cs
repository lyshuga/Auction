using Auction.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ApplicationProfile ApplicationProfile { get;set; }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            throw new NotImplementedException();
        }
    }
}
