using Auction.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Interface
{
    public interface IMarketUnitOfWork
    {
        IRepository<ApplicationProfile, string> Profiles { get; }
        IRepository<Lot, int> Lots { get; }
        Task SaveAsync();
    }
}
