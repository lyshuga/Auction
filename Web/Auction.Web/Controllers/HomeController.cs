﻿using Auction.BLL.DTO;
using Auction.BLL.Infrastructure;
using Auction.BLL.Interface;
using Auction.BLL.Service;
using Auction.DAL.Repostories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
        public async Task<ActionResult> Create()
        {
            UserDTO user = new UserDTO() { Name = "Kolia", Email = "kolia@gmail.com", Password = "pukpuk", Role = "admin", Balance = 238, CreditCard = "1234567890" };
            Result result = await IdentityService.CreateAsync(user);
            return Content(result.Message);
        }
        public void CreateLot()
        {
            
            string kyky = "Kyky";
            MarketService.CreateLot(new LotDTO()
            {
                Name = kyky,
                Description = kyky,
                Price = 200,
                ExpireDate = DateTime.Now
            ,
                GoodType = kyky,
                LastBid = DateTime.Now
            ,
                StartDate = DateTime.Now
            ,
                Photo = new System.Drawing.Bitmap(100, 100),
                BidderId = "3e8299fc-ca28-4f6e-9ef9-c572a521be2f",
                SellerId = "3e8299fc-ca28-4f6e-9ef9-c572a521be2f"
            });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                IdentityService?.Dispose();
                MarketService?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}