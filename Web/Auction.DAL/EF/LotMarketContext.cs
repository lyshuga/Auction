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
    public class LotMarketContext:IdentityDbContext<ApplicationUser>
    {
        public LotMarketContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {
            
        }
        public LotMarketContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<ApplicationProfile> Profiles { get; set; }
        public DbSet<Lot> Lots { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
            modelBuilder.Entity<Lot>()
                        .Property(c => c.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
