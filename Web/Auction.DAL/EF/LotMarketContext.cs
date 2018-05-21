using Auction.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.EF
{
    class LotMarketContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationProfile> Profiles;
        public DbSet<Lot> Lots;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lot>()
                        .HasRequired(m => m.Seller)
                        .WithMany(t => t.AuctionedLots)
                        .HasForeignKey(m => m.SellerId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lot>()
                        .HasRequired(m => m.Bidder)
                        .WithMany(t => t.BiddenLots)
                        .HasForeignKey(m => m.BidderId)
                        .WillCascadeOnDelete(false);
        }
    }
}
