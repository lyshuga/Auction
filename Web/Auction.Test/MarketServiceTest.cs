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
            MarketService marketService = new MarketService(new MarketUnitOfWork("DefaultConnection"))
        }
    }
}
