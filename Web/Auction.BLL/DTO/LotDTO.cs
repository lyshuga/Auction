using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Auction.BLL.BusinessModels;

namespace Auction.BLL.DTO
{
    public class LotDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GoodType { get; set; }
        public Image Photo { get; set; }
        public decimal Price { get; set; }
        public string BidderId { get; set; }
        public string SellerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime LastBid { get; set; }
    }
}
