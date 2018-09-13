using Auction.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string ApplicationProfileId { get; set; }
        [ForeignKey("ApplicationProfileId")]
        public ApplicationProfile ApplicationProfile { get;set; }
    }
}
