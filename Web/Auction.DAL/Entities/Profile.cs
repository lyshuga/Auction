using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class Profile
    {
        [ForeignKey("User")]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Balance { get; set; }
        public string CreditCard { get; set; }
        public User User { get; set; }
        [InverseProperty("Seller")]
        public virtual ICollection<Lot> AuctionedLots { get; set; }
        [InverseProperty("Bidder")]
        public virtual ICollection<Lot> BiddenLots { get; set; }
    }
}
