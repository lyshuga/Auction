using Auction.BLL.Infrastructure;
using Auction.DAL.EF;
using Ninject;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Auction.Web.Util;
using AutoMapper;

namespace Auction.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<MarketContext>(new MarketContextInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cfg =>
                AutoMapperConfiguration.Configure(cfg)
            );
            ServiceModule service = new ServiceModule("DefaultConnection");
            ControllerModule controller = new ControllerModule();
            var kernel = new StandardKernel(service, controller);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            ModelValidatorProviders.Providers.Clear();
            //FluentValidationModelValidatorProvider.Configure(provider => provider.AddImplicitRequiredValidator = false);
        }
    }
}
