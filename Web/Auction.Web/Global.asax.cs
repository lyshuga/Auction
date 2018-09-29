using Auction.BLL.Infrastructure;
using Auction.Web.Util;
using AutoMapper;
using Ninject;
using Ninject.Web.Mvc;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Auction.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
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
