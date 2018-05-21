using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class Lot
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string GoodType { get; set; }
        public byte[] Photo { get; set; }
        [Required]
        public int SellerId { get; set; }
        public ApplicationProfile Seller { get; set; }
        [Required]
        public int BidderId { get; set; }
        public ApplicationProfile Bidder { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        [Required]
        public DateTime LastBid { get; set; }
    }
}
