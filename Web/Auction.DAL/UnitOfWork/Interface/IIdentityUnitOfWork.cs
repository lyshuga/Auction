using Auction.DAL.Entities;
using Auction.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Interface
{
    public interface IIdentityUnitOfWork
    {
        ApplicationUserManager UserManager { get;}
        ApplicationRoleManager RoleManager { get;}
        Task SaveAsync();
    }
}
