using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class ApplicationProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Balance { get; set; }
        public string CreditCard { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<Lot> AuctionedLots { get; set; }
        public virtual ICollection<Bid> BiddenItems { get; set; }
    }
}
