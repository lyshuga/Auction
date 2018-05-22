using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class Lot
    {

        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string GoodType { get; set; }
        public byte[] Photo { get; set; }
        [Required]
        public string SellerId { get; set; }
        [ForeignKey("SellerId")]
        public ApplicationProfile Seller { get; set; }
        [Required]
        public string BidderId { get; set; }
        [ForeignKey("BidderId")]
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
