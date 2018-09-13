using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.DTO
{
    public class ApplicationProfileDTO
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string CreditCard { get; set; }
        public string Role { get; set; }
    }
}
