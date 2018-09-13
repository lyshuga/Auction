using Auction.BLL.Interface;
using Auction.Web.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.IO;
using Auction.BLL.DTO;
using System.Net;

namespace Auction.Web.Controllers
{
    [Authorize]
    public class MarketController : Controller
    {
        [Inject]
        private IMarketService MarketService { get; set; }
        public MarketController(IMarketService market)
        {
            MarketService = market;
        }
        [HttpGet]
        public ActionResult CreateLot()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLot(CreateLotModel model, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0 && upload.ContentLength < 999999)
                {
                    string sellerId = User.Identity.GetUserId();
                    byte[] b;
                    using (BinaryReader br = new BinaryReader(upload.InputStream))
                    {
                        b = br.ReadBytes((int)upload.InputStream.Length);
                    }
                    LotDTO lot = new LotDTO()
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Photo = b,
                        GoodType = model.GoodType,
                        StartDate = model.StartDate,
                        ExpireDate = model.ExpireDate,
                        StartPrice = model.Price,
                        Seller = new ApplicationProfileDTO() { Id = sellerId }
                    };


                    var result = MarketService.CreateLot(lot);
                    if (!result.Succedeed)
                    {
                        ModelState.AddModelError("", result.Message);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            return View(model);
        }
        
        public ActionResult LotDetails(int id)
        {
            string userId = User.Identity.GetUserId();
            var profile = MarketService.GetProfile(userId);
            var lot = MarketService.GetLots(profile).First(x => x.Id == id);
            DetailsLotModel model = new DetailsLotModel()
            {
                Id = id,
                Name = lot.Name,
                Description = lot.Description,
                Photo = Convert.ToBase64String(lot.Photo),
                GoodType = lot.GoodType,
                StartDate = lot.StartDate,
                ExpireDate = lot.ExpireDate,
                Price = lot.StartPrice,
                LastBid = lot.StartDate
                //,
                //BidderId = lot.LastBid.Bidder.Name,
                //SellerId = lot.Seller.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> MakeBid(DetailsLotModel model)
        {
            LotDTO lotDTO = new LotDTO() { Id = model.Id, StartPrice = model.Price };
            await MarketService.EditLotAsync(lotDTO);
            return RedirectToAction("LotDetails", new { id = model.Id });
        }
        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LotDTO lots = MarketService.GetLots(null).First();
        //    if (lots == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    MarketService.DeleteLotAsync
        //    return RedirectToAction("Profile");
        //}


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Suppliers suppliers = db.Suppliers.Find(id);
        //    db.Suppliers.Remove(suppliers);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public new ActionResult Profile()
        {
            string userId = User.Identity.GetUserId();
            var profile = MarketService.GetProfile(userId);
            ViewBag.Lots = MarketService.GetLots(profile);
            ViewBag.Profile = profile;
            return View();
        }
    }
}