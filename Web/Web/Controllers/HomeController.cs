using Auction.BLL.DTO;
using Auction.BLL.Infrastructure;
using Auction.BLL.Service;
using Auction.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public async Task<string> Create()
        {

            IdentityService service = new IdentityService(new IdentityUnitOfWork("DefaultConnection"));
            UserDTO user = new UserDTO() { Name = "Kolia", Email = "kolia@gmail.com", Password = "pukpuk", Role = "admin" };
            Result result = await service.CreateAsync(user);
            return result.Message;
        }
    }
}