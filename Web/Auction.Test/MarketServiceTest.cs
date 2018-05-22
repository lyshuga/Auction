using Auction.BLL.Service;
using Auction.DAL.Repostories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Test
{
    [TestFixture]
    public class MarketServiceTest
    {
        [Test]
        public void Create_ShouldBeNoExcpetions()
        {
            MarketService marketService = new MarketService(new MarketUnitOfWork("DefaultConnection"));
            string kyky = "Kyky";
            marketService.CreateLot(new BLL.DTO.LotDTO()
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
                Photo = new System.Drawing.Bitmap(100, 100)
            });

        }
    }
}
