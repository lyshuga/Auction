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

        public MarketContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {
            
        }
        public MarketContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        
        
    }
}
