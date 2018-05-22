﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.Interface;
using Auction.BLL.Service;
using Auction.DAL.Interface;
using Auction.DAL.Repostories;
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
            Bind<IIdentityUnitOfWork>().To<IdentityUnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IMarketUnitOfWork>().To<MarketUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
