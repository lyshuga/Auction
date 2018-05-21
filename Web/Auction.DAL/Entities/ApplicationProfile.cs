using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class ApplicationProfile
    {
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string CreditCard { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Lot> AuctionedLots { get; set; }
        public virtual ICollection<Lot> BiddenLots { get; set; }
    }
}
