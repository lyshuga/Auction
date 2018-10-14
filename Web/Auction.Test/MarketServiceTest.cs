using Auction.BLL.Service;
using Auction.DAL.Repostories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace Auction.Test
{
    [TestFixture]
    public class MarketServiceTest
    {
        //[Test]
        //public void Create_ShouldBeNoExcpetions()
        //{
        //    try
        //    {
        //        DAL.EF.MarketContext context = new DAL.EF.MarketContext("DefaultConnection");
        //        context.Lots.Add(new DAL.Entities.Lot()
        //        {
        //            Name = "kyky",
        //            Description = "kyky",
        //            Price = 200,
        //            Photo = new byte[100],
        //            StartDate = DateTime.Now,
        //            ExpireDate = DateTime.Now,
        //            Bidder = context.Profiles.First(),
        //            GoodType = "kyky",
        //            LastBid = DateTime.Now,
        //            Seller = context.Profiles.First()
        //        });
        //        context.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        string s = "";
        //        foreach (var entityValidationErrors in ex.EntityValidationErrors)
        //        {
        //            foreach (var validationError in entityValidationErrors.ValidationErrors)
        //            {
        //                s += "Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage;
        //            }
        //        }
        //        throw new Exception(s);
        //    }
            

        //    //MarketService marketService = new MarketService(new MarketUnitOfWork(new DAL.EF.LotMarketContext( "DefaultConnection")));
        //    //string kyky = "Kyky";
        //    //marketService.CreateLot(new BLL.DTO.LotDTO()
        //    //{
        //    //    Name = kyky,
        //    //    Description = kyky,
        //    //    Price = 200,
        //    //    ExpireDate = DateTime.Now
        //    //,
        //    //    GoodType = kyky,
        //    //    LastBid = DateTime.Now
        //    //,
        //    //    StartDate = DateTime.Now
        //    //,
        //    //    Photo = new byte[100]
        //    //});

        }
    }
//}
