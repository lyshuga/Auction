using Auction.DAL.Entities;
using Auction.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Interface
{
    public interface IUnitOfWork
    {
        IRepository<ApplicationProfile> Profiles { get; }
        IRepository<Lot> Lots { get;}
        ApplicationUserManager UserManager { get;}
        ApplicationRoleManager RoleManager { get;}
        Task SaveAsync();
    }
}
