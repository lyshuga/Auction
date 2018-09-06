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
    public class LotMarketContext:IdentityDbContext<User>
    {
        public LotMarketContext(string connectionString)
            : base(connectionString, throwIfV1Schema: false)
        {
            
        }
        public LotMarketContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Lot> Lots { get; set; }
        
    }
}
