using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.Interface;
using Auction.BLL.Service;
using Auction.DAL.EF;
using Auction.DAL.Interface;
using Auction.DAL.Repostories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Auction.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<MarketContext>().To<MarketContext>().InRequestScope().WithConstructorArgument(connectionString);
            Bind<IIdentityUnitOfWork>().To<IdentityUnitOfWork>().InRequestScope();
            Bind<IMarketUnitOfWork>().To<MarketUnitOfWork>().InRequestScope();
        }
    }
}
