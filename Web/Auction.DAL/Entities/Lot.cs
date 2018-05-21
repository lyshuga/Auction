using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class Lot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GoodType { get; set; }
        public byte[] Photo { get; set; }
        public int SellerId { get; set; }
        public ApplicationProfile Seller { get; set; }
        public int BidderId { get; set; }
        public ApplicationProfile Bidder { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
