using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.Interface;
using Auction.BLL.Service;
using Ninject.Modules;

namespace Auction.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IIdentityService>().To<IdentityService>().WithConstructorArgument(connectionString);
            Bind<IMarketService>().To<MarketService>().WithConstructorArgument(connectionString);
        }
    }
}
