using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.DTO
{
    public class BidDTO
    {
        public int Id { get; set; }
        public ApplicationProfileDTO Bidder { get; set; }
        public decimal Price { get; set; }
        public LotDTO Lot { get; set; }
        public DateTime Time { get; set; }
    }
}
