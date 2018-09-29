using Auction.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.EF
{
    public class MarketContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationProfile> Profiles { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }

        public MarketContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {
            Database.SetInitializer<MarketContext>(new MarketContextInitializer());
        }
        public MarketContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<MarketContext>(new MarketContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Lot>()
            //    .HasMany<Bid>(b=>b.Bids)
            //    .WithOptional(b=>b.Lot)
            //    .WillCascadeOnDelete(true);
            modelBuilder.Entity<Bid>().
                HasRequired(x=>x.Bidder).
                WithMany(x=>x.BiddenItems).
                WillCascadeOnDelete(false);
            modelBuilder.Entity<Lot>().
                HasRequired(x => x.Seller).
                WithMany(x => x.AuctionedLots).
                WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
        
        
    }
}
