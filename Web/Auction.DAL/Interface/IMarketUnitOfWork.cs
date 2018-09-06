using Auction.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Interface
{
    public interface IMarketUnitOfWork:IDisposable
    {
        IRepository<Profile> Profiles { get; }
        IRepository<Lot> Lots { get; }
        Task SaveAsync();
    }
}
