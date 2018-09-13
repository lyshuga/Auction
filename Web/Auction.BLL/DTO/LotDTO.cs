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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GoodType { get; set; }
        public byte[] Photo { get; set; }
        public decimal Price { get; set; }
        public ApplicationProfileDTO Seller { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public BidDTO LastBid { get; set; }
    }
}
