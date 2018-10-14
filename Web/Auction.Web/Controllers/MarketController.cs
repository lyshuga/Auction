using Auction.BLL.DTO;
using Auction.BLL.Interface;
using Auction.Web.Models;
using Microsoft.AspNet.Identity;
using Ninject;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Auction.Web.Controllers
{
    //[Authorize]
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
        public async Task<ActionResult> CreateLot(CreateLotModel model, HttpPostedFileBase upload)
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


                    var result = await MarketService.CreateLot(lot);
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
        
        public async Task<ActionResult> LotDetails(int id)
        {
            var lot = await MarketService.GetLotAsync(id);
            //var lastBid = lot.Bids.LastOrDefault();
            var bidderId = User.Identity.GetUserId();
            DetailsLotModel model = new DetailsLotModel()
            {
                Id = id,
                Name = lot.Name,
                Description = lot.Description,
                Photo = Convert.ToBase64String(lot.Photo),
                GoodType = lot.GoodType,
                StartDate = lot.StartDate,
                ExpireDate = lot.ExpireDate,
                //Price = lastBid?.Price ?? lot.StartPrice,
                LastBid = lot.Bids.LastOrDefault(),
                SellerName =  lot.Seller.Name,
                //BidderName = lastBid?.Bidder.Name,
                BidderId = bidderId
            };
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> GetPrice(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var bid = MarketService.FindBid(id.Value);
                BidRequestModel bidResponse;
                if (bid == null)
                {
                    var lot = await MarketService.GetLotAsync(id.Value);
                    bidResponse = new BidRequestModel()
                    {
                        BidderId = lot.Seller.Id,
                        Price = lot.StartPrice
                    };
                }
                else
                {
                    bidResponse = new BidRequestModel()
                    {
                        BidderId = bid.Bidder.Id,
                        Price = bid.Price
                    };
                }
                return Json(bidResponse, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public async Task<HttpStatusCode> MakeBid(BidRequestModel model)
        {
            BidDTO bid = new BidDTO()
            {
                Bidder = new ApplicationProfileDTO() {Id = model.BidderId},
                Lot = new LotDTO() {Id = model.LotId},
                Time = DateTime.Now,
                Price = model.Price
            };
            await MarketService.MakeBidAsync(bid);
            return HttpStatusCode.OK;
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return await new Task<ActionResult>(() => new HttpStatusCodeResult(HttpStatusCode.BadRequest)); 
            }
            LotDTO lots = MarketService.GetLots(null).First();
            if (lots == null)
            {
                return await new Task<ActionResult>(() => new HttpStatusCodeResult(HttpStatusCode.NotFound));
            }

            await MarketService.DeleteLotAsync(id.Value);
            return RedirectToAction("Profile");
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarketService.DeleteLotAsync(id);
            return RedirectToAction("Index", "Home");
        }

        public new async Task<ActionResult> Profile()
        {
            string userId = User.Identity.GetUserId();
            var profile = await MarketService.GetProfile(userId);
            ViewBag.Lots = MarketService.GetLots(profile);
            ViewBag.Profile = profile;
            return View();
        }
        public ActionResult AllLots()
        {
            var lots = MarketService.GetLots(null);
            return View(lots);
        }
    }
}