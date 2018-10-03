using Auction.BLL.Interface;
using Ninject;
using System.Web.Mvc;

namespace Auction.Web.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        private IIdentityService IdentityService { get; set; }
        [Inject]
        private IMarketService MarketService { get; set; }
        public HomeController(IIdentityService identity, IMarketService market)
        {
            IdentityService = identity;
            MarketService = market;
        }
        public ActionResult Index()
        {
            return RedirectToAction("AllLots", "Market");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public void CreateLot()
        //{
            
        //    string kyky = "Kyky";
        //    MarketService.CreateLot(new LotDTO()
        //    {
        //        Name = kyky,
        //        Description = kyky,
        //        Price = 200,
        //        ExpireDate = DateTime.Now
        //    ,
        //        GoodType = kyky,
        //        LastBid = DateTime.Now
        //    ,
        //        StartDate = DateTime.Now
        //    ,
        //        Photo = new byte[100],
        //        BidderId = "3e8299fc-ca28-4f6e-9ef9-c572a521be2f",
        //        SellerId = "3e8299fc-ca28-4f6e-9ef9-c572a521be2f"
        //    });
        //}
    }
}