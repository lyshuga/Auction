using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.Interface;
using Auction.BLL.Service;
using Ninject.Modules;

namespace Web.Util
{
    public class ControllerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IIdentityService>().To<IdentityService>();
            Bind<IMarketService>().To<MarketService>();
        }
    }
}
