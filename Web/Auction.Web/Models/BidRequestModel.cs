using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using Auction.BLL.DTO;

namespace Auction.Web.Models
{
    public class BidRequestModel
    {
        public int LotId { get; set; }
        public string BidderId { get; set; }
        public decimal Price { get; set; }
    }
}